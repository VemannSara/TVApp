namespace TVApp
{
    partial class FilmValasztasForm
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
            filmListBox = new ListBox();
            label2 = new Label();
            datumListBox = new ListBox();
            mentButton = new Button();
            FelvetelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(113, 28);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 0;
            label1.Text = "Mit szeretnél nézni?";
            // 
            // filmListBox
            // 
            filmListBox.BackColor = SystemColors.InactiveBorder;
            filmListBox.FormattingEnabled = true;
            filmListBox.Location = new Point(96, 77);
            filmListBox.Name = "filmListBox";
            filmListBox.Size = new Size(165, 224);
            filmListBox.TabIndex = 1;
            filmListBox.SelectedIndexChanged += filmListBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.Location = new Point(349, 28);
            label2.Name = "label2";
            label2.Size = new Size(201, 20);
            label2.TabIndex = 2;
            label2.Text = "Melyik időpontban néznéd?";
            // 
            // datumListBox
            // 
            datumListBox.BackColor = SystemColors.InactiveBorder;
            datumListBox.FormattingEnabled = true;
            datumListBox.Location = new Point(367, 77);
            datumListBox.Name = "datumListBox";
            datumListBox.Size = new Size(169, 224);
            datumListBox.TabIndex = 3;
            // 
            // mentButton
            // 
            mentButton.BackColor = Color.FromArgb(192, 255, 192);
            mentButton.Location = new Point(200, 325);
            mentButton.Name = "mentButton";
            mentButton.Size = new Size(94, 29);
            mentButton.TabIndex = 4;
            mentButton.Text = "Ment";
            mentButton.UseVisualStyleBackColor = false;
            mentButton.Click += mentButton_Click;
            // 
            // FelvetelButton
            // 
            FelvetelButton.Location = new Point(335, 325);
            FelvetelButton.Name = "FelvetelButton";
            FelvetelButton.Size = new Size(94, 29);
            FelvetelButton.TabIndex = 5;
            FelvetelButton.Text = "Felvétel";
            FelvetelButton.UseVisualStyleBackColor = true;
            FelvetelButton.Click += FelvetelButton_Click;
            // 
            // FilmValasztasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(622, 450);
            Controls.Add(FelvetelButton);
            Controls.Add(mentButton);
            Controls.Add(datumListBox);
            Controls.Add(label2);
            Controls.Add(filmListBox);
            Controls.Add(label1);
            Name = "FilmValasztasForm";
            Text = "FilmValasztasForm";
            Load += FilmValasztasForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox filmListBox;
        private Label label2;
        private ListBox datumListBox;
        private Button mentButton;
        private Button FelvetelButton;
    }
}