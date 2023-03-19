using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace PayloadTool
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static readonly Regex _regexNew = new Regex("^-?[0-9]\\d*(\\.\\d+)?$"); //regex that matches disallowed text

        private bool _mouseExitPressed = false;
        private bool _mouseMaxPressed = false;
        private bool _mouseMinPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }
        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }
        private void ButtonBuild_Click(object sender, RoutedEventArgs e)
        {
            string[] cmFileTextSparse = new string[48];
            const string s = " ";
            const string q = "\"";
            const string sv = "SETVAR ";
            const string grp1 = "$PLST_GRP1[1].";
            const string grp2 = "$PLST_GRP1[2].";
            const string grp3 = "$PLST_GRP1[3].";
            const string grp4 = "$PLST_GRP1[4].";
            const string grp5 = "$PLST_GRP1[5].";
            const string grp6 = "$PLST_GRP1[6].";
            const string cmt = "$COMMENT";
            const string pld = "$PAYLOAD";
            const string x = "_X";
            const string y = "_Y";
            const string z = "_Z";
            const string ix = "_IX";
            const string iy = "_IY";
            const string iz = "_IZ";

            if (pl1Name.Text.Length > 0) cmFileTextSparse[0] = sv + grp1 + cmt + s + q + pl1Name.Text + q;
            if (pl1Weight.Text.Length > 0) cmFileTextSparse[1] = sv + grp1 + pld + s + pl1Weight.Text;
            if (pl1CogX.Text.Length > 0) cmFileTextSparse[2] = sv + grp1 + pld + x + s + pl1CogX.Text;
            if (pl1CogY.Text.Length > 0) cmFileTextSparse[3] = sv + grp1 + pld + y + s + pl1CogY.Text;
            if (pl1CogZ.Text.Length > 0) cmFileTextSparse[4] = sv + grp1 + pld + z + s + pl1CogZ.Text;
            if (pl1InX.Text.Length > 0) cmFileTextSparse[5] = sv + grp1 + pld + ix + s + pl1InX.Text;
            if (pl1InY.Text.Length > 0) cmFileTextSparse[6] = sv + grp1 + pld + iy + s + pl1InY.Text;
            if (pl1InZ.Text.Length > 0) cmFileTextSparse[7] = sv + grp1 + pld + iz + s + pl1InZ.Text;

            if (pl2Name.Text.Length > 0) cmFileTextSparse[8] = sv + grp2 + cmt + s + q + pl2Name.Text + q;
            if (pl2Weight.Text.Length > 0) cmFileTextSparse[9] = sv + grp2 + pld + s + pl2Weight.Text;
            if (pl2CogX.Text.Length > 0) cmFileTextSparse[10] = sv + grp2 + pld + x + s + pl2CogX.Text;
            if (pl2CogY.Text.Length > 0) cmFileTextSparse[11] = sv + grp2 + pld + y + s + pl2CogY.Text;
            if (pl2CogZ.Text.Length > 0) cmFileTextSparse[12] = sv + grp2 + pld + z + s + pl2CogZ.Text;
            if (pl2InX.Text.Length > 0) cmFileTextSparse[13] = sv + grp2 + pld + ix + s + pl2InX.Text;
            if (pl2InY.Text.Length > 0) cmFileTextSparse[14] = sv + grp2 + pld + iy + s + pl2InY.Text;
            if (pl2InZ.Text.Length > 0) cmFileTextSparse[15] = sv + grp2 + pld + iz + s + pl2InZ.Text;

            if (pl3Name.Text.Length > 0) cmFileTextSparse[16] = sv + grp3 + cmt + s + q + pl3Name.Text + q;
            if (pl3Weight.Text.Length > 0) cmFileTextSparse[17] = sv + grp3 + pld + s + pl3Weight.Text;
            if (pl3CogX.Text.Length > 0) cmFileTextSparse[18] = sv + grp3 + pld + x + s + pl3CogX.Text;
            if (pl3CogY.Text.Length > 0) cmFileTextSparse[19] = sv + grp3 + pld + y + s + pl3CogY.Text;
            if (pl3CogZ.Text.Length > 0) cmFileTextSparse[20] = sv + grp3 + pld + z + s + pl3CogZ.Text;
            if (pl3InX.Text.Length > 0) cmFileTextSparse[21] = sv + grp3 + pld + ix + s + pl3InX.Text;
            if (pl3InY.Text.Length > 0) cmFileTextSparse[22] = sv + grp3 + pld + iy + s + pl3InY.Text;
            if (pl3InZ.Text.Length > 0) cmFileTextSparse[23] = sv + grp3 + pld + iz + s + pl3InZ.Text;

            if (pl4Name.Text.Length > 0) cmFileTextSparse[24] = sv + grp4 + cmt + s + q + pl4Name.Text + q;
            if (pl4Weight.Text.Length > 0) cmFileTextSparse[25] = sv + grp4 + pld + s + pl4Weight.Text;
            if (pl4CogX.Text.Length > 0) cmFileTextSparse[26] = sv + grp4 + pld + x + s + pl4CogX.Text;
            if (pl4CogY.Text.Length > 0) cmFileTextSparse[27] = sv + grp4 + pld + y + s + pl4CogY.Text;
            if (pl4CogZ.Text.Length > 0) cmFileTextSparse[28] = sv + grp4 + pld + z + s + pl4CogZ.Text;
            if (pl4InX.Text.Length > 0) cmFileTextSparse[29] = sv + grp4 + pld + ix + s + pl4InX.Text;
            if (pl4InY.Text.Length > 0) cmFileTextSparse[30] = sv + grp4 + pld + iy + s + pl4InY.Text;
            if (pl4InZ.Text.Length > 0) cmFileTextSparse[31] = sv + grp4 + pld + iz + s + pl4InZ.Text;

            if (pl5Name.Text.Length > 0) cmFileTextSparse[32] = sv + grp5 + cmt + s + q + pl5Name.Text + q;
            if (pl5Weight.Text.Length > 0) cmFileTextSparse[33] = sv + grp5 + pld + s + pl5Weight.Text;
            if (pl5CogX.Text.Length > 0) cmFileTextSparse[34] = sv + grp5 + pld + x + s + pl5CogX.Text;
            if (pl5CogY.Text.Length > 0) cmFileTextSparse[35] = sv + grp5 + pld + y + s + pl5CogY.Text;
            if (pl5CogZ.Text.Length > 0) cmFileTextSparse[36] = sv + grp5 + pld + z + s + pl5CogZ.Text;
            if (pl5InX.Text.Length > 0) cmFileTextSparse[37] = sv + grp5 + pld + ix + s + pl5InX.Text;
            if (pl5InY.Text.Length > 0) cmFileTextSparse[38] = sv + grp5 + pld + iy + s + pl5InY.Text;
            if (pl5InZ.Text.Length > 0) cmFileTextSparse[39] = sv + grp5 + pld + iz + s + pl5InZ.Text;

            if (pl6Name.Text.Length > 0) cmFileTextSparse[40] = sv + grp6 + cmt + s + q + pl6Name.Text + q;
            if (pl6Weight.Text.Length > 0) cmFileTextSparse[41] = sv + grp6 + pld + s + pl6Weight.Text;
            if (pl6CogX.Text.Length > 0) cmFileTextSparse[42] = sv + grp6 + pld + x + s + pl6CogX.Text;
            if (pl6CogY.Text.Length > 0) cmFileTextSparse[43] = sv + grp6 + pld + y + s + pl6CogY.Text;
            if (pl6CogZ.Text.Length > 0) cmFileTextSparse[44] = sv + grp6 + pld + z + s + pl6CogZ.Text;
            if (pl6InX.Text.Length > 0) cmFileTextSparse[45] = sv + grp6 + pld + ix + s + pl6InX.Text;
            if (pl6InY.Text.Length > 0) cmFileTextSparse[46] = sv + grp6 + pld + iy + s + pl6InY.Text;
            if (pl6InZ.Text.Length > 0) cmFileTextSparse[47] = sv + grp6 + pld + iz + s + pl6InZ.Text;

            int numLines = 0;
            foreach (var line in cmFileTextSparse)
            {
                if (line != null)
                    numLines++;
            }
            string[] cmFileTextDense = new string[numLines];

            int i = 0;
            foreach (var line in cmFileTextSparse)
            {
                if (line != null)
                {
                    cmFileTextDense[i++] = line;
                }
            }

            BuildFile(cmFileTextDense);
        }

        // Save JSON of current values
        private static void SaveFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                Title = "Save file",
                Filter = "Text Document (*.txt) | *.txt",
                FileName = ""
            };

            if (saveFileDialog1.ShowDialog() == true)
            {
                //File.WriteAllText(saveFileDialog1.FileName, pl1Name.Text);
                //fileName.Text = "Filename: " + System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
            }

        }

        // Save CM File
        private static void BuildFile(string[] cmFileText)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                Title = "Build CM file",
                Filter = "CM File (*.cm) | *.cm",
                FileName = ""
            };

            if (saveFileDialog1.ShowDialog() == true)
            {

                File.WriteAllLines(saveFileDialog1.FileName, cmFileText);
                //fileName.Text = "Filename: " + System.IO.Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
            }
        }

        // Open JSON Saved File
        private static void OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Title = "Open CM file",
                Filter = "CM File (*.cm) | *.cm",
                FileName = ""
            };

            if (openFileDialog1.ShowDialog() == true)
            {
                //fileName.Text = openFileDialog1.FileName;
                //fileText.Text = File.ReadAllText(openFileDialog1.FileName);
            }

        }
        private static bool IsTextAllowed(string text)
        {
            bool isAllowed = !_regex.IsMatch(text);

            char dot = '.';
            int numDots = text.Count(f => (f == dot));
            return isAllowed && (numDots <= 1);
        }

        private static bool IsDotAllowed(string text)
        {
            char dot = '.';
            int numDots = text.Count(f => (f == dot));
            return (numDots < 1);
        }

        private static bool IsNegativeAllowed(string text)
        {
            char neg = '-';
            int numNegs = text.Count(f => (f == neg));
            return (numNegs < 1);
        }

        private void DockPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BorderMin_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _mouseMinPressed = true;
        }

        private void BorderMin_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_mouseMinPressed)
            {
                _mouseMinPressed = false;
                this.WindowState = WindowState.Minimized;
            }
        }

        private void BorderMax_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _mouseMaxPressed = true;
        }

        private void BorderMax_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (_mouseMaxPressed)
            //{
            //    _mouseMaxPressed = false;
            //    this.WindowState = WindowState.Maximized;
            //}
        }

        private void BorderClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _mouseExitPressed = true;
        }

        private void BorderClose_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_mouseExitPressed)
            {
                _mouseExitPressed = false;
                this.Close();
            }
        }

        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox? inputText = e.Source as TextBox;
            TextBox? originalSrc = e.OriginalSource as TextBox;
            if (e.Text.Equals("."))
            {
                e.Handled = !IsDotAllowed(inputText.Text);
            }
            else if (e.Text.Equals("-"))
            {
                e.Handled = !((originalSrc.CaretIndex < 1) && IsNegativeAllowed(inputText.Text));
            }
            else
            {
                e.Handled = !IsTextAllowed(e.Text);
            }
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }

}
