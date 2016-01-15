using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace didactic_palm_tree.Views.Converter
{
    public class BulbImageConverter : IValueConverter
    {
        public object Convert(object value, Type typename, object parameter, CultureInfo info)
        {
            string url = ((bool) value) ? "../../../Resources/Bulb_On.png" : "../../../ Resources/Bulb_Off.png";
            return new BitmapImage(new Uri(url, UriKind.Relative));
        }

        public object ConvertBack(object value, Type typename, object parameter, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
