using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

using RestaurantManagement.ServiceReference1;

namespace RestaurantManagement
{
    public class Genral
    {
        public static string UploadImage()//uploader
        {
            string filename = null;

            // Create OpenFileDialog 
            OpenFileDialog dlg = new OpenFileDialog();


            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            dlg.Filter = "All Images | *.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.png|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                /*string*/
                filename = dlg.FileName;
                filename = SaveImage(filename); // save the Image in LocalFolder (if not exist) rns return only thr file name

            }
            return filename;
        }


        private static string SaveImage(string sourcefileName)
        {
            string fileName = Path.GetFileName(sourcefileName);
            string localFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);
            if(!File.Exists(localFilePath))
            {
                byte[] imgArray = File.ReadAllBytes(sourcefileName);
                var stream = new MemoryStream(imgArray);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

                img.Save(localFilePath);
            }
            return fileName;
        }
        public static void sendImage(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);
            byte[] imgArray = File.ReadAllBytes(path);
            ServiceReference1.Service1Client serviceproxy = new Service1Client();
           // serviceproxy.SendImageWithName(imgArray, fileName);
            serviceproxy.SaveImage(imgArray, fileName);
        }
    }
}

