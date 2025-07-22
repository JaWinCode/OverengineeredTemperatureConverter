using System.Windows;
using System.Windows.Input;

namespace Converter.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TopBar_DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}