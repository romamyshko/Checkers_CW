using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Checkers.Services.Styles
{
    public class GreenPaletteStyle : IStyle
    {
        private readonly System.Windows.Media.Color _backWindowColor = System.Windows.Media.Color.FromArgb(255, 193, 248, 207);
        private readonly System.Windows.Media.Color _foreWindowColor = System.Windows.Media.Color.FromArgb(255, 72, 143, 177);
        private readonly System.Windows.Media.Color _backButtonColor = System.Windows.Media.Color.FromArgb(255, 79, 211, 196);
        private readonly System.Windows.Media.Color _foreButtonColor = System.Windows.Media.Color.FromArgb(255, 83, 62, 133);

        public Style Style { get; set; } = Style.Green;

        public void ChangeButtonStyle(Button button)
        {
            button.Foreground = new SolidColorBrush(_foreButtonColor);
            button.Background = new SolidColorBrush(_backButtonColor);
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