using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using System.Windows.Shapes;


namespace SliceApplication
{
    class GridRenderer
    {
        //private WriteableBitmap gridImage;

        //private uint[] pixels;
        private int _cellWidth;
        private int _cellHeight;
        private int _imageWidth;
        private int _imageHeight;


        public GridRenderer(int imageWidth, int imageHeight, int cellWidth = 16, int cellHeight = 16)
        {
            _cellWidth = cellWidth;
            _cellHeight = cellHeight;
            _imageWidth = imageWidth;
            _imageHeight = imageHeight;
            //gridImage = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
            //pixels = new uint[Convert.ToInt32(width) * Convert.ToInt32(height)];
        }

        /// <summary>
        /// What do I need to do next?
        /// </summary>


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

        public void drawGrid(Grid aGrid)
        {
            
            // cell > 0 is to catch edge case from trying to render while Height and Width Textboxes are empty
            if (CellWidth > 0)
            {
                
                for (var y = 0; y < ImageWidth; y += CellWidth)
                {
                    
                    ColumnDefinition col = new ColumnDefinition();
                    col.Width = new GridLength(CellWidth, GridUnitType.Pixel);
                    aGrid.ColumnDefinitions.Add(col);
                }
                aGrid.ColumnDefinitions.Clear();
            }
            if (CellHeight > 0)
            {
                
                for (var x = 0; x < ImageHeight; x += CellHeight)
                {
                    
                    RowDefinition row = new RowDefinition();
                    row.Height = new GridLength(CellHeight, GridUnitType.Pixel);
                    aGrid.RowDefinitions.Add(row);
                }
                aGrid.RowDefinitions.Clear();
            }
        }

        public override string ToString()
        {
            return String.Format("Image CellWidth:{0}/n Image Height:{1}/n Cell CellWidth:{2}/n Cell Height:{3}",ImageWidth,ImageHeight,CellWidth,CellHeight);
        }


    }
}
