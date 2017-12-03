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
using System.IO;
using Microsoft.Win32;

namespace SliceApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageSlice imageSlice;
        GridRenderer gridRenderer;


        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.bmp;*.gif)|*.png;*.jpeg;*.bmp;*.gif";
                
            if (openFileDialog.ShowDialog() == true)
            {
                Stream myStream = null;

                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        //ImageBrush Implementation
                        BitmapSource bs = new BitmapImage(new Uri(openFileDialog.FileName));
                        ImageBrush imgB = new ImageBrush(bs);
                        VisualGrid.Background = imgB;

                        VisualGrid.Width = bs.Width;
                        VisualGrid.Height = bs.Height;

                        gridRenderer = new GridRenderer(Convert.ToInt32(bs.Width), Convert.ToInt32(bs.Height));
                        
                    }
                    
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void QuitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SliceButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridRenderer != null)
            {
                gridRenderer.drawGrid(VisualGrid);
            }

        }

        private void WidthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gridRenderer != null && String.IsNullOrEmpty(WidthTextBox.Text))
            {
                
                gridRenderer.CellWidth = int.Parse(WidthTextBox.Text);
                gridRenderer.drawGrid(VisualGrid);
            }
        }

        private void HeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (gridRenderer != null && !String.IsNullOrEmpty(HeightTextBox.Text))
            {
                gridRenderer.CellHeight = int.Parse(HeightTextBox.Text);
                gridRenderer.drawGrid(VisualGrid);
            }
        }
    }
}
