namespace TechMeasurements_2020_L2_3D_Data_Izometry
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox_plane = new System.Windows.Forms.CheckBox();
            this.checkBox_voxel = new System.Windows.Forms.CheckBox();
            this.checkBox_dot = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Fov = new System.Windows.Forms.NumericUpDown();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSaveImg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownRZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_start = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.numericUpDown_start = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_delta = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_Zmin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Ymin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Xmax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Zmax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Ymax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Xmin = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox_otsrch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Fov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Zmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ymin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Xmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Zmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ymax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Xmin)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_plane
            // 
            this.checkBox_plane.AutoSize = true;
            this.checkBox_plane.Location = new System.Drawing.Point(186, 145);
            this.checkBox_plane.Name = "checkBox_plane";
            this.checkBox_plane.Size = new System.Drawing.Size(81, 17);
            this.checkBox_plane.TabIndex = 105;
            this.checkBox_plane.Text = "Плоскость";
            this.checkBox_plane.UseVisualStyleBackColor = true;
            // 
            // checkBox_voxel
            // 
            this.checkBox_voxel.AutoSize = true;
            this.checkBox_voxel.Location = new System.Drawing.Point(88, 145);
            this.checkBox_voxel.Name = "checkBox_voxel";
            this.checkBox_voxel.Size = new System.Drawing.Size(69, 17);
            this.checkBox_voxel.TabIndex = 104;
            this.checkBox_voxel.Text = "Воксили";
            this.checkBox_voxel.UseVisualStyleBackColor = true;
            // 
            // checkBox_dot
            // 
            this.checkBox_dot.AutoSize = true;
            this.checkBox_dot.Checked = true;
            this.checkBox_dot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_dot.Location = new System.Drawing.Point(3, 145);
            this.checkBox_dot.Name = "checkBox_dot";
            this.checkBox_dot.Size = new System.Drawing.Size(56, 17);
            this.checkBox_dot.TabIndex = 103;
            this.checkBox_dot.Text = "Точки";
            this.checkBox_dot.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "Угол обзора";
            // 
            // numericUpDown_Fov
            // 
            this.numericUpDown_Fov.Location = new System.Drawing.Point(86, 294);
            this.numericUpDown_Fov.Maximum = new decimal(new int[] {
            179,
            0,
            0,
            0});
            this.numericUpDown_Fov.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Fov.Name = "numericUpDown_Fov";
            this.numericUpDown_Fov.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown_Fov.TabIndex = 101;
            this.numericUpDown_Fov.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.Location = new System.Drawing.Point(288, 3);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(600, 400);
            this.openGLControl1.TabIndex = 100;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseDown);
            this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseMove);
            this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl1_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "X";
            // 
            // buttonSaveImg
            // 
            this.buttonSaveImg.Location = new System.Drawing.Point(1, 320);
            this.buttonSaveImg.Name = "buttonSaveImg";
            this.buttonSaveImg.Size = new System.Drawing.Size(131, 26);
            this.buttonSaveImg.TabIndex = 94;
            this.buttonSaveImg.Text = "Сохранить картинку";
            this.buttonSaveImg.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Направление";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Положение";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-2, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 98;
            this.label7.Text = "Z";
            // 
            // numericUpDownRZ
            // 
            this.numericUpDownRZ.DecimalPlaces = 3;
            this.numericUpDownRZ.Location = new System.Drawing.Point(87, 268);
            this.numericUpDownRZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownRZ.Name = "numericUpDownRZ";
            this.numericUpDownRZ.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRZ.TabIndex = 90;
            // 
            // numericUpDownRY
            // 
            this.numericUpDownRY.DecimalPlaces = 3;
            this.numericUpDownRY.Location = new System.Drawing.Point(87, 242);
            this.numericUpDownRY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownRY.Name = "numericUpDownRY";
            this.numericUpDownRY.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRY.TabIndex = 89;
            // 
            // numericUpDownRX
            // 
            this.numericUpDownRX.DecimalPlaces = 3;
            this.numericUpDownRX.Location = new System.Drawing.Point(87, 216);
            this.numericUpDownRX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownRX.Name = "numericUpDownRX";
            this.numericUpDownRX.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownRX.TabIndex = 88;
            // 
            // numericUpDownZ
            // 
            this.numericUpDownZ.DecimalPlaces = 3;
            this.numericUpDownZ.Location = new System.Drawing.Point(18, 268);
            this.numericUpDownZ.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownZ.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownZ.Name = "numericUpDownZ";
            this.numericUpDownZ.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownZ.TabIndex = 87;
            this.numericUpDownZ.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.DecimalPlaces = 3;
            this.numericUpDownY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownY.Location = new System.Drawing.Point(18, 242);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownY.TabIndex = 86;
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.DecimalPlaces = 3;
            this.numericUpDownX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownX.Location = new System.Drawing.Point(18, 216);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownX.TabIndex = 85;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(3, 424);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(131, 26);
            this.buttonLoad.TabIndex = 83;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(4, 395);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(111, 23);
            this.button_start.TabIndex = 107;
            this.button_start.Text = "Старт";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(4, 366);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 106;
            this.button_next.Text = "Next";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(141, 424);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(269, 20);
            this.textBox_path.TabIndex = 108;
            this.textBox_path.Text = "C:\\Users\\user\\Downloads\\HokuyoLidar_lidarlog\\HokuyoLidar_lidarlog.txt";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(895, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(460, 381);
            this.listBox1.TabIndex = 109;
            // 
            // numericUpDown_start
            // 
            this.numericUpDown_start.Location = new System.Drawing.Point(121, 398);
            this.numericUpDown_start.Maximum = new decimal(new int[] {
            1783793664,
            116,
            0,
            0});
            this.numericUpDown_start.Name = "numericUpDown_start";
            this.numericUpDown_start.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_start.TabIndex = 110;
            // 
            // numericUpDown_delta
            // 
            this.numericUpDown_delta.Location = new System.Drawing.Point(185, 398);
            this.numericUpDown_delta.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numericUpDown_delta.Name = "numericUpDown_delta";
            this.numericUpDown_delta.Size = new System.Drawing.Size(58, 20);
            this.numericUpDown_delta.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Кадр";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 113;
            this.label8.Text = "Кадров одновременно ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 120;
            this.label10.Text = "X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 122;
            this.label11.Text = "Z";
            // 
            // numericUpDown_Zmin
            // 
            this.numericUpDown_Zmin.DecimalPlaces = 3;
            this.numericUpDown_Zmin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Zmin.Location = new System.Drawing.Point(27, 116);
            this.numericUpDown_Zmin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Zmin.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Zmin.Name = "numericUpDown_Zmin";
            this.numericUpDown_Zmin.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_Zmin.TabIndex = 119;
            this.numericUpDown_Zmin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // numericUpDown_Ymin
            // 
            this.numericUpDown_Ymin.DecimalPlaces = 3;
            this.numericUpDown_Ymin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Ymin.Location = new System.Drawing.Point(27, 90);
            this.numericUpDown_Ymin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Ymin.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Ymin.Name = "numericUpDown_Ymin";
            this.numericUpDown_Ymin.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_Ymin.TabIndex = 118;
            this.numericUpDown_Ymin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // numericUpDown_Xmax
            // 
            this.numericUpDown_Xmax.DecimalPlaces = 3;
            this.numericUpDown_Xmax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Xmax.Location = new System.Drawing.Point(85, 62);
            this.numericUpDown_Xmax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Xmax.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Xmax.Name = "numericUpDown_Xmax";
            this.numericUpDown_Xmax.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_Xmax.TabIndex = 117;
            this.numericUpDown_Xmax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown_Zmax
            // 
            this.numericUpDown_Zmax.DecimalPlaces = 3;
            this.numericUpDown_Zmax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Zmax.Location = new System.Drawing.Point(85, 116);
            this.numericUpDown_Zmax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Zmax.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Zmax.Name = "numericUpDown_Zmax";
            this.numericUpDown_Zmax.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_Zmax.TabIndex = 116;
            this.numericUpDown_Zmax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown_Ymax
            // 
            this.numericUpDown_Ymax.DecimalPlaces = 3;
            this.numericUpDown_Ymax.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Ymax.Location = new System.Drawing.Point(85, 90);
            this.numericUpDown_Ymax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Ymax.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Ymax.Name = "numericUpDown_Ymax";
            this.numericUpDown_Ymax.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_Ymax.TabIndex = 115;
            this.numericUpDown_Ymax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown_Xmin
            // 
            this.numericUpDown_Xmin.DecimalPlaces = 3;
            this.numericUpDown_Xmin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_Xmin.Location = new System.Drawing.Point(27, 62);
            this.numericUpDown_Xmin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Xmin.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown_Xmin.Name = "numericUpDown_Xmin";
            this.numericUpDown_Xmin.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown_Xmin.TabIndex = 114;
            this.numericUpDown_Xmin.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 124;
            this.label12.Text = "Максимум";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 123;
            this.label13.Text = "Минимум";
            // 
            // checkBox_otsrch
            // 
            this.checkBox_otsrch.AutoSize = true;
            this.checkBox_otsrch.Location = new System.Drawing.Point(27, 26);
            this.checkBox_otsrch.Name = "checkBox_otsrch";
            this.checkBox_otsrch.Size = new System.Drawing.Size(80, 17);
            this.checkBox_otsrch.TabIndex = 125;
            this.checkBox_otsrch.Text = "Отсечение";
            this.checkBox_otsrch.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 450);
            this.Controls.Add(this.checkBox_otsrch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown_Zmin);
            this.Controls.Add(this.numericUpDown_Ymin);
            this.Controls.Add(this.numericUpDown_Xmax);
            this.Controls.Add(this.numericUpDown_Zmax);
            this.Controls.Add(this.numericUpDown_Ymax);
            this.Controls.Add(this.numericUpDown_Xmin);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_delta);
            this.Controls.Add(this.numericUpDown_start);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.checkBox_plane);
            this.Controls.Add(this.checkBox_voxel);
            this.Controls.Add(this.checkBox_dot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_Fov);
            this.Controls.Add(this.openGLControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSaveImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownRZ);
            this.Controls.Add(this.numericUpDownRY);
            this.Controls.Add(this.numericUpDownRX);
            this.Controls.Add(this.numericUpDownZ);
            this.Controls.Add(this.numericUpDownY);
            this.Controls.Add(this.numericUpDownX);
            this.Controls.Add(this.buttonLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Fov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Zmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ymin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Xmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Zmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ymax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Xmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_plane;
        private System.Windows.Forms.CheckBox checkBox_voxel;
        private System.Windows.Forms.CheckBox checkBox_dot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Fov;
        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSaveImg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownRZ;
        private System.Windows.Forms.NumericUpDown numericUpDownRY;
        private System.Windows.Forms.NumericUpDown numericUpDownRX;
        private System.Windows.Forms.NumericUpDown numericUpDownZ;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_start;
        private System.Windows.Forms.NumericUpDown numericUpDown_delta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_Zmin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Ymin;
        private System.Windows.Forms.NumericUpDown numericUpDown_Xmax;
        private System.Windows.Forms.NumericUpDown numericUpDown_Zmax;
        private System.Windows.Forms.NumericUpDown numericUpDown_Ymax;
        private System.Windows.Forms.NumericUpDown numericUpDown_Xmin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox_otsrch;
    }
}

