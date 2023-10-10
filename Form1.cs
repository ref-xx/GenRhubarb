
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GenRhubarb
{

    public partial class Form1 : Form
    {
        string selectedFilePath = "";

        void readjson()
        {
            string jsonFilePath = textBox1.Text;
            string jsonString = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON into your C# object
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Match JSON property names without case sensitivity
            };
            Root jsonRoot = JsonSerializer.Deserialize<Root>(jsonString, options);

            // Access the mouthCues data
            List<MouthCue> mouthCues = jsonRoot.MouthCues;


            listView1.Items.Clear();

            foreach (MouthCue mouthCue in mouthCues)
            {
                ListViewItem item = new ListViewItem(mouthCue.Start.ToString()); // Add the Start value
                item.SubItems.Add(mouthCue.End.ToString()); // Add the End value
                item.SubItems.Add(mouthCue.Value); // Add the Value
                listView1.Items.Add(item); // Add the item to the ListView
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