// Lousy but fast coding by ref :D
// it mostly works, updates are wellcome

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenRhubarb
{

    public partial class Form1 : Form
    {
        string selectedFilePath = "";

        void readjson()
        {

            string jsonFilePath = textBox1.Text;
            if (jsonFilePath == "") return;
            string jsonString = File.ReadAllText(jsonFilePath);
            listBox1.Items.Clear();
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
                        button2.Text = "4. Generate Animation";

                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFFconcat();

        }

        void saveFFconcat()
        {
            string jsonFilePath = textBox1.Text;
            string newPath = Path.ChangeExtension(jsonFilePath, "fct");
            SaveListBoxItemsToFile(listBox1, newPath);
            string newOutPath = Path.ChangeExtension(jsonFilePath, "mp4");
            newOutPath = System.IO.Path.GetFileName(newOutPath);
            textBox8.Text = newOutPath;
            updateExec();
        }

        void updateExec()
        {
            string jsonFilePath = textBox6.Text;
            string newPath = Path.ChangeExtension(jsonFilePath, "fct");
            string aud = "";
            if (!checkBox3.Checked) aud = "-i " + Path.GetFileName(jsonFilePath);
            newPath = System.IO.Path.GetFileName(newPath);
            string w = GetValidNumb(textBox3.Text, 1);
            string h = GetValidNumb(textBox3.Text, 2);

            textBox2.Text = textBox4.Text.Replace("<w>", w).Replace("<h>", h).Replace("<fct>", newPath).Replace("<out>", textBox8.Text).Replace("<include_audio>", aud);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (CheckValidNumb(textBox3.Text)) textBox3.BackColor = SystemColors.Window; else textBox3.BackColor = Color.Red;
            updateExec();


        }
        static int GetClosestEvenNumber(int value)
        {
            // Calculate the closest even number
            int closestEven = value / 2 * 2;
            return closestEven;
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

                string newOutPath = Path.ChangeExtension(jsonFilePath, "mp4");
                newOutPath = System.IO.Path.GetFileName(newOutPath);
                textBox8.Text = newOutPath;


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
                    outputTextBox.Text = "Generating lip sync animation...";
                    Application.DoEvents();

                    readjson();
                    outputTextBox.Text = "Preparing to encode mp4....";
                    Application.DoEvents();

                    saveFFconcat();
                    outputTextBox.Text = "Encoding now...";
                    Application.DoEvents();

                    newstartencode();
                    Application.DoEvents();

                }
            }
            else if (outputTextBox.Text.Contains("frames duplicated"))
            {
                outputTextBox.Text = "Encoding done.";
                tabControl1.TabIndex = 3;
            }
        }


        private void newstartencode()
        {

            checkBox2.Checked = false;
            string arguments = textBox2.Text;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"ffmpeg\ffmpeg.exe",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true
            };

            process.Start();

            string processOutput = null;
            while ((processOutput = process.StandardError.ReadLine()) != null)
            {
                // do something with processOutput
                //Debug.WriteLine(processOutput);


                //listBox3.Items.Clear();
                //listBox3.Items.Add(processOutput);
                outputTextBox.Text = processOutput;
                if (checkBox2.Checked)
                {
                    process.StandardInput.WriteLine("q");
                }
                Application.DoEvents();
                //this.Refresh();

            }
            process.WaitForExit();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            newstartencode();
        }

        static string DoubleNumbersInString(string input, bool fix)
        {
            // Split the string into parts using 'x' as the separator
            string[] parts = input.Split('x');

            if (parts.Length == 2)
            {
                if (int.TryParse(parts[0], out int firstNumber) && int.TryParse(parts[1], out int secondNumber))
                {

                    if (fix)
                    {
                        firstNumber = GetClosestEvenNumber(firstNumber);
                        secondNumber = GetClosestEvenNumber(secondNumber);
                    }
                    else
                    {
                        // Double the numbers
                        firstNumber *= 2;
                        secondNumber *= 2;
                    }
                    // Reconstruct the string
                    return $"{firstNumber}x{secondNumber}";
                }
            }

            // Return the original string if parsing or doubling failed
            return input;
        }

        static bool CheckValidNumb(string input)
        {
            // Split the string into parts using 'x' as the separator
            string[] parts = input.Split('x');

            if (parts.Length == 2)
            {
                if (int.TryParse(parts[0], out int firstNumber) && int.TryParse(parts[1], out int secondNumber))
                {
                    if ((firstNumber % 2 == 0) && (secondNumber % 2 == 0)) { return true; }


                }
            }

            // Return the original string if parsing or doubling failed
            return false;
        }

        static string GetValidNumb(string input, int part)
        {
            // Split the string into parts using 'x' as the separator
            string[] parts = input.Split('x');

            if (parts.Length == 2)
            {
                if (int.TryParse(parts[0], out int firstNumber) && int.TryParse(parts[1], out int secondNumber))
                {
                    if (part == 1) return firstNumber.ToString();
                    if (part == 2) return secondNumber.ToString();

                }
            }

            // Return the original string if parsing or doubling failed
            return "0";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox3.Text = DoubleNumbersInString(textBox3.Text, false);
        }

        static void OpenFolderInExplorer(string folderPath)
        {
            if (System.IO.Directory.Exists(folderPath))
            {
                Process.Start("explorer.exe", folderPath);
            }
            else
            {
                Console.WriteLine("The specified folder does not exist.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFolderInExplorer(Path.GetDirectoryName(textBox1.Text));
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            updateExec();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox3.Text = DoubleNumbersInString(textBox3.Text, true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string firstItem = listBox2.Items.Count > 0 ? listBox2.Items[0].ToString() : "";
            if (firstItem == "")
            {
                textBox3.Text = "320x256";
                return;
            }
            using (Image image = Image.FromFile(firstItem))
            {
                int width = image.Width;
                int height = image.Height;
                textBox3.Text = width + "x" + height;
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

            string url = "https://github.com/ref-xx/GenRhubarb/"; // rhubarb url
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
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