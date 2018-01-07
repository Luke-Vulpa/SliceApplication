using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
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
        private int _cellHeight;
        private int _cellWidth;
        private String _path;


        private ImageSource _image;

        /// <summary>
        /// Purpose of class to take an image, iterate over and cutting off a subimage then saving that to the harddisc.
        /// </summary>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        

        public ImageSlice(ImageSource anImage,int cellWidth, int cellHeight)
        {
            ImageWidth = (int)anImage.Width;
            ImageHeight = (int)anImage.Height;
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            _image = anImage;
        }

        public int CellWidth
        {
            set { _cellWidth = value; }
            get { return _cellWidth; }
        }

        public int CellHeight
        {
            set { _cellHeight = value; }
            get { return _cellHeight; }
        }

        public int ImageWidth
        {
            set { _imageWidth = value; }
            get { return _imageWidth; }
        }

        public int ImageHeight
        {
            set { _imageHeight = value; }
            get { return _imageHeight; }
        }

        public void Slice()
        {
            
        }
        public void Incise()
        {
            

        }

        public void Save()
        {
            

        }







        //public List<Line> setLines(int cellWidth, int cellHeight)
        //{
           
        //    for (var y = 0; y < _imageWidth; y += cellWidth)
        //    {
        //        var myLine = new Line();
        //        myLine.Stroke = System.Windows.Media.Brushes.Black;
        //        myLine.StrokeThickness = 2;
        //        for (var x = 0; x < _imageHeight; x += cellHeight)
        //        {
        //            myLine.X1 = 0;
        //            myLine.X2 = _imageWidth;
        //            myLine.Y1 = y;
        //            myLine.Y2 = y;

        //            hLines.Add(myLine);
        //            myLine = new Line();
        //        }
        //    }

        //    return hLines;
        //}


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
