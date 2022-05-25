namespace imageprocess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.fileOpenBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.byte_per_line = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.output_image = new System.Windows.Forms.PictureBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.output_image)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 27);
            this.textBox1.TabIndex = 0;
            // 
            // fileOpenBtn
            // 
            this.fileOpenBtn.Location = new System.Drawing.Point(366, 28);
            this.fileOpenBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileOpenBtn.Name = "fileOpenBtn";
            this.fileOpenBtn.Size = new System.Drawing.Size(192, 31);
            this.fileOpenBtn.TabIndex = 1;
            this.fileOpenBtn.Text = "browse file";
            this.fileOpenBtn.UseVisualStyleBackColor = true;
            this.fileOpenBtn.Click += new System.EventHandler(this.fileOpenBtn_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(49, 152);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(199, 27);
            this.textBox2.TabIndex = 2;
            // 
            // byte_per_line
            // 
            this.byte_per_line.AutoSize = true;
            this.byte_per_line.Location = new System.Drawing.Point(59, 128);
            this.byte_per_line.Name = "byte_per_line";
            this.byte_per_line.Size = new System.Drawing.Size(96, 20);
            this.byte_per_line.TabIndex = 3;
            this.byte_per_line.Text = "byte_per_line";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image height";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(325, 152);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(148, 27);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(565, 152);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(168, 27);
            this.textBox4.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(565, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Image width";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(49, 186);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(234, 33);
            this.textBox5.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(451, 186);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(588, 33);
            this.textBox6.TabIndex = 9;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(739, 285);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(324, 443);
            this.textBox7.TabIndex = 10;
            // 
            // output_image
            // 
            this.output_image.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.output_image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("output_image.BackgroundImage")));
            this.output_image.Location = new System.Drawing.Point(49, 347);
            this.output_image.Name = "output_image";
            this.output_image.Size = new System.Drawing.Size(460, 381);
            this.output_image.TabIndex = 11;
            this.output_image.TabStop = false;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(49, 255);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(443, 27);
            this.textBox8.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 788);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.output_image);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.byte_per_line);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.fileOpenBtn);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.output_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button fileOpenBtn;
        private TextBox textBox2;
        private Label byte_per_line;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label2;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private PictureBox output_image;
        private TextBox textBox8;
    }
}