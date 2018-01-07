using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Forms; // Forms used for FolderBrowserDialog
using Microsoft.Win32;
using System.IO;
using SliceApplication.Properties;

namespace SliceApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageSlice imageSlice;
        GridRenderer gridRenderer;
        //BitmapSource bs;
        FolderBrowserDialog fbd;


        public MainWindow()
        {
            InitializeComponent();
            
            fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Settings.Default.SavePath;
            PathTextBox.Text = Settings.Default.SavePath;

            WidthTextBox.Text = Settings.Default.CellWidth;
            HeightTextBox.Text = Settings.Default.CellHeight;
            
            //set up event delgates
            WidthTextBox.TextChanged += WidthTextBox_TextChanged;
            HeightTextBox.TextChanged += HeightTextBox_TextChanged;
            PathTextBox.TextChanged += PathTextBox_TextChanged;
        }


        #region Click Event Functions 


        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.bmp;*.gif)|*.png;*.jpeg;*.bmp;*.gif";
                
            if (openFileDialog.ShowDialog() == true)
            {
                Stream myStream = null;

                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {

                        BitmapSource bs = new BitmapImage(new Uri(openFileDialog.FileName));
                      
                        ImageBrush imgBrush = new ImageBrush(bs);
                        
                        VisualGrid.Background = imgBrush;
                        


                        VisualGrid.Width = bs.PixelWidth;
                        VisualGrid.Height = bs.PixelHeight;

                        VisualGrid.RowDefinitions.Clear();
                        VisualGrid.ColumnDefinitions.Clear();

                        gridRenderer = new GridRenderer(bs.PixelWidth, bs.PixelHeight);
                        gridRenderer.drawGrid(VisualGrid);
                        //imageSlice = new ImageSlice(bs, Convert.ToInt32(bs.Width), Convert.ToInt32(bs.Height));

                    }
                    
                }
                catch (FileNotFoundException ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
            e.Handled = true;
        }


        private void QuitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void SliceButton_Click(object sender, RoutedEventArgs e)
        {
            /// VisualGrid.background is used to instanciate image slice instance
            if (gridRenderer != null)
            {
               
                e.Handled = true;
            }

        }


        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aw = new AboutWindow();
            aw.Show();
        }


        private void PreferencesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.Show();
        }


        private void PathButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathTextBox.Text = fbd.SelectedPath;
                e.Handled = true;
                
            }
        }

        #endregion

        #region TextChanged Event Functions 


        private void WidthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (gridRenderer != null && !String.IsNullOrEmpty(WidthTextBox.Text))
            {
                if (Convert.ToInt32(WidthTextBox.Text) < VisualGrid.ActualHeight)
                {
                    gridRenderer.CellWidth = int.Parse(WidthTextBox.Text);
                    gridRenderer.drawGrid(VisualGrid);

                    e.Handled = true;
                }
            }
        }

        private void HeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gridRenderer != null && !String.IsNullOrEmpty(HeightTextBox.Text))
            {
                if (Convert.ToInt32(HeightTextBox.Text) < VisualGrid.ActualHeight)
                {
                    gridRenderer.CellHeight = int.Parse(HeightTextBox.Text);
                    gridRenderer.drawGrid(VisualGrid);

                    e.Handled = true;
                }
            }
        }

        private void PathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        #endregion


    }
}
