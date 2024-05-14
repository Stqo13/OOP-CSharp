using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
			this.Length = length;
			this.Width = width;
			this.Height = height;
        }
        private double length;

		public double Length
		{
			get { return length; }
			private set 
			{
				if (value<=0)
				{
					throw new ArgumentException($"Length cannot be zero or negative.");
				}
				length = value; 
			}
		}
		private double width;

		public double Width
		{
			get { return width; }
			private set 
			{ 
				if (value <= 0)
				{
					throw new ArgumentException($"Width cannot be zero or negative.");
				}
				width = value; 
			}
		}
		private double height;

		public double Height
		{
			get { return height; }
			private set 
			{ 
				if (value <= 0)
				{
					throw new ArgumentException($"Height cannot be zero or negative.");
				}
				height = value; 
			}
		}
		public double SurfaceArea()
		{
			double area = 0;
			return area = 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);
		}
		public double LateralSurfaceArea()
		{
			double area = 0;
			return area = 2 * (this.Length * this.Height + this.Width * this.Height);
		}
		public double Volume()
		{
			double volume = 0;
			return volume = this.Length * this.Width * this.Height;
		}
    }
}
