using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Checkers.Services.Styles
{
    public class PacificPaletteStyle : IStyle
    {
        private readonly System.Windows.Media.Color _backWindowColor = System.Windows.Media.Color.FromArgb(255, 238, 238, 238);
        private readonly System.Windows.Media.Color _foreWindowColor = System.Windows.Media.Color.FromArgb(255, 34, 40, 49);
        private readonly System.Windows.Media.Color _backButtonColor = System.Windows.Media.Color.FromArgb(255, 0, 173, 181);
        private readonly System.Windows.Media.Color _foreButtonColor = System.Windows.Media.Color.FromArgb(255, 57, 62, 70);

        public Style Style { get; set; } = Style.Pacific;

        public void ChangeButtonStyle(Button button)
        {
            button.Foreground = new SolidColorBrush(_foreButtonColor);
            button.Background = new SolidColorBrush(_backButtonColor);
            button.BorderBrush = new SolidColorBrush(_foreWindowColor);
        }

        public void ChangeWindowStyle(Window window)
        {
            window.Foreground = new SolidColorBrush(_foreWindowColor);
            window.Background = new SolidColorBrush(_backWindowColor);
        }

        public void ChangeGridStyle(Grid grid)
        {
            grid.Background = new SolidColorBrush(_backWindowColor);
        }

        public void ChangeNameStyle(TextBlock textBlock)
        {
            textBlock.Foreground = new SolidColorBrush(_foreWindowColor);
        }

        public void ChangeSubNameStyle(TextBlock textBlock)
        {
            textBlock.Foreground = new SolidColorBrush(_foreButtonColor);
        }
    }
}