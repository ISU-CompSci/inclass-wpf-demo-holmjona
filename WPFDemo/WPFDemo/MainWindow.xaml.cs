using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        string[] fileData;

        public MainWindow() {
            InitializeComponent();
        }

        private void btnSayHello_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Yo!!!");
        }


        /// <summary>
        /// Reads in a text file and not sure yet what because we were not told.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadFile_Click(object sender, RoutedEventArgs e) {
            //Button btn = btnReadFile;
            //Button btn2 = (Button)sender;

            //double d = 23453563.233456;
            //int i = (int)d;

            //MessageBox.Show(btn.Name);
            //MessageBox.Show(btn2.Name);

            try {
                string[] data = File.ReadAllLines("../../data/GreenEggs.txt");

                //for (int i = 0; i < data.Length; i++) {
                //    MessageBox.Show(data[i]);
                //}

                // same as above
                fileData = new string[data.Length];
                int indexToAdd = 0;
                foreach (string item in data) {
                    if (!string.IsNullOrWhiteSpace(item)) {
                        fileData[indexToAdd] = item;
                        indexToAdd++;
                    }
                }
                btnFindLine.IsEnabled = true;
            } catch (Exception ex) {
                MessageBox.Show("Oops: " + ex.Message);
            }

            
        }
        /// <summary>
        /// Based on input from user display line from text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindLine_Click(object sender, RoutedEventArgs e) {
            int lineNumber;
            if(int.TryParse(txtLineNumber.Text,out lineNumber)){
                string line = fileData[lineNumber];
                int letterNumber = int.Parse(txtLetterNumber.Text);
                char letter = line[letterNumber];
                MessageBox.Show(letter.ToString());
            } else {
                MessageBox.Show("Bad Line number");
            }

        }
    }
}
