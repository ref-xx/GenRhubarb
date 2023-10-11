namespace GenRhubarb
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
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            listBox1 = new ListBox();
            button3 = new Button();
            listBox2 = new ListBox();
            button4 = new Button();
            textBox2 = new TextBox();
            button5 = new Button();
            checkBox1 = new CheckBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button6 = new Button();
            button7 = new Button();
            textBox7 = new TextBox();
            outputTextBox = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(533, 107);
            button1.Name = "button1";
            button1.Size = new Size(255, 23);
            button1.TabIndex = 0;
            button1.Text = "Pick/Change  Rhubarb JSON";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 108);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(515, 23);
            textBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(533, 414);
            button2.Name = "button2";
            button2.Size = new Size(255, 23);
            button2.TabIndex = 2;
            button2.Text = "4. Parse JSON";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 149);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(515, 289);
            listBox1.TabIndex = 3;
            // 
            // button3
            // 
            button3.Location = new Point(533, 139);
            button3.Name = "button3";
            button3.Size = new Size(137, 23);
            button3.TabIndex = 4;
            button3.Text = "3.Pick Image Folder";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.HorizontalScrollbar = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(533, 168);
            listBox2.Name = "listBox2";
            listBox2.ScrollAlwaysVisible = true;
            listBox2.Size = new Size(255, 184);
            listBox2.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new Point(533, 443);
            button4.Name = "button4";
            button4.Size = new Size(255, 23);
            button4.TabIndex = 6;
            button4.Text = "5. save ffconcat file";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 472);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(515, 23);
            textBox2.TabIndex = 7;
            textBox2.Text = "create concat file";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(533, 472);
            button5.Name = "button5";
            button5.Size = new Size(255, 23);
            button5.TabIndex = 8;
            button5.Text = "6. Convert to mp4";
            button5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(533, 358);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Use full paths";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(688, 139);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 10;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 501);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(141, 23);
            textBox4.TabIndex = 11;
            textBox4.Text = "ffmpeg -f concat -safe 0 -i <fct> -c:a aac -c:v libx264 -pix_fmt yuv420p -s <res> -r 25 <out>";
            textBox4.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(159, 501);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(368, 23);
            textBox5.TabIndex = 12;
            textBox5.Text = "rhubarb.exe <wav> --machineReadable -f json -r phonetic -o <json>";
            textBox5.Visible = false;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(12, 20);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(515, 23);
            textBox6.TabIndex = 14;
            // 
            // button6
            // 
            button6.Location = new Point(533, 20);
            button6.Name = "button6";
            button6.Size = new Size(255, 23);
            button6.TabIndex = 13;
            button6.Text = "1. Pick Wav File To Prepare";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(533, 49);
            button7.Name = "button7";
            button7.Size = new Size(255, 23);
            button7.TabIndex = 15;
            button7.Text = "2. Create Rhubarb JSON";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(12, 50);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(515, 23);
            textBox7.TabIndex = 16;
            textBox7.Text = "Pick a wav first";
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(12, 79);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size(776, 23);
            outputTextBox.TabIndex = 17;
            outputTextBox.Text = "...";
            outputTextBox.TextChanged += outputTextBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 536);
            Controls.Add(outputTextBox);
            Controls.Add(textBox7);
            Controls.Add(button7);
            Controls.Add(textBox6);
            Controls.Add(button6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(checkBox1);
            Controls.Add(button5);
            Controls.Add(textBox2);
            Controls.Add(button4);
            Controls.Add(listBox2);
            Controls.Add(button3);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private ListBox listBox1;
        private Button button3;
        private ListBox listBox2;
        private Button button4;
        private TextBox textBox2;
        private Button button5;
        private CheckBox checkBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button6;
        private Button button7;
        private TextBox textBox7;
        private TextBox outputTextBox;
    }
}