using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.ServiceReference1;

namespace RestaurantManagement
{
    public class ImageMethods
    {

        Service1Client srv = new Service1Client();
        public void SaveImage(byte[] imageArray, string fileName)  //save image
        {
            var stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            string localFilePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);
            img.Save(localFilePath);
        }

        byte[] imgArray;
        public void SelectImage(BaseEntity baseEntity)
        {
            //Create Open_File_Dialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "All Images | *.jpg;*.jpeg;*.tif;*.tiff;*.bmp;*.png|JPEG Files(*.jpeg)|*.jpeg|PNG Files(*.png)|*.pmg|JPG Files (*.jpg)|*.jpg|GIF Files (*gif)|*.gif";

            //Display Open_File_Dialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            //Get the selcted file name and display in a textbox
            if (result == true)
            {
                //open document
                string filename = dlg.FileName;
                /* byte[]*/
                imgArray = File.ReadAllBytes(filename);
                filename = System.IO.Path.GetFileName(filename);
                SaveImage(imgArray, filename);
                //   s.SendImageWithName(imgArray, filename);
                if (baseEntity is Menuu)
                {
                    Menuu m = baseEntity as Menuu;
                  //  m.Pic1 = srv.SendImageWithName(imgArray, System.IO.Path.GetFileName(filename));    // מה לעשות פה???
                }
            }
        }
    }
}
