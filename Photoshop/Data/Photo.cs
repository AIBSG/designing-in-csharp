using System;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int width;
		public readonly int height;
		public readonly Pixel[,] data;

		public Photo (int widthValue, int heightValue)
		{
			width = widthValue;
			height = heightValue;
			data = new Pixel[widthValue, heightValue];
		}

        public Pixel this[int x, int y]
		{
			get => data[x, y];
			set => data[x, y] = value;
		}

    }
}

