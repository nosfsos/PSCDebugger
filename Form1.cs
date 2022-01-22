using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptDebugger
{
    public partial class MainWindow : Form
    {
        private List<string> _filePaths;
        private string _scriptsDirectory;
        private string _targetDirectory;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void open_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _scriptsDirectory = fbd.SelectedPath;
                    _filePaths = Directory.EnumerateFiles(_scriptsDirectory, "*.psc", SearchOption.AllDirectories).ToList();

                    MessageBox.Show(@"Files found: " + _filePaths.Count, @"Message");

                    //MessageBox.Show(_filePaths[0]);
                }
            }
        }

        private void addDebugLines_Click(object sender, EventArgs e)
        {
            var startDebug = "Debug.Trace(\"Function starting!\")";
            var endDebug = "Debug.Trace(\"Function ending!{0}\")";

            if (string.IsNullOrWhiteSpace(_targetDirectory) || string.IsNullOrWhiteSpace(_scriptsDirectory))
            {
                MessageBox.Show(@"Select the folders before pressing this button");
                return;
            }

            foreach (var filePath in _filePaths)
            {
                //var readText = File.ReadAllLines(filePath).ToList();

                var fileText = new List<string>();
                using (var reader = new StreamReader(filePath))
                {
                    while (reader.EndOfStream == false)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                            continue;

                        if (line.Length == 0 || line[0] == ';' || line[0] == '/') // current line is empty or is a comment
                            continue;

                        if (line.Contains("Function") && line.Contains("(") && line.Contains(")")) // function declaration line
                        {
                            // add startDebug line

                            var spacesCount = Regex.Matches(line, "\t");
                            var sb = new StringBuilder();

                            for (var i = 0; i < spacesCount.Count; i++)
                            {
                                sb.Append("\t");
                            }

                            sb.Append("\t"); // extra indent to be ahead of Function

                            fileText.Add(line);
                            fileText.Add(sb + startDebug);
                        }
                        else if (line.Contains("EndFunction") || line.Contains("return"))
                        {
                            // add endDebug before returns and EndFunctions

                            var spacesCount = Regex.Matches(line, "\t");
                            var sb = new StringBuilder();

                            for (var i = 0; i < spacesCount.Count; i++)
                            {
                                sb.Append("\t");
                            }

                            if (line.Contains("EndFunction"))
                                sb.Append("\t"); // extra indent to be ahead of EndFunction. Not needed in case of return
                            fileText.Add( string.Format(sb + endDebug, line.Contains("return") ? line : ""));
                            fileText.Add(line);
                        }
                        else
                        {
                            fileText.Add(line);
                        }
                    }
                    reader.Dispose();
                }

                // write the lines back to the file

                var path = _targetDirectory + filePath.Replace(_scriptsDirectory, "");
                //MessageBox.Show(path);
                var newDir = "";
                var directory = path.Split('\\');
                for (var i = 0; i < directory.Length - 1; i++)
                {
                    newDir += directory[i] + (i == directory.Length - 1 ? "": "\\");
                }

                if (Directory.Exists(newDir) == false)
                    Directory.CreateDirectory(newDir);

                File.WriteAllLines(path, fileText);

                //readText.Clear();
            }

            MessageBox.Show(@"Done");
        }

        private void targetDirectory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _targetDirectory = fbd.SelectedPath;

                    MessageBox.Show(@"Directory selected: " + _targetDirectory, @"Message");

                    //MessageBox.Show(_filePaths[0]);
                }
            }
        }
    }
}
