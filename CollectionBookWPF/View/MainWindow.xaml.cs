using CollectionBookWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace CollectionBookWPF.View
{
    public partial class MainWindow : Window
    {
        public static ListView All_Books;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerViewModel();
            All_Books = ViewAllBooks;
        }
    }
}
