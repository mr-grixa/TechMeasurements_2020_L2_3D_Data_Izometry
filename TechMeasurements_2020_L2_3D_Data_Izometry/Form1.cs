using SharpGL.Enumerations;
using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TechMeasurements_2020_L2_3D_Data_Izometry.Class1;
using SharpGL;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;

namespace TechMeasurements_2020_L2_3D_Data_Izometry
{
    public partial class Form1 : Form
    {
        List<Point3D> points=new List<Point3D>();
        List<byte[]> packets=new List<byte[]>();
        public Form1()
        {
            InitializeComponent();
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            // Создаем экземпляр
            OpenGL gl = this.openGLControl1.OpenGL;

            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            // Сбрасываем модельно-видовую матрицу
            gl.MatrixMode(MatrixMode.Projection);
            gl.LoadIdentity();
            gl.Perspective((double)numericUpDown_Fov.Value, (double)openGLControl1.Width / (double)openGLControl1.Height, 0.01, 10000);

            // Двигаем перо вглубь экрана
            double camX = (double)numericUpDownX.Value;
            double camY = (double)numericUpDownY.Value;
            double camZ = (double)numericUpDownZ.Value;
            gl.Translate(camX, camY, -camZ);
            // Вращаем точки 
            double angleX = (double)numericUpDownRX.Value /** Math.PI / 180.0f*/;
            double angleY = (double)numericUpDownRY.Value /** Math.PI / 180.0f*/;
            double angleZ = (double)numericUpDownRZ.Value /** Math.PI / 180.0f*/;
            gl.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(angleY, 0.0f, 1.0f, 0.0f);
            gl.Rotate(angleZ, 0.0f, 0.0f, 1.0f);


            // включаем режим смешивания
            gl.Enable(OpenGL.GL_BLEND);


            gl.Begin(OpenGL.GL_POINTS);
            
            if (points != null)
            {
                int Xmin = (int)numericUpDown_Xmin.Value;
                int Xmax = (int)numericUpDown_Xmax.Value;
                int Ymin = (int)numericUpDown_Ymin.Value;
                int Ymax = (int)numericUpDown_Ymax.Value;
                int Zmin = (int)numericUpDown_Zmin.Value;
                int Zmax = (int)numericUpDown_Zmax.Value;
                foreach (Point3D point in points)
                {
                    if (!checkBox_otsrch.Checked ||(point.x>Xmin&&point.x<Xmax&&
                        point.y > Ymin && point.y < Ymax &&
                        point.z > Zmin && point.z < Zmax))
                    {
                        gl.Color(1d, 1d, 1d);
                        gl.Vertex(point.x, point.y, point.z);
                    }
                }
            }


            gl.Perspective((double)numericUpDown_Fov.Value, (double)openGLControl1.Width / (double)openGLControl1.Height, 0.01, 100);

            // Завершаем работу
            gl.End();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] binaryData = File.ReadAllBytes(openFileDialog.FileName);

                packets = new List<byte[]>();
                int packetStart = 0;
                for (int i = 0; i < binaryData.Length - 1; i++)
                {
                    if (binaryData[i] == 0xFF && binaryData[i + 1] == 0xEE)
                    {
                        int packetLength = i - packetStart;
                        if (packetLength > 0)
                        {
                            byte[] packet = new byte[packetLength];
                            Array.Copy(binaryData, packetStart, packet, 0, packetLength);
                            packets.Add(packet);
                        }
                        packetStart = i + 2;
                        i++; // пропустить разделитель
                    }
                }

            }

        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (packets.Count != 0)
            {
                int start = (int)numericUpDown_start.Value;
                int delta = (int)numericUpDown_delta.Value;
                numericUpDown_start.Value=start + GenerateXYZ(start, delta);
            }
            
        }
        private int GenerateXYZ(int start,int delta)
        {
            points.Clear();
            listBox1.Items.Clear();
            double[] angles = new double[] {
                    -30.67,
                    -9.33,
                    -29.33,
                    -8.00,
                    -28.00,
                    -6.66,
                    -26.66,
                    -5.33,
                    -25.33,
                    -4.00,
                    -24.00,
                    -2.67,
                    -22.67,
                    -1.33,
                    -21.33,
                    0.00,
                    -20.00,
                    1.33,
                    -18.67,
                    2.67,
                    -17.33,
                    4.00,
                    -16.00,
                    5.33,
                    -14.67,
                    6.67,
                    -13.33,
                    8.00,
                    -12.00,
                    9.33,
                    -10.67,
                    10.67};
            if (delta> 0 )
            {
                for (int i = start; i < packets.Count && i < start + delta; i++)
                {
                    double azimuth = ((double)packets[i][1] * 256 + (double)packets[i][0]) / 100;
                    search(i, azimuth);
                }
                return delta;
            }
            else
            {
                double angle = ((double)packets[start][1] * 256 + (double)packets[start][0]) / 100;
                double angleOld=-1;
                bool test = true;
                double angleNew=0;
                int delt = 0;
                for (int i = start;i<packets.Count&& test ; i++)
                {

                    delt = i;
                    angleOld = angleNew;
                    angleNew = ((double)packets[i][1] * 256 + (double)packets[i][0]) / 100;                   
                    test = angleNew > angleOld;
                    if (test) { search(i, angleNew); }
                }
                return delt- start;
            }

            void search(int i, double azimuth)
            {
                //listBox1.Items.Add(azimuth);
                if (packets[i].Length < 98)
                {
                    listBox1.Items.Add(i);
                }
                else
                {
                    for (int j = 2; j < 98; j += 3)
                    {
                        double d = (packets[i][j + 1] * 256 + packets[i][j]) * 0.002;
                        double alpha = Math.PI * angles[((j + 1) / 3) - 1] / 180;
                        double beta = Math.PI * azimuth / 180;

                        double x = d * Math.Cos(beta) * Math.Cos(alpha);
                        double y = d * Math.Cos(beta) * Math.Sin(alpha);
                        double z = d * Math.Sin(beta);
                        //listBox1.Items.Add(packets[i][j + 2]);
                        points.Add(new Point3D(x, y, z));

                    }
                }

                //if (packets[i].Length > 98)
                //{
                //    int gpstimestamp = (packets[i][102] * 256 * 256 * 256 + packets[i][101] * 256 * 256 + packets[i][100] * 256 + packets[i][99]);
                //    DateTime gpsEpoch = new DateTime(1980, 1, 6, 0, 0, 0, DateTimeKind.Utc);
                //    DateTime timestamp = gpsEpoch.AddSeconds(gpstimestamp);
                //    //listBox1.Items.Add(timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                //}
            }

        }

        private Point startPoint;
        private decimal RX;
        private decimal RY;
        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                RX = numericUpDownRX.Value;
                RY = numericUpDownRY.Value;
            }
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                numericUpDownRY.Value += ((decimal)(startPoint.X - e.X) * (decimal)0.1);
                numericUpDownRX.Value += ((decimal)(startPoint.Y - e.Y) * (decimal)0.1);
                startPoint = e.Location;
            }
        }

        private void openGLControl1_MouseUp(object sender, MouseEventArgs e)
        {
            startPoint = Point.Empty;
            RX = 0;
            RY = 0;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                button_start.Text = "Старт";
            }
            else
            {
                timer1.Enabled = true;
                button_start.Text = "Стоп";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (packets.Count != 0)
            {
                int start = (int)numericUpDown_start.Value;
                int delta = (int)numericUpDown_delta.Value;
                numericUpDown_start.Value = start + GenerateXYZ(start, delta);
            }
        }
    }
}
