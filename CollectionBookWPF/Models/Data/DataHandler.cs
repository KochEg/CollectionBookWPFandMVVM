using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using CollectionBookWPF.Models.Entity;
using CollectionBookWPF.View;

namespace CollectionBookWPF.Models.Data
{
    public static class DataHandler
    {
        // добавить книгу
        public static string Create_Book(string name, string author, EGenre genre, int year_of_publishing)
        {
            string result = "Такой объект уже существует";

            using (ApplicationContext db = new ApplicationContext())
            {
                // проверяем существует ли книга
                bool check_is_exist = db.Books.Any(element => element.Name == name);
                if (!check_is_exist)
                {
                    Book new_book = new Book
                    {
                        Name = name,
                        Author = author,
                        Genre = genre,
                        Year_Of_Publishing = year_of_publishing
                    };
                    db.Books.Add(new_book);
                    db.SaveChanges();
                    result = "Объект добавлен!";
                }
                return result;
            }
        }

        // удалить книгу
        public static string Delete_Book(Book book)
        {
            string result = "Такой объект не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
                result = "Объект " + book.Name + " удалён!";
            }
            return result;
        }

        // редактировать книгу
        public static string Edit_Book(Book old_book, string name, string author, EGenre genre, int year_of_publishing)
        {
            string result = "Такой объект не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Book book = db.Books.FirstOrDefault(d => d.Id == old_book.Id);
                if (book != null)
                {
                    book.Name = name;
                    book.Author = author;
                    book.Genre = genre;
                    book.Year_Of_Publishing = year_of_publishing;
                    db.SaveChanges();
                    result = "Объект " + book.Name + " изменён!";
                }
            }
            return result;
        }

        // вернуть все книги
        public static List<Book> Get_All_Books()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Books.ToList();
                return result;
            }
        }

        // сортировка по году издания
        public static List<Book> Get_All_Books_Sort_Year()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Books.ToList();
                result.Sort(delegate (Book x, Book y)
                {
                    if (x == null && y == null) return 0;
                    else if (x == null) return -1;
                    else if (y == null) return 1;
                    else
                        return x.Year_Of_Publishing.CompareTo(y.Year_Of_Publishing);
                });
                return result;
            }
        }     
    }
}
