using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ResizeImages {

	enum SizeMetaData {
		large,
		medium,
		small,
		xlarge,
		xsmall,
		xxlarge,
		xxxlarge
	};

	class MainClass {

		public static void Main (string[] args) {

			// this application must be run in the folder with images for resize
			string currentPath = System.IO.Directory.GetCurrentDirectory() ;
			string lastPath = String.Empty;
			string imagesForResizePath = currentPath;
			var imgFolderPath = currentPath + "/img";

			//-- Load image
			var imagesForResize = Image.GetImages(imagesForResizePath);

			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.DarkBlue;

		  // Create folder
			Console.WriteLine ("Current path: " +  currentPath);

			// If img folder doesn't exist -> create it
			// else -> delete it and create a new one
			if (!Directory.Exists (imgFolderPath)) {
				Directory.CreateDirectory (imgFolderPath);
				Console.WriteLine ("New folder for images created at  " + imgFolderPath);
			} else {
				try {
					Directory.Delete(imgFolderPath, true);
					Console.WriteLine("Delete old folder");
					Directory.CreateDirectory (imgFolderPath);
					Console.WriteLine ("New folder for images created at  " + imgFolderPath);
				} catch(Exception ex) {
					Console.WriteLine ("!!! ERROR !!!  " + ex);
				}
			}

			// Create type of folders enum
			var sizeList = new List<Image>();
			sizeList.Add (new Image (SizeMetaData.large.ToString(),    933, 525));
			sizeList.Add (new Image (SizeMetaData.medium.ToString(),   400, 225));
			sizeList.Add (new Image (SizeMetaData.small.ToString(),    355, 200));
			sizeList.Add (new Image (SizeMetaData.xlarge.ToString(),   1333, 750));
			sizeList.Add (new Image (SizeMetaData.xsmall.ToString(),   140, 78));
			sizeList.Add (new Image (SizeMetaData.xxlarge.ToString(),  1300, 731));
			sizeList.Add (new Image (SizeMetaData.xxxlarge.ToString(), 3968, 2232));

			foreach(var item in sizeList) {

				lastPath = currentPath;
				currentPath = imgFolderPath + '/' + item.TypeOfSize;

				//create folder in the curent location with metaData name
				Directory.CreateDirectory (currentPath );
				Console.WriteLine ("New folder for images created at  " + currentPath);
				// go in the new created folder
				Directory.SetCurrentDirectory (currentPath);

				foreach(var image in imagesForResize) {
					// resize image an save it in folder
					Image.ResizeImage (image.BitmapImage, currentPath + '/' + image.Name, item.Width, item.Heigth);
				}

			}

			Console.BackgroundColor = ConsoleColor.Green;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.WriteLine (" ---  Magic done ---- !! ");
			Console.ReadKey ();
		}
		 
	}
}
