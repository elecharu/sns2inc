using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ITSLIB
{
    public class CvtFileKey : IValueConverter
    {
        private string _FileKey = "";
        public object Convert(object fileKey, Type targetType, object parameter, CultureInfo culture)
        {
            _FileKey = fileKey.ToString();
            StringBuilder query = new StringBuilder("SELECT FILEURL('" + fileKey + "')");
            string fileUrl = ItsData.GetScalar(ItsMaria.Query(query.ToString()));
            return fileUrl;
        }

        public object ConvertBack(object fileUrl, Type targetType, object parameter, CultureInfo culture)
        {
            return _FileKey;
        }
    }

    public class CvtToDate : IValueConverter
    {
        private string _String = "";
        public object Convert(object obj, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                _String = DateTime.Parse(obj.ToString()).ToString("yyyy-MM-dd");
            }
            catch
            {
                _String = "";
            }
            return _String;
        }

        public object ConvertBack(object obj, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                _String = DateTime.Parse(obj.ToString()).ToString("yyyy-MM-dd");
            }
            catch
            {
                _String = "";
            }
            return _String;
        }
    }

    public class CvtToString : IValueConverter
    {
        private string _String = "";
        public object Convert(object obj, Type targetType, object parameter, CultureInfo culture)
        {
            _String = obj.ToString();
            return _String;
        }

        public object ConvertBack(object fileUrl, Type targetType, object parameter, CultureInfo culture)
        {
            return _String;
        }
    }
}