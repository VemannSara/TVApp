namespace TVApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            XmlButton = new Button();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            FilmnezesButton = new Button();
            dateTimePicker1 = new DateTimePicker();
            KeresesButton = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            adminToolStripMenuItem = new ToolStripMenuItem();
            label8 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            ResetDateButton = new Button();
            WholeListButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 350);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1032, 334);
            dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(7, 300);
            label1.Name = "label1";
            label1.Size = new Size(194, 28);
            label1.TabIndex = 2;
            label1.Text = "Aktuális műsorlista";
            // 
            // XmlButton
            // 
            XmlButton.Location = new Point(915, 303);
            XmlButton.Name = "XmlButton";
            XmlButton.Size = new Size(94, 29);
            XmlButton.TabIndex = 3;
            XmlButton.Text = "xml";
            XmlButton.UseVisualStyleBackColor = true;
            XmlButton.Click += XmlButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(12, 116);
            label2.Name = "label2";
            label2.Size = new Size(84, 28);
            label2.TabIndex = 4;
            label2.Text = "Keresés";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 171);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 5;
            label3.Text = "Név";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(105, 168);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 214);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 7;
            label4.Text = "Csatorna";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(105, 211);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 260);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 9;
            label5.Text = "Műfaj";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(105, 260);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(267, 168);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 11;
            label6.Text = "Műsor";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(348, 168);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(267, 227);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 13;
            label7.Text = "Időtartam";
            // 
            // FilmnezesButton
            // 
            FilmnezesButton.Location = new Point(800, 303);
            FilmnezesButton.Name = "FilmnezesButton";
            FilmnezesButton.Size = new Size(94, 29);
            FilmnezesButton.TabIndex = 14;
            FilmnezesButton.Text = "Filmnézés";
            FilmnezesButton.UseVisualStyleBackColor = true;
            FilmnezesButton.Click += FilmnezesButton_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(348, 227);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 15;
            dateTimePicker1.Value = new DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // KeresesButton
            // 
            KeresesButton.Location = new Point(366, 278);
            KeresesButton.Name = "KeresesButton";
            KeresesButton.Size = new Size(94, 29);
            KeresesButton.TabIndex = 16;
            KeresesButton.Text = "Keresés";
            KeresesButton.UseVisualStyleBackColor = true;
            KeresesButton.Click += KeresesButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.GradientInactiveCaption;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1043, 28);
            menuStrip1.TabIndex = 17;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { adminToolStripMenuItem });
            toolStripMenuItem1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(63, 24);
            toolStripMenuItem1.Text = "Menu";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(139, 26);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label8.Location = new Point(472, 53);
            label8.Name = "label8";
            label8.Size = new Size(32, 38);
            label8.TabIndex = 18;
            label8.Text = "a";
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // ResetDateButton
            // 
            ResetDateButton.BackColor = Color.IndianRed;
            ResetDateButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            ResetDateButton.ForeColor = SystemColors.ButtonHighlight;
            ResetDateButton.Location = new Point(617, 228);
            ResetDateButton.Name = "ResetDateButton";
            ResetDateButton.Size = new Size(25, 26);
            ResetDateButton.TabIndex = 19;
            ResetDateButton.Text = "X";
            ResetDateButton.UseVisualStyleBackColor = false;
            ResetDateButton.Click += ResetDateButton_Click;
            // 
            // WholeListButton
            // 
            WholeListButton.BackColor = Color.FromArgb(100, 215, 143);
            WholeListButton.Location = new Point(504, 278);
            WholeListButton.Name = "WholeListButton";
            WholeListButton.Size = new Size(94, 29);
            WholeListButton.TabIndex = 20;
            WholeListButton.Text = "Teljes lista";
            WholeListButton.UseVisualStyleBackColor = false;
            WholeListButton.Click += WholeListButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1043, 696);
            Controls.Add(WholeListButton);
            Controls.Add(ResetDateButton);
            Controls.Add(label8);
            Controls.Add(KeresesButton);
            Controls.Add(dateTimePicker1);
            Controls.Add(FilmnezesButton);
            Controls.Add(label7);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(XmlButton);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "TVApp";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label label1;
        private Button XmlButton;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox4;
        private Label label7;
        private Button FilmnezesButton;
        private DateTimePicker dateTimePicker1;
        private Button KeresesButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private Label label8;
        private Label label9;
        private NotifyIcon notifyIcon1;
        private Button ResetDateButton;
        private Button WholeListButton;
    }
}
