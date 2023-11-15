using System.Windows;


namespace CollectionBookWPF.View
{
    /// <summary>
    /// Логика взаимодействия для MessageView.xaml
    /// </summary>
    public partial class MessageView : Window
    {
        public MessageView(string text)
        {
            InitializeComponent();
            MessageTextView.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
