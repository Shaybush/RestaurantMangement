using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.IO;
using System.Windows.Controls;
using RestaurantManagement.ServiceReference1;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace RestaurantManagement
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return (bool)value == bool.Parse(parameter.ToString());
            }
            else return false;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }

    public class StrGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return "Male";
                else
                    return "Female";
            }
            else return null;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }

    public class BGConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            if (value == null || value.ToString() == "")
            {
                return new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                Color clr = (Color)value;
                return new SolidColorBrush((Color)value); ;
            }
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }



    public sealed class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {

            if (value == null) return null;

            string fileName = (string)value;
            if (fileName == "") return null;

            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);

            try
            {
                Uri uri = new Uri(fileName);// , UriKind.Relative);
                fileName = uri.Segments[uri.Segments.Length - 1];
                path = Path.Combine(Environment.CurrentDirectory, @"..\..\" + "/Images/" + fileName);

                if (!File.Exists(path))
                {
                    DownloadImage(uri, path);
                }
            }
            catch
            {
                if (!File.Exists(path)&& fileName != "")
                {
                    GetImage(fileName, path);
                }

            }


            //  finally
          
            return new BitmapImage(new Uri(path));

        }

        private void GetImage(string fileName, string localFilePath)
        {
            Service1Client service = new Service1Client();
            byte[] imageArray = service.GetImage(fileName);

            var stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            img.Save(localFilePath);
        }

        private void DownloadImage(Uri uri, string localFilePath)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                using (Stream stream = webClient.OpenRead(uri))
                {
                    using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(stream))
                    {
                        stream.Flush();
                        stream.Close();
                        bitmap.Save(localFilePath);
                    }
                }
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}

