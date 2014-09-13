using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Drawing2D;

namespace ResizeImages {
	public class Image {
		public string TypeOfSize { get; set; }
		public int Width { get; set; }
		public int Heigth { get; set; }
		public Bitmap BitmapImage { get; set; }
		public string Name { get; set; }

		public Image (string typeOfSize,int width,int heigth) {
			TypeOfSize = typeOfSize;
			Width = width; 
			Heigth = heigth;
		}

		public Image(Bitmap bitmapImage, string name) {
			BitmapImage = bitmapImage;
			Name = name;
		}

		public static List<Image> GetImages(string path) {

			string[] imagesFromFolder =  Directory.GetFiles (path, "*.jpg");
			var imagesList = new List<Image>();

			foreach (string image in imagesFromFolder) {
				imagesList.Add( new Image(new Bitmap(image), Path.GetFileName(image)) );
			}

			return imagesList;
		}

		public static void ResizeImage(Bitmap sourceImage, string outputFile, int newWidth, int newHeight) {

			using (var newImage = new Bitmap (newWidth, newHeight))
			using (var graphics = Graphics.FromImage (newImage)) {
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				graphics.DrawImage (sourceImage, new Rectangle (0, 0, newWidth, newHeight));
				newImage.Save(outputFile);
			}
		}
	}
}

