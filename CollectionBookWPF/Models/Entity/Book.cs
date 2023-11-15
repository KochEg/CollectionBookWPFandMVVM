using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionBookWPF.Models.Entity
{
    public enum EGenre
    {
        EG_None,
        EG_Horror,
        EG_Adventures,
        EG_Novel,
        EG_Fantastic,
        EG_Fantasy
    }
    public class Book 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public EGenre Genre { get; set; }
        public int Year_Of_Publishing { get; set; }

        // Корректное отображение в ListView
        [NotMapped]
        public string Title_Genre
        {
            get
            {
                switch (Genre)
                {
                    case EGenre.EG_Horror:
                        return "Ужасы";

                    case EGenre.EG_Adventures:
                        return "Приключения";

                    case EGenre.EG_Novel:
                        return "Роман";

                    case EGenre.EG_Fantastic:
                        return "Фантастика";

                    case EGenre.EG_Fantasy:
                        return "Фэнтези";

                    default:
                        return "";
                }
            }
        }
    }
}
