namespace TVApp
{
    partial class AdminForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            AddButton = new Button();
            button2 = new Button();
            UpdateButton = new Button();
            dataGridView1 = new DataGridView();
            MusorTextbox = new TextBox();
            CsatornaTextBox = new TextBox();
            MufajTextbox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            numericUpDown1 = new NumericUpDown();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker3 = new DateTimePicker();
            labe6 = new Label();
            label7 = new Label();
            MutasdButton = new Button();
            plotView2 = new OxyPlot.WindowsForms.PlotView();
            plotView3 = new OxyPlot.WindowsForms.PlotView();
            label6 = new Label();
            label8 = new Label();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(566, 148);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "Dátum";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(257, 64);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "Műsor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(417, 64);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 3;
            label3.Text = "Csatorna";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(600, 64);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 4;
            label4.Text = "Műfaj";
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(192, 255, 192);
            AddButton.Location = new Point(747, 100);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(94, 29);
            AddButton.TabIndex = 5;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 128);
            button2.Location = new Point(66, 169);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += DeleteButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(747, 186);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(94, 29);
            UpdateButton.TabIndex = 7;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 253);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(917, 197);
            dataGridView1.TabIndex = 8;
            // 
            // MusorTextbox
            // 
            MusorTextbox.Location = new Point(227, 100);
            MusorTextbox.Name = "MusorTextbox";
            MusorTextbox.Size = new Size(114, 27);
            MusorTextbox.TabIndex = 9;
            // 
            // CsatornaTextBox
            // 
            CsatornaTextBox.Location = new Point(393, 100);
            CsatornaTextBox.Name = "CsatornaTextBox";
            CsatornaTextBox.Size = new Size(122, 27);
            CsatornaTextBox.TabIndex = 10;
            // 
            // MufajTextbox
            // 
            MufajTextbox.Location = new Point(578, 100);
            MufajTextbox.Name = "MufajTextbox";
            MufajTextbox.Size = new Size(119, 27);
            MufajTextbox.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(464, 186);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(259, 27);
            dateTimePicker1.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(97, 64);
            label5.Name = "label5";
            label5.Size = new Size(24, 20);
            label5.TabIndex = 13;
            label5.Text = "ID";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(80, 102);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(55, 27);
            numericUpDown1.TabIndex = 14;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // plotView1
            // 
            plotView1.Location = new Point(1032, 87);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(419, 274);
            plotView1.TabIndex = 15;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(1135, 380);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 16;
            dateTimePicker2.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.Location = new Point(1135, 423);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(250, 27);
            dateTimePicker3.TabIndex = 17;
            dateTimePicker3.Value = new DateTime(2024, 1, 3, 0, 0, 0, 0);
            // 
            // labe6
            // 
            labe6.AutoSize = true;
            labe6.Location = new Point(1052, 385);
            labe6.Name = "labe6";
            labe6.Size = new Size(53, 20);
            labe6.TabIndex = 18;
            labe6.Text = "kezdet";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1072, 430);
            label7.Name = "label7";
            label7.Size = new Size(33, 20);
            label7.TabIndex = 19;
            label7.Text = "vég";
            // 
            // MutasdButton
            // 
            MutasdButton.Location = new Point(1198, 484);
            MutasdButton.Name = "MutasdButton";
            MutasdButton.Size = new Size(94, 29);
            MutasdButton.TabIndex = 20;
            MutasdButton.Text = "Mutasd!";
            MutasdButton.UseVisualStyleBackColor = true;
            MutasdButton.Click += MutasdButton_Click;
            // 
            // plotView2
            // 
            plotView2.Location = new Point(42, 510);
            plotView2.Name = "plotView2";
            plotView2.PanCursor = Cursors.Hand;
            plotView2.Size = new Size(378, 275);
            plotView2.TabIndex = 21;
            plotView2.Text = "plotView2";
            plotView2.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView2.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView2.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // plotView3
            // 
            plotView3.Location = new Point(539, 497);
            plotView3.Name = "plotView3";
            plotView3.PanCursor = Cursors.Hand;
            plotView3.Size = new Size(378, 288);
            plotView3.TabIndex = 22;
            plotView3.Text = "plotView3";
            plotView3.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView3.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView3.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(336, 20);
            label6.Name = "label6";
            label6.Size = new Size(223, 31);
            label6.TabIndex = 23;
            label6.Text = "Filmek szerkesztése";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(240, 148);
            label8.Name = "label8";
            label8.Size = new Size(91, 20);
            label8.TabIndex = 24;
            label8.Text = "Hossz (perc)";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(252, 186);
            numericUpDown2.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(55, 27);
            numericUpDown2.TabIndex = 25;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1580, 859);
            Controls.Add(numericUpDown2);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(plotView3);
            Controls.Add(plotView2);
            Controls.Add(MutasdButton);
            Controls.Add(label7);
            Controls.Add(labe6);
            Controls.Add(dateTimePicker3);
            Controls.Add(dateTimePicker2);
            Controls.Add(plotView1);
            Controls.Add(numericUpDown1);
            Controls.Add(label5);
            Controls.Add(dateTimePicker1);
            Controls.Add(MufajTextbox);
            Controls.Add(CsatornaTextBox);
            Controls.Add(MusorTextbox);
            Controls.Add(dataGridView1);
            Controls.Add(UpdateButton);
            Controls.Add(button2);
            Controls.Add(AddButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button AddButton;
        private Button button2;
        private Button UpdateButton;
        private DataGridView dataGridView1;
        private TextBox MusorTextbox;
        private TextBox CsatornaTextBox;
        private TextBox MufajTextbox;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private NumericUpDown numericUpDown1;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker3;
        private Label labe6;
        private Label label7;
        private Button MutasdButton;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private OxyPlot.WindowsForms.PlotView plotView3;
        private Label label6;
        private Label label8;
        private NumericUpDown numericUpDown2;
    }
}