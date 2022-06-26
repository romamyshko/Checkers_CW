using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Color = System.Drawing.Color;

namespace Checkers.Services.Styles
{
    public interface IStyle
    {
        Style Style { get; set; }
        void ChangeButtonStyle(Button button);
        void ChangeWindowStyle(Window window);
        void ChangeGridStyle(Grid grid);
        void ChangeNameStyle(TextBlock textBlock);
        void ChangeSubNameStyle(TextBlock textBlock);
    }

    public enum Style
    {
        None,
        Base,
        Green,
        Pacific
    }
}
