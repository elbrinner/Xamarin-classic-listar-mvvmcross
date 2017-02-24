using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Visibility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic.Core.Converters
{ 
    public class VisibilityConverter : MvxBaseVisibilityValueConverter<bool>
    {
        /// <summary>
        /// Cambia la visibilidad en funcion del valor del bool pasado.
        /// </summary>
        /// <param name="value">bool, true o false.</param>
        /// <param name="parameter">bool: Si es true actúa de forma normal. Si es false, invierte las salidas.</param>
        /// <param name="culture">La cultura de la vista</param>
        /// <returns>Devuelve visible o collapsed</returns>
        protected override MvxVisibility Convert(bool value, object parameter, CultureInfo culture)
        {
            if ((value && (bool)parameter) ||
                (value && !(bool)parameter))
            {
                return MvxVisibility.Visible;
            }

            return MvxVisibility.Collapsed;
        }
    }
}
