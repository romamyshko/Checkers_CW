using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Checkers.Models;
using Checkers.ViewModels;

namespace Checkers.Views
{
    /// <summary>
    /// Interaction logic for GameWithAIWindow.xaml
    /// </summary>
    public partial class GameWithAIWindow : Window
    {
        public GameWithAIWindow()
        {
            InitializeComponent();
            DataContext = new GameWithAIViewModel(new GameWithAIModel() { View = this});
        }
    }
}
