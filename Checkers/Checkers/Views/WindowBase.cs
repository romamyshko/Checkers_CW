using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Checkers.Services.Styles;

namespace Checkers.Views
{
    public class WindowBase : Window
    {
        public IStyle Style { get; set; }
    }
}
