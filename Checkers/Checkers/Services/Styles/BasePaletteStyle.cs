using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Checkers.Services.Styles
{
    public class BasePaletteStyle : IStyle
    {
        private readonly System.Windows.Media.Color _backWindowColor = System.Windows.Media.Color.FromArgb(255, 255, 186, 78);
        private readonly System.Windows.Media.Color _foreNameColor = System.Windows.Media.Color.FromArgb(255, 71, 0, 71);
        private readonly System.Windows.Media.Color _foreSubNameColor = System.Windows.Media.Color.FromArgb(255, 160, 43, 104);
        private readonly System.Windows.Media.Color _backButtonColor = System.Windows.Media.Color.FromArgb(255, 249, 113, 52);
        private readonly System.Windows.Media.Color _foreButtonColor = System.Windows.Media.Color.FromArgb(255, 111, 11, 91);

        public Style Style { get; set; } = Style.Base;

        public void ChangeButtonStyle(Button button)
        {
            button.Foreground = new SolidColorBrush(_foreButtonColor);
            button.Background = new SolidColorBrush(_backButtonColor);
        }

        public void ChangeWindowStyle(Window window)
        {
            window.Foreground = new SolidColorBrush(_foreNameColor);
            window.Background = new SolidColorBrush(_backWindowColor);
        }

        public void ChangeGridStyle(Grid grid)
        {
            grid.Background = new SolidColorBrush(_backWindowColor);
        }

        public void ChangeNameStyle(TextBlock textBlock)
        {
            textBlock.Foreground = new SolidColorBrush(_foreNameColor);
        }

        public void ChangeSubNameStyle(TextBlock textBlock)
        {
            textBlock.Foreground = new SolidColorBrush(_foreSubNameColor);
        }
    }
}