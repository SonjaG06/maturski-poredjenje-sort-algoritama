namespace moje
{
    partial class GlavnaForma
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
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            GenerisiNizButton = new Button();
            SortirajButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(25, 93);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1000, 700);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(421, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(196, 28);
            comboBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(171, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(76, 27);
            textBox1.TabIndex = 5;
            textBox1.Text = "100";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 32);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 7;
            label1.Text = "Unesite duzinu niza:";
            // 
            // GenerisiNizButton
            // 
            GenerisiNizButton.Location = new Point(264, 21);
            GenerisiNizButton.Name = "GenerisiNizButton";
            GenerisiNizButton.Size = new Size(104, 41);
            GenerisiNizButton.TabIndex = 8;
            GenerisiNizButton.Text = "Generiši niz";
            GenerisiNizButton.UseVisualStyleBackColor = true;
            GenerisiNizButton.Click += GenerisiNizButton_Click;
            // 
            // SortirajButton
            // 
            SortirajButton.Location = new Point(657, 24);
            SortirajButton.Name = "SortirajButton";
            SortirajButton.Size = new Size(125, 39);
            SortirajButton.TabIndex = 9;
            SortirajButton.Text = "Sortiraj";
            SortirajButton.UseVisualStyleBackColor = true;
            SortirajButton.Click += SortirajButton_Click;
            // 
            // GlavnaForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1495, 819);
            Controls.Add(SortirajButton);
            Controls.Add(GenerisiNizButton);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GlavnaForma";
            WindowState = FormWindowState.Maximized;
            Load += GlavnaForma_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Button GenerisiNizButton;
        private Button SortirajButton;
    }
}