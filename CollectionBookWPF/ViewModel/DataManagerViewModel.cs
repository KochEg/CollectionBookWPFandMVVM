using CollectionBookWPF.Models.Command;
using CollectionBookWPF.Models.Data;
using CollectionBookWPF.Models.Entity;
using CollectionBookWPF.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;


namespace CollectionBookWPF.ViewModel
{
    class DataManagerViewModel : INotifyPropertyChanged
    {
        #region CONSTRUCTS
        public DataManagerViewModel() { }

        public DataManagerViewModel(Book book)
        {
            if (book != null)
                Selected_Book = book;
        }
        #endregion


        #region PROPERTIES
        // все книги
        private List<Book> _All_Books = DataHandler.Get_All_Books();
        public List<Book> All_Books
        {
            get 
            {  return _All_Books; }
            set
            {
                _All_Books = value;
                NotityPropertyChanged("All_Books");
            }
        }
        // вводимые данные
        public string Book_Name { get; set; }
        public string Author { get; set; }
        public EGenre Genre { get; set; }
        public int Year_Of_Publishing { get; set; }

        // свойства для выделенных элементов
        public Book Selected_Book { get; set; }

        // combobox добавления и редактирования
        private List<string> _Com_Box = new List<string>() { "", "Ужасы", "Приключения", "Роман", "Фантастика", "Фентези" };
        public List<string> Com_Box { get { return _Com_Box; } }

        // Combobox поиска автора
        private List<string> _Find_Author_Combobox = new List<string>();
        public List<string> Find_Author_Combobox
        { get
            {
                foreach (var v in _All_Books)
                    _Find_Author_Combobox.Add(v.Author);
                return _Find_Author_Combobox;
            }
            set { Find_Author_Combobox = value; }
        }
        #endregion


        #region SORT COMMAND
        private CommandHandler _Sort_Year; 
        public CommandHandler Sort_Year
        {
            get
            {
                return _Sort_Year ?? new CommandHandler(obj =>
                {
                    All_Books = DataHandler.Get_All_Books_Sort_Year();
                    MainWindow.All_Books.ItemsSource = All_Books;
                    Show_Message_To_User("Сортировка прошла");
                });
            }
        }
        #endregion


        #region ADD COMMANDS
        private CommandHandler _Open_Add_New_Book;
        public CommandHandler Open_Add_New_Book
        {
            get
            {
                return _Open_Add_New_Book ?? new CommandHandler(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    Entity_Processing(wnd, resultStr, true);
                });
            }
        }
        #endregion


        #region EDIT COMMANDS
        private CommandHandler _Edit_Book;

        public CommandHandler Edit_Book
        {
            get
            {
                return _Edit_Book ?? new CommandHandler(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "Не выбран объект";
                    if (Selected_Book != null)
                        Entity_Processing(wnd, resultStr, false);

                    if (Selected_Book == null)
                        Show_Message_To_User(resultStr);

                });
            }
        }
        #endregion


        #region OPEN WINDOW COMMANDS
        private CommandHandler _Open_Add_New_Book_Wnd;
        public CommandHandler Open_Add_New_Book_Wnd
        {
            get
            {
                return _Open_Add_New_Book_Wnd ?? new CommandHandler(obj => Open_Add_New_Book_Window());
            }
        }

        private CommandHandler _Open_Edit_Book_Wnd;
        public CommandHandler Open_Edit_Book_Wnd
        {
            get
            {
                return _Open_Edit_Book_Wnd ?? new CommandHandler(obj => Open_Edit_Book_Window(Selected_Book));
            }
        }
        #endregion


        #region OPEN WINDOWS METHODS
        // открытие окон
        private void Open_Add_New_Book_Window()
        {
            AddNewBook new_book = new AddNewBook();
            Set_Center_Position_AndOpen(new_book);
        }
        private void Open_Edit_Book_Window(Book book)
        {
            if (book != null)
            {
                EditBook new_book = new EditBook(book);
                Set_Center_Position_AndOpen(new_book);
            }
            else
                Show_Message_To_User("Обект не выбран");
        }

        private void Show_Message_To_User(string message)
        {
            MessageView message_view = new MessageView(message);
            Set_Center_Position_AndOpen(message_view);
        }

        private void Set_Center_Position_AndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion


        #region DELETE COMMANDS
        private CommandHandler _Delete_Item;

        public CommandHandler Delete_Item
        {
            get
            {
                return _Delete_Item ?? new CommandHandler(obj =>
                {
                    string result = "Объект не выбран";
                    if (Selected_Book != null)
                    {
                        result = DataHandler.Delete_Book(Selected_Book);
                        Update_All_Books_View();
                    }

                    //обновление 
                    Set_Null_Value_Properties();
                    Show_Message_To_User(result);
                }

            );
            }

        }

        #endregion


        #region SUPPORT METHODS

        private void Entity_Processing(Window wnd, string message, bool is_create)
        {
           

            if (Book_Name == null || Book_Name.Replace(" ", "").Length == 0)
                Show_Message_To_User("Не верно указано название книги");

            else if (Author == null || Author.Replace(" ", "").Length == 0)
                    Show_Message_To_User("Не верно указан автор");

            else if (Year_Of_Publishing < 1850 || Year_Of_Publishing > 2024)
                Show_Message_To_User("Указан не верный год издания");

            else if (Genre == EGenre.EG_None)
                Show_Message_To_User("Не указан жанр");
            else
            {
                if (is_create)
                    message = DataHandler.Create_Book(Book_Name, Author, Genre, Year_Of_Publishing);
                else
                    message = DataHandler.Edit_Book(Selected_Book, Book_Name, Author, Genre, Year_Of_Publishing);

                Update_All_Books_View();
                Show_Message_To_User(message);
                Set_Null_Value_Properties();
                wnd.Close();
            }
        }

        private void Set_Null_Value_Properties()
        {
            Book_Name = null;
            Author = null;
            Genre = EGenre.EG_None;
            Year_Of_Publishing = 0;
        }

        private void Update_All_Data_View()
        {
            Update_All_Books_View();
        }

        private void Update_All_Books_View()
        {
            All_Books = DataHandler.Get_All_Books();
            MainWindow.All_Books.ItemsSource = null;
            MainWindow.All_Books.Items.Clear();
            MainWindow.All_Books.ItemsSource = All_Books;
            MainWindow.All_Books.Items.Refresh();
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotityPropertyChanged(string property_name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property_name));
            }
        }
        #endregion
    }
}
