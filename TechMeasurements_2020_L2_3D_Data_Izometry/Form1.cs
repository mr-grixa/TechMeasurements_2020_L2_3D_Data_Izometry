using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace TechMeasurements_2020_L2_3D_Data_Izometry
{
    public partial class Form1 : Form
    {
        List<Point3D> points = new List<Point3D>();
        List<byte[]> packets = new List<byte[]>();
        Cluster[] clusters;
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

            double camX = (double)numericUpDownX.Value;
            double camY = (double)numericUpDownY.Value;
            double camZ = (double)numericUpDownZ.Value;

            if (checkBox_perspective.Checked)
            {
                gl.Perspective((double)numericUpDown_Fov.Value, (double)openGLControl1.Width / (double)openGLControl1.Height, 0.01, 10000);
            }
            else
            {
                double w = (double)openGLControl1.Width / (double)openGLControl1.Height;
                double h = 1.0;
                h = h * camZ;
                w = w * camZ;
                gl.Ortho(-w, w, -h, h, -10000, 10000);
            }

            // Двигаем перо вглубь экрана
            gl.Translate(camX, camY, -camZ);

            // Вращаем точки 
            float angleX = (float)numericUpDownRX.Value /** Math.PI / 180.0f*/;
            float angleY = (float)numericUpDownRY.Value /** Math.PI / 180.0f*/;
            float angleZ = (float)numericUpDownRZ.Value /** Math.PI / 180.0f*/;
            gl.Rotate(angleX, angleY, angleZ);




            gl.Begin(OpenGL.GL_POINTS);

            //Matrix matrix = gl.GetModelViewMatrix();
            double Xmin = (double)numericUpDown_Xmin.Value;
            double Xmax = (double)numericUpDown_Xmax.Value;
            double Ymin = (double)numericUpDown_Ymin.Value;
            double Ymax = (double)numericUpDown_Ymax.Value;
            double Zmin = (double)numericUpDown_Zmin.Value;
            double Zmax = (double)numericUpDown_Zmax.Value;

            // Получаем текущую матрицу вида
            Matrix matrix = gl.GetModelViewMatrix();

            // Находим расстояние от камеры до каждой точки
            double maxDistance = 10; // Максимальное расстояние
            if (checkBox_dot.Checked && points.Count>0)
            {


                foreach (Point3D point in points)
                {
                    if (!checkBox_otsrch.Checked || (
                        point.X > Xmin && point.X < Xmax &&
                        point.Y > Ymin && point.Y < Ymax &&
                        point.Z > Zmin && point.Z < Zmax))
                    {
                        double distance = Math.Sqrt(Math.Pow(point.X - camX, 2) + Math.Pow(point.Y - camY, 2) + Math.Pow(point.Z + camZ, 2));
                        double intensity = 1.0 - distance / maxDistance; // Интенсивность точки зависит от расстояния до камеры
                        intensity = 0.5 + Math.Max(0.0, intensity / 2); // Интенсивность не может быть меньше нуля
                        gl.Color(intensity, intensity, intensity); // Устанавливаем цвет точки с учетом интенсивности

                        gl.Vertex(point.X, point.Y, point.Z);
                    }
                }
            }
            if (checkBox_cluster.Checked && points.Count > 0)
            {
                if (clusters == null)
                {
                    GenerateCluster();
                }
                Random random = new Random(42);
                foreach (Cluster cluster in clusters)
                {
                    gl.Color(random.NextDouble(), random.NextDouble(), random.NextDouble());
                    if (cluster.Points.Count != 0)
                    {
                        foreach (Point3D point in cluster.Points)
                        {
                            if (!checkBox_otsrch.Checked || (
                                point.X > Xmin && point.X < Xmax &&
                                point.Y > Ymin && point.Y < Ymax &&
                                point.Z > Zmin && point.Z < Zmax))
                            {

                                gl.Vertex(point.X, point.Y, point.Z);
                            }
                        }
                    }
                }
            }
            gl.End();

            if (checkBox_cube.Checked && points.Count > 0)
            {
                if (clusters == null)
                {
                    GenerateCluster();
                }
                Random random = new Random(42);
                foreach (Cluster cluster in clusters)
                {
                    gl.Color(random.NextDouble(), random.NextDouble(), random.NextDouble());
                    if (cluster.Points.Count > numericUpDown_clusterMinVes.Value && cluster.Radius < (double)numericUpDown_cubeMaxRadius.Value)
                    {
                        Draw.Rectangle(gl, cluster.Center.X, cluster.Center.Y, cluster.Center.Z, cluster.RadiusX, cluster.RadiusY, cluster.RadiusZ);
                    }

                }
            }
            if (checkBox_corridor.Checked && points.Count > 0)
            {
                if (points != null)
                {
                    if (clusters == null)
                    {
                        GenerateCluster();
                    }
                    double MaxDistant = (double)numericUpDown_coridorMaxDlin.Value;
                    float chekX = (float)numericUpDown_corridorX.Value / 2;
                    float chekY = (float)numericUpDown_corridorZ.Value / 2;
                    RectangleF rectChek = new RectangleF(-chekX, -chekY, chekX * 2, chekY * 2);
                    foreach (Cluster cluster in clusters)
                    {
                        if (cluster.Points.Count > numericUpDown_clusterMinVes.Value &&
                            cluster.Radius < (double)numericUpDown_cubeMaxRadius.Value)
                        {
                            float X1 = (float)(cluster.Center.X - cluster.RadiusX);
                            //double Y2 = cluster.Center.X + cluster.RadiusX / 2;
                            float Y1 = (float)(cluster.Center.Y - cluster.RadiusY);
                            // double X2 = cluster.Center.Y + cluster.RadiusY / 2;
                            double Z = -cluster.Center.Z - cluster.RadiusZ;
                            RectangleF rectangle = new RectangleF(X1, Y1, (float)cluster.RadiusX * 2, (float)cluster.RadiusY * 2);
                            if (Z > 0)
                            {
                                if (RectanglesIntersect(rectChek, rectangle))
                                {
                                    if (Z < MaxDistant)
                                    {
                                        MaxDistant = Z;
                                    }
                                }

                            }
                        }


                    }
                    numericUpDown_corridor.Value = (decimal)Math.Abs(MaxDistant);
                }
                bool RectanglesIntersect(RectangleF rect1, RectangleF rect2)
                {
                    // Проверка наложения прямоугольников друг на друга
                    if (rect1.Contains(rect2.Location) || rect2.Contains(rect1.Location))
                        return true;

                    // Проверка пересечения проекций прямоугольников на оси координат
                    if (rect1.Right >= rect2.Left && rect1.Left <= rect2.Right &&
                        rect1.Bottom >= rect2.Top && rect1.Top <= rect2.Bottom)
                        return true;

                    return false;
                }
                double corridorZ = (double)numericUpDown_corridor.Value;
                double corridorY = (double)numericUpDown_corridorZ.Value;
                double corridorX = (double)numericUpDown_corridorX.Value;
                gl.Color(1f, 0f, 0f);
                Draw.RectangleQ(gl, 0, 0, -corridorZ / 2, corridorX, corridorY, corridorZ / 2);
            }

            gl.End();

        }
        private void GenerateCluster()
        {
            int Xmin = (int)numericUpDown_Xmin.Value;
            int Xmax = (int)numericUpDown_Xmax.Value;
            int Ymin = (int)numericUpDown_Ymin.Value;
            int Ymax = (int)numericUpDown_Ymax.Value;
            int Zmin = (int)numericUpDown_Zmin.Value;
            int Zmax = (int)numericUpDown_Zmax.Value;
            if (!checkBox_otsrch.Checked)
            {
                clusters = KMeans.gen(points, (int)numericUpDown_clusterCount.Value, (int)numericUpDown_clusterMax.Value);
            }
            else
            {
                List<Point3D> point3Ds = new List<Point3D>();
                foreach (Point3D point in points)
                {

                    if (point.X > Xmin && point.X < Xmax &&
                        point.Y > Ymin && point.Y < Ymax &&
                        point.Z > Zmin && point.Z < Zmax)
                    {
                        point3Ds.Add(point);
                    }
                }
                clusters = KMeans.gen(point3Ds, (int)numericUpDown_clusterCount.Value, (int)numericUpDown_clusterMax.Value);
            }
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
                if (start + delta < packets.Count)
                {
                    numericUpDown_start.Value = start + GenerateXYZ(start, delta);
                    clusters = null;
                }
            }

        }
        private int GenerateXYZ(int start, int delta)
        {
            points.Clear();
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
            if (delta > 0)
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
                double angleOld = -1;
                bool test = true;
                double angleNew = 0;
                int delt = 0;
                for (int i = start; i < packets.Count && test; i++)
                {

                    delt = i;
                    angleOld = angleNew;
                    angleNew = ((double)packets[i][1] * 256 + (double)packets[i][0]) / 100;
                    test = angleNew > angleOld;
                    if (test) { search(i, angleNew); }
                }
                return delt - start;
            }

            void search(int i, double azimuth)
            {


                    for (int j = 2; j < 98 &&j<packets[i].Length-1; j += 3)
                    {
                        double distance = (packets[i][j + 1] * 256 + packets[i][j]) * 0.002;
                        double alpha = Math.PI * angles[((j + 1) / 3) - 1] / 180;
                        double beta = Math.PI * azimuth / 180;

                        double x = distance * Math.Cos(beta) * Math.Cos(alpha);
                        double y = distance * Math.Cos(beta) * Math.Sin(alpha);
                        double z = distance * Math.Sin(beta);
                        points.Add(new Point3D(x, y, z));

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
                if (start + delta < packets.Count)
                {
                    numericUpDown_start.Value = start + GenerateXYZ(start, delta);
                    clusters = null;
                }
            }
        }

        private void button_clusterNull_Click(object sender, EventArgs e)
        {
            clusters = null;
        }
        private void button_coridor_Click(object sender, EventArgs e)
        {
            if (points != null)
            {
                if (clusters == null)
                {
                    GenerateCluster();
                }
                double MaxDistant = (double)numericUpDown_corridor.Value;
                float chekX = (float)numericUpDown_corridorX.Value / 2;
                float chekY = (float)numericUpDown_corridorZ.Value / 2;
                RectangleF rectChek = new RectangleF(-chekX, -chekY, chekX * 2, chekY * 2);
                foreach (Cluster cluster in clusters)
                {
                    if (cluster.Points.Count > numericUpDown_clusterMinVes.Value &&
                        cluster.Radius < (double)numericUpDown_cubeMaxRadius.Value)
                    {
                        float X1 = (float)(cluster.Center.X - cluster.RadiusX);
                        //double Y2 = cluster.Center.X + cluster.RadiusX / 2;
                        float Y1 = (float)(cluster.Center.Y - cluster.RadiusY);
                        // double X2 = cluster.Center.Y + cluster.RadiusY / 2;
                        double Z = -cluster.Center.Z - cluster.RadiusZ;
                        RectangleF rectangle = new RectangleF(X1, Y1, (float)cluster.RadiusX * 2, (float)cluster.RadiusY * 2);
                        if (Z > 0)
                        {
                            if (RectanglesIntersect(rectChek, rectangle))
                            {
                                if (Z < MaxDistant)
                                {
                                    MaxDistant = Z;
                                }
                            }

                        }
                    }


                }
                numericUpDown_corridor.Value = (decimal)Math.Abs(MaxDistant);
            }
            bool RectanglesIntersect(RectangleF rect1, RectangleF rect2)
            {
                // Проверка наложения прямоугольников друг на друга
                if (rect1.Contains(rect2.Location) || rect2.Contains(rect1.Location))
                    return true;

                // Проверка пересечения проекций прямоугольников на оси координат
                if (rect1.Right >= rect2.Left && rect1.Left <= rect2.Right &&
                    rect1.Bottom >= rect2.Top && rect1.Top <= rect2.Bottom)
                    return true;

                return false;
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)(numericUpDown1.Value * 1000);
        }
    }
}
