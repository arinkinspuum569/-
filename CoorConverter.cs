using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace разбор_анимации
{
    public class CoorConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) // метод является реализацией интерфейса IValueConverter.Convert()
            //Он принимает следующие параметры:
   //- value: входное значение, которое нужно преобразовать.
  // - targetType: тип, в который нужно преобразовать входное значение.
   //- parameter: дополнительный параметр, который может быть использован для настройки преобразования.
  // - culture: информация о культурных настройках, которая может быть использована для форматирования.
        {
            int ang = (int)value; //Входное значение value преобразуется в целочисленное значение ang.
            int x = (int)Math.Cos(ang) + 200;
            int y = (int)Math.Sin(ang) + 200;


            return string.Format("{0}, {1} {2}, {3} {4}, {5}", x + 100, y + 100, x + 110, y + 110, x - 90, y + 110); //Возвращается строковое представление координат в формате "x1, y1 x2, y2 x3, y3", где x1, y1, x2, y2, x3, y3 - вычисленные ранее координаты с дополнительными смещениями.
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

//Этот метод является реализацией интерфейса IValueConverter.ConvertBack().
//Однако, в данном случае он просто выбрасывает исключение NotImplementedException, так как обратное преобразование не реализовано.