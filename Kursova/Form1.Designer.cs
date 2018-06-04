namespace Kursova
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Menu = new System.Windows.Forms.Panel();
            this.Land = new System.Windows.Forms.Button();
            this.Align = new System.Windows.Forms.Button();
            this.LeaveOrbit = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.Lauch = new System.Windows.Forms.Button();
            this.MarsTravel = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Graph = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Menu.Controls.Add(this.Land);
            this.Menu.Controls.Add(this.Align);
            this.Menu.Controls.Add(this.LeaveOrbit);
            this.Menu.Controls.Add(this.PauseButton);
            this.Menu.Controls.Add(this.Lauch);
            this.Menu.Controls.Add(this.MarsTravel);
            this.Menu.Controls.Add(this.labelSpeed);
            this.Menu.Controls.Add(this.numericUpDown1);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(108, 986);
            this.Menu.TabIndex = 1;
            // 
            // Land
            // 
            this.Land.Location = new System.Drawing.Point(13, 255);
            this.Land.Name = "Land";
            this.Land.Size = new System.Drawing.Size(86, 38);
            this.Land.TabIndex = 9;
            this.Land.Text = "Prepare for Landing";
            this.Land.UseMnemonic = false;
            this.Land.UseVisualStyleBackColor = true;
            this.Land.Click += new System.EventHandler(this.Land_Click);
            // 
            // Align
            // 
            this.Align.Location = new System.Drawing.Point(13, 217);
            this.Align.Name = "Align";
            this.Align.Size = new System.Drawing.Size(86, 31);
            this.Align.TabIndex = 8;
            this.Align.Text = "Align Orbits";
            this.Align.UseMnemonic = false;
            this.Align.UseVisualStyleBackColor = true;
            this.Align.Click += new System.EventHandler(this.Align_Click);
            // 
            // LeaveOrbit
            // 
            this.LeaveOrbit.Location = new System.Drawing.Point(13, 180);
            this.LeaveOrbit.Name = "LeaveOrbit";
            this.LeaveOrbit.Size = new System.Drawing.Size(86, 30);
            this.LeaveOrbit.TabIndex = 7;
            this.LeaveOrbit.Text = "Leave Orbit";
            this.LeaveOrbit.UseMnemonic = false;
            this.LeaveOrbit.UseVisualStyleBackColor = true;
            this.LeaveOrbit.Click += new System.EventHandler(this.LeaveOrbit_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(12, 60);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(87, 32);
            this.PauseButton.TabIndex = 6;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseMnemonic = false;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // Lauch
            // 
            this.Lauch.Location = new System.Drawing.Point(12, 138);
            this.Lauch.Name = "Lauch";
            this.Lauch.Size = new System.Drawing.Size(87, 35);
            this.Lauch.TabIndex = 5;
            this.Lauch.Text = "Launch spaceship";
            this.Lauch.UseMnemonic = false;
            this.Lauch.UseVisualStyleBackColor = true;
            this.Lauch.Click += new System.EventHandler(this.Lauch_Click);
            // 
            // MarsTravel
            // 
            this.MarsTravel.Location = new System.Drawing.Point(12, 98);
            this.MarsTravel.Name = "MarsTravel";
            this.MarsTravel.Size = new System.Drawing.Size(87, 34);
            this.MarsTravel.TabIndex = 3;
            this.MarsTravel.Text = "View Earth\'s Orbit";
            this.MarsTravel.UseMnemonic = false;
            this.MarsTravel.UseVisualStyleBackColor = true;
            this.MarsTravel.Click += new System.EventHandler(this.Solar_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSpeed.Location = new System.Drawing.Point(32, 9);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(38, 13);
            this.labelSpeed.TabIndex = 1;
            this.labelSpeed.Text = "Speed";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.InterceptArrowKeys = false;
            this.numericUpDown1.Location = new System.Drawing.Point(12, 28);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(87, 16);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.UseWaitCursor = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Graph
            // 
            this.Graph.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Graph.BackgroundImage")));
            this.Graph.Dock = System.Windows.Forms.DockStyle.Right;
            this.Graph.Location = new System.Drawing.Point(105, 0);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(1119, 986);
            this.Graph.TabIndex = 2;
            this.Graph.Paint += new System.Windows.Forms.PaintEventHandler(this.Graph_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 986);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.Menu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel Graph;
        private System.Windows.Forms.Button Lauch;
        private System.Windows.Forms.Button PauseButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button LeaveOrbit;
        public System.Windows.Forms.Button MarsTravel;
        private System.Windows.Forms.Button Land;
        private System.Windows.Forms.Button Align;
    }
}

