using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Converter.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowVM();
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

        private void Clear_Focus(object sender, MouseButtonEventArgs e)
        {
            var src = e.OriginalSource as DependencyObject;
            if (src is null)
            {
                Keyboard.ClearFocus();
                return;
            }

            if (!IsWithinControl<TextBox>(src) &&
                !IsWithinControl<ComboBox>(src) &&
                !IsWithinControl<ComboBoxItem>(src))
            {
                Keyboard.ClearFocus();
            }
        }

        private static bool IsWithinControl<T>(DependencyObject element) where T : DependencyObject
        {
            while (element != null)
            {
                if (element is T)
                {
                    return true;
                }
                element = VisualTreeHelper.GetParent(element);
            }

            return false;
        }
    }
}