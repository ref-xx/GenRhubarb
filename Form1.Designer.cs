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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            checkBox2 = new CheckBox();
            button8 = new Button();
            button9 = new Button();
            textBox8 = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            label2 = new Label();
            tabPage3 = new TabPage();
            label3 = new Label();
            tabPage4 = new TabPage();
            groupBox1 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            checkBox3 = new CheckBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(200, 217);
            button1.Name = "button1";
            button1.Size = new Size(255, 23);
            button1.TabIndex = 0;
            button1.Text = "Pick/Change  Rhubarb JSON";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 188);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(449, 23);
            textBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(203, 132);
            button2.Name = "button2";
            button2.Size = new Size(255, 23);
            button2.TabIndex = 2;
            button2.Text = "Generate Animation";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(6, 161);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(452, 244);
            listBox1.TabIndex = 3;
            // 
            // button3
            // 
            button3.Location = new Point(308, 141);
            button3.Name = "button3";
            button3.Size = new Size(150, 23);
            button3.TabIndex = 4;
            button3.Text = "Pick Image Folder";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.HorizontalScrollbar = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(9, 170);
            listBox2.Name = "listBox2";
            listBox2.ScrollAlwaysVisible = true;
            listBox2.Size = new Size(449, 139);
            listBox2.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new Point(203, 410);
            button4.Name = "button4";
            button4.Size = new Size(255, 23);
            button4.TabIndex = 6;
            button4.Text = "Save ffconcat file";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 133);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(440, 23);
            textBox2.TabIndex = 7;
            textBox2.Text = "first create concat file in previous page";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button5
            // 
            button5.Location = new Point(197, 162);
            button5.Name = "button5";
            button5.Size = new Size(255, 23);
            button5.TabIndex = 8;
            button5.Text = "6. Convert to mp4";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(6, 414);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "Use full paths";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(165, 315);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(104, 23);
            textBox3.TabIndex = 10;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 60);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(440, 23);
            textBox4.TabIndex = 11;
            textBox4.Text = "-y -f concat -safe 0 -i <fct> <include_audio> -c:a aac -c:v libx264 -pix_fmt yuv420p -vf \"scale=<w>:<h>:flags=neighbor\" -r 25 <out>";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(6, 31);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(440, 23);
            textBox5.TabIndex = 12;
            textBox5.Text = "rhubarb.exe <wav> --machineReadable -f json -r phonetic -o <json>";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(9, 55);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(449, 23);
            textBox6.TabIndex = 14;
            // 
            // button6
            // 
            button6.Location = new Point(308, 84);
            button6.Name = "button6";
            button6.Size = new Size(150, 23);
            button6.TabIndex = 13;
            button6.Text = "Pick Wav File To Prepare";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(299, 406);
            button7.Name = "button7";
            button7.Size = new Size(162, 23);
            button7.TabIndex = 15;
            button7.Text = "Start Encoding";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(6, 377);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(455, 23);
            textBox7.TabIndex = 16;
            textBox7.Text = "Rhubarb parameters will be shown here, you may modify them if you want";
            // 
            // outputTextBox
            // 
            outputTextBox.Enabled = false;
            outputTextBox.Location = new Point(12, 491);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size(468, 23);
            outputTextBox.TabIndex = 17;
            outputTextBox.Text = "...";
            outputTextBox.TextChanged += outputTextBox_TextChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Enabled = false;
            checkBox2.Location = new Point(349, 191);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(103, 19);
            checkBox2.TabIndex = 18;
            checkBox2.Text = "Stop encoding";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(342, 315);
            button8.Name = "button8";
            button8.Size = new Size(55, 23);
            button8.TabIndex = 19;
            button8.Text = "Double";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(197, 244);
            button9.Name = "button9";
            button9.Size = new Size(255, 23);
            button9.TabIndex = 20;
            button9.Text = "Show output folder";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(116, 407);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(177, 23);
            textBox8.TabIndex = 21;
            textBox8.Text = "out.mp4";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(8, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(472, 473);
            tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button12);
            tabPage1.Controls.Add(button11);
            tabPage1.Controls.Add(button10);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(button8);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBox8);
            tabPage1.Controls.Add(textBox7);
            tabPage1.Controls.Add(button6);
            tabPage1.Controls.Add(textBox6);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(listBox2);
            tabPage1.Controls.Add(button7);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(464, 445);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Convert Wav";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Location = new Point(308, 7);
            button12.Name = "button12";
            button12.Size = new Size(150, 23);
            button12.TabIndex = 27;
            button12.Text = "Open Github Page";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.Location = new Point(403, 315);
            button11.Name = "button11";
            button11.Size = new Size(55, 23);
            button11.TabIndex = 26;
            button11.Text = "Reset";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.Location = new Point(275, 315);
            button10.Name = "button10";
            button10.Size = new Size(61, 23);
            button10.TabIndex = 25;
            button10.Text = "Closest";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 356);
            label6.Name = "label6";
            label6.Size = new Size(288, 15);
            label6.TabIndex = 24;
            label6.Text = "You may modify encoding templates in the last page.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 87);
            label5.Name = "label5";
            label5.Size = new Size(293, 75);
            label5.TabIndex = 23;
            label5.Text = resources.GetString("label5.Text");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 410);
            label4.Name = "label4";
            label4.Size = new Size(96, 15);
            label4.TabIndex = 22;
            label4.Text = "Output Filename";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 7);
            label1.Name = "label1";
            label1.Size = new Size(240, 45);
            label1.TabIndex = 16;
            label1.Text = "Wav to Mp4 Rhubarb Lip Sync Helper by Ref\r\n\r\nPlease select your wav file ";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(464, 445);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Convert JSON";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 16);
            label2.Name = "label2";
            label2.Size = new Size(303, 150);
            label2.TabIndex = 17;
            label2.Text = resources.GetString("label2.Text");
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(listBox1);
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(checkBox1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(464, 445);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Json Preview";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 8);
            label3.Name = "label3";
            label3.Size = new Size(464, 105);
            label3.TabIndex = 0;
            label3.Text = resources.GetString("label3.Text");
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(groupBox1);
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(checkBox3);
            tabPage4.Controls.Add(checkBox2);
            tabPage4.Controls.Add(button9);
            tabPage4.Controls.Add(button5);
            tabPage4.Controls.Add(textBox2);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(464, 445);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Encoder Config";
            tabPage4.UseVisualStyleBackColor = true;
            tabPage4.Click += tabPage4_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Location = new Point(6, 273);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(452, 166);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Templates";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 97);
            label8.Name = "label8";
            label8.Size = new Size(331, 75);
            label8.TabIndex = 24;
            label8.Text = resources.GetString("label8.Text");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 26);
            label7.Name = "label7";
            label7.Size = new Size(322, 60);
            label7.TabIndex = 22;
            label7.Text = "You may modify the ffmeg parameters here, \r\nthese modifications will be reset when you select a new wav\r\n\r\nsuch as flags=bicubic scales better for photos";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Enabled = false;
            checkBox3.Location = new Point(12, 165);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(181, 19);
            checkBox3.TabIndex = 21;
            checkBox3.Text = "Do not put audio. Video only.";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 526);
            Controls.Add(tabControl1);
            Controls.Add(outputTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "GenRhubarb Wav2Mp4 Lip Sync V0.1 by Ref - 10/2023";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private CheckBox checkBox2;
        private Button button8;
        private Button button9;
        private TextBox textBox8;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private TabPage tabPage2;
        private Label label2;
        private TabPage tabPage3;
        private Label label3;
        private Label label4;
        private TabPage tabPage4;
        private Label label6;
        private Label label5;
        private CheckBox checkBox3;
        private Label label7;
        private Button button10;
        private Button button11;
        private GroupBox groupBox1;
        private Label label8;
        private Button button12;
    }
}