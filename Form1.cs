
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenRhubarb
{

    public partial class Form1 : Form
    {
        string selectedFilePath = "";

        void readjson()
        {
            string jsonFilePath = textBox1.Text;
            string jsonString = File.ReadAllText(jsonFilePath);

            string[] filenames;

            if (checkBox1.Checked)
            {
                filenames = ExtractFullPathFromListBox(listBox2);
            }
            else
            {
                filenames = ExtractFilenamesFromListBox(listBox2);
            }

            // Deserialize the JSON into your C# object
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Match JSON property names without case sensitivity
            };
            Root jsonRoot = JsonSerializer.Deserialize<Root>(jsonString, options);

            // Access the mouthCues data
            List<MouthCue> mouthCues = jsonRoot.MouthCues;

            listBox1.Items.Add("ffconcat version 1.0");

            foreach (MouthCue mouthCue in mouthCues)
            {
                string correspondingFilename = "NA";
                char firstChar = mouthCue.Value[0];
                int charCode = (int)firstChar;
                int index = charCode - 64;
                if (index >= 10) index = 8;

                if (index >= 0)
                {
                    correspondingFilename = filenames[index];

                }

                double diff = mouthCue.End - mouthCue.Start;
                listBox1.Items.Add("file " + correspondingFilename);
                listBox1.Items.Add("duration " + diff.ToString("F4"));// Add the item to the ListView
            }


        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);
        public static string GetShortFilename(string longFilename)
        {
            int bufferSize = 260; // MAX_PATH
            StringBuilder shortPath = new StringBuilder(bufferSize);

            int result = GetShortPathName(longFilename, shortPath, bufferSize);

            if (result == 0)
            {
                // An error occurred
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }

            return shortPath.ToString();
        }




        static void SaveListBoxItemsToFile(ListBox listBox, string filePath)
        {
            try
            {
                string[] items = new string[listBox.Items.Count];
                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    items[i] = listBox.Items[i].ToString();
                }

                File.WriteAllLines(filePath, items);
                Console.WriteLine("ListBox items have been saved to " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving ListBox items: " + ex.Message);
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the initial directory (optional)
            //openFileDialog.InitialDirectory = "C:\\";

            // Filter the types of files that can be opened
            openFileDialog.Filter = "Rhubarb Json Files (*.json)|*.json|All Files (*.*)|*.*";

            // Filter index for the default selection (optional)
            openFileDialog.FilterIndex = 1;

            // Allow multiple file selections (optional)
            openFileDialog.Multiselect = false;

            // Set the title of the dialog
            openFileDialog.Title = "Open a File";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                selectedFilePath = openFileDialog.FileName;
                textBox1.Text = selectedFilePath;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readjson();
        }

        static string[] ExtractFilenamesFromListBox(ListBox listBox)
        {
            List<string> filenames = new List<string>();

            foreach (var item in listBox.Items)
            {
                if (item is string fullPath)
                {
                    string filename = System.IO.Path.GetFileName(fullPath);
                    filenames.Add(filename);
                }
            }

            return filenames.ToArray();
        }

        static string[] ExtractFullPathFromListBox(ListBox listBox)
        {
            List<string> filenames = new List<string>();

            foreach (var item in listBox.Items)
            {
                if (item is string fullPath)
                {
                    //string filename = System.IO.Path.GetFileName(fullPath);
                    filenames.Add(GetShortFilename(fullPath).Replace('\\', '/'));
                }
            }

            return filenames.ToArray();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the initial directory (optional)
            //openFileDialog.InitialDirectory = "C:\\";

            // Filter the types of files that can be opened
            openFileDialog.Filter = "Mouth Shape Image A (*A.png)|*A.png|All Files (*.*)|*.*";

            // Filter index for the default selection (optional)
            openFileDialog.FilterIndex = 1;

            // Allow multiple file selections (optional)
            openFileDialog.Multiselect = false;

            // Set the title of the dialog
            openFileDialog.Title = "Open a File";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string Afile = openFileDialog.FileName;

                using (Image image = Image.FromFile(Afile))
                {
                    int width = image.Width;
                    int height = image.Height;
                    textBox3.Text = width + "x" + height;
                }

                string folderPath = Path.GetDirectoryName(Afile);
                char[] validEndings = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'X' };

                if (Directory.Exists(folderPath))
                {
                    string[] pngFiles = Directory.GetFiles(folderPath, "*.png");

                    // Filter the files that meet the criteria
                    var matchingFiles = pngFiles.Where(filePath =>
                    {
                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        if (!string.IsNullOrEmpty(fileName) && fileName.Length >= 1)
                        {
                            char lastChar = char.ToUpper(fileName[^1]); // Get the last character and convert it to uppercase
                            return validEndings.Contains(lastChar);
                        }
                        return false;
                    });

                    // Output the matching file paths
                    //Console.WriteLine("Matching PNG files:");
                    int total = 0;
                    listBox2.Items.Clear();

                    foreach (string filePath in matchingFiles)
                    {
                        total++;
                        listBox2.Items.Add(filePath);
                    }
                    if (total < validEndings.Length)
                    {
                        button2.Text = "MISSING ENTRIES!!!";
                    }
                    else
                    {
                        button2.Text = "Parse Json Now!";

                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string jsonFilePath = textBox1.Text;
            string newPath = Path.ChangeExtension(jsonFilePath, "fct");
            string newOutPath = Path.ChangeExtension(jsonFilePath, "mp4");
            newOutPath = System.IO.Path.GetFileName(newOutPath);
            SaveListBoxItemsToFile(listBox1, newPath);
            newPath = System.IO.Path.GetFileName(newPath);
            textBox2.Text = textBox4.Text.Replace("<res>", textBox3.Text).Replace("<fct>", newPath).Replace("<out>", newOutPath);
            button5.Enabled = true;


        }

        void updateExec()
        {
            string jsonFilePath = textBox1.Text;
            string newPath = Path.ChangeExtension(jsonFilePath, "fct");
            string newOutPath = Path.ChangeExtension(jsonFilePath, "mp4");
            newOutPath = System.IO.Path.GetFileName(newOutPath);
            newPath = System.IO.Path.GetFileName(newPath);
            textBox2.Text = textBox4.Text.Replace("<res>", textBox3.Text).Replace("<fct>", newPath).Replace("<out>", newOutPath);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            updateExec();
        }
        static async Task ExecuteCommandAsync(string command, TextBox outputTextBox)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c " + command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                // Create a synchronization context to run updates on the UI thread
                SynchronizationContext context = SynchronizationContext.Current;

                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        context.Post(_ =>
                        {
                            outputTextBox.Text = e.Data;
                        }, null);
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Data))
                    {
                        context.Post(_ =>
                        {
                            outputTextBox.Text = e.Data;

                        }, null);
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // Use Task.Run to execute the command asynchronously
                await Task.Run(() => process.WaitForExit());
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {

            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the initial directory (optional)
            //openFileDialog.InitialDirectory = "C:\\";

            // Filter the types of files that can be opened
            openFileDialog.Filter = "Wav Files (*.wav)|*.wav|Ogg files (*.ogg)|*.ogg|All Files (*.*)|*.*";

            // Filter index for the default selection (optional)
            openFileDialog.FilterIndex = 1;

            // Allow multiple file selections (optional)
            openFileDialog.Multiselect = false;

            // Set the title of the dialog
            openFileDialog.Title = "Open a File";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string oFilePath = openFileDialog.FileName;
                textBox6.Text = oFilePath;

                string jsonFilePath = textBox6.Text;
                string newPath = Path.ChangeExtension(jsonFilePath, "json");

                jsonFilePath = System.IO.Path.GetFileName(jsonFilePath);
                newPath = System.IO.Path.GetFileName(newPath);
                textBox7.Text = textBox5.Text.Replace("<wav>", jsonFilePath).Replace("<json>", newPath);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            runRhubarb();


        }
        private async void runRhubarb()
        {
            string command = textBox7.Text;

            await ExecuteCommandAsync(command, outputTextBox);
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (outputTextBox.Text.Contains("uccess"))
            {
                string jsonFilePath = textBox6.Text;
                string newPath = Path.ChangeExtension(jsonFilePath, "json");
                newPath = System.IO.Path.GetFileName(newPath);
                if (File.Exists(newPath))
                {
                    textBox1.Text = Path.ChangeExtension(jsonFilePath, "json");

                }
            }
        }
    }


    public class MouthCue
    {
        public double Start { get; set; }
        public double End { get; set; }
        public string Value { get; set; }
    }

    public class Metadata
    {
        public string SoundFile { get; set; }
        public double Duration { get; set; }
    }

    public class Root
    {
        public Metadata Metadata { get; set; }
        public List<MouthCue> MouthCues { get; set; }
    }



}