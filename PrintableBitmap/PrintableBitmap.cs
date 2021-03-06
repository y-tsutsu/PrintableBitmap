﻿using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;

namespace PrintableBitmap
{
    class PrintableBitmap
    {
        public Bitmap Bitmap { private set; get; }
        public PrintableBitmap(string filename) => Bitmap = new Bitmap(filename);
        public override string ToString()
        {
            int w = Bitmap.Width;
            int h = (int)(Bitmap.Height * 0.42);
            int height = 64;
            int width = (int)(w / (float)h * height);
            var resizebmp = new Bitmap(Bitmap, width, height);
            var text = new StringBuilder((width + 1) * height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pxl = resizebmp.GetPixel(x, y);
                    text.Append(ToChar((byte)((pxl.R + pxl.B + pxl.G) / 3)));
                }
                text.Append('\n');
            }
            return text.ToString().TrimEnd('\n');
        }
        private char ToChar(byte pixel)
        {
            var table = new List<(byte p, char c)>
            {
                (249, ' '), (239, '`'), (233 , '.'), (217 , ','), (198 , '-'), (185, '~'), (173, '+'), (160, '<'), (147 , '>'), (134, 'o'), (109, '='), (83, '*'), (52, '%'), (13 , 'X'), (0, '@')
            };
            return table.SkipWhile(x => x.p > pixel).First().c;
        }
    }
}
