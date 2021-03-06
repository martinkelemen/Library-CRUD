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

namespace MyLibrary.WpfClient
{
    /// <summary>
    /// Interaction logic for BookEditorWindow.xaml
    /// </summary>
    public partial class BookEditorWindow : Window
    {
        public BookEditorWindow()
        {
            InitializeComponent();
            bookwvm.invalidInput += (sender, eventargs) => MessageBox.Show((eventargs as InvalidInputEventArgs).Message, (eventargs as InvalidInputEventArgs).Caption, MessageBoxButton.OK);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
