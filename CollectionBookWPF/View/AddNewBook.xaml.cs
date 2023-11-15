using CollectionBookWPF.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace CollectionBookWPF.View
{
    public partial class AddNewBook : Window
    {
        public AddNewBook()
        {
            InitializeComponent();
            DataContext = new DataManagerViewModel();
        }

        private void Autor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Za-zА-Яа-я.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Year_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
