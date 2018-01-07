using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using SliceApplication.Properties;

namespace SliceApplication
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            WidthTextBox.Text = Settings.Default.CellWidth;
            HeightTextBox.Text = Settings.Default.CellHeight;
            PathTextBox.Text = Settings.Default.SavePath;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            WidthTextBox.Text = Settings.Default.CellWidth;
            HeightTextBox.Text = Settings.Default.CellHeight;
            PathTextBox.Text = Settings.Default.SavePath;
            this.Close();
        }
    }
}
