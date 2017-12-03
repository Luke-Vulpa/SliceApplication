using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SliceApplication
{
    class ImageSlice
    {
        private int _imageWidth;
        private int _imageHeight;
        public List<Line> hLines = new List<Line>();

        public ImageSlice(int imageWidth,int imageHeight)
        {
            _imageWidth = imageWidth;
            _imageHeight = imageHeight;

        }
        
        public List<Line> setLines(int cellWidth, int cellHeight)
        {
           
            for (var y = 0; y < _imageWidth; y += cellWidth)
            {
                var myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.Black;
                myLine.StrokeThickness = 2;
                for (var x = 0; x < _imageHeight; x += cellHeight)
                {
                    myLine.X1 = 0;
                    myLine.X2 = _imageWidth;
                    myLine.Y1 = y;
                    myLine.Y2 = y;

                    hLines.Add(myLine);
                    myLine = new Line();
                }
            }

            return hLines;
        }


        public static void drawLine(Canvas c)
        {
            for (var y = 0; y < c.Width; y += 8)
            {


                for (var x = 0; x < c.Height; x += 8)
                {
                    var line = new Line();
                    line.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                    line.VerticalAlignment = VerticalAlignment.Center;
                    line.StrokeThickness = 2;
                    line.X1 = 0;
                    line.X2 = c.Width;
                    line.Y1 = y;
                    line.Y2 = y;


                    c.Children.Add(line);
                }
            }

        }
    }

}
