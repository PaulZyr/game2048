using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Home0422_2048
{
    public class NumberBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "2") return "#EEE4DA";
            else if (value.ToString() == "4") return "#ECE0CA";
            else if (value.ToString() == "8") return "#F2B179";
            else if (value.ToString() == "16") return "#EC8D53";
            else if (value.ToString() == "32") return "#F67C5F";
            else if (value.ToString() == "64") return "#F65E3B";
            else if (value.ToString() == "128") return "#EDCF72";
            else if (value.ToString() == "256") return "#EDCF72";
            else if (value.ToString() == "512") return "#EDCF72";
            else return "#CDC1B5";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
