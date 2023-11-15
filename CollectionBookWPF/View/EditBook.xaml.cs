using CollectionBookWPF.Models.Entity;
using CollectionBookWPF.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace CollectionBookWPF.View
{
    public partial class EditBook : Window
    {
        public EditBook(Book book)
        {
            Book Book_Buffer = book as Book;
            InitializeComponent();
            DataContext = new DataManagerViewModel(Book_Buffer);
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
