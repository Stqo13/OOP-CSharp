using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        private int width;

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }


        public void Draw()
        {
            DrawLine(this.width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');
            }
            DrawLine(this.width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
