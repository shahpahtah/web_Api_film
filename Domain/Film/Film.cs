namespace Film
{
    public class Film
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }
        public string Director { get; private set; }
        public string PosterPath { get; private set; }
        public Guid UserId { get; private set; }

        // Конструктор (только для внутреннего использования)
        internal Film(Guid id, string title, string description, int year, string director, string posterPath, Guid userId)
        {
            Id = id;
            Title = title;
            Description = description;
            Year = year;
            Director = director;
            PosterPath = posterPath;
            UserId = userId;
        }

        // Метод Create (вместо конструктора)
        public static Film Create(Guid id, string title, string description, int year, string director, string posterPath, Guid userId)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("ID фильма не может быть пустым.");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название не может быть пустым.");
            }

            if (year < 1888) // Первый фильм
            {
                throw new ArgumentException("Год не может быть меньше 1888.");
            }

            //  Дополнительная валидация может быть добавлена здесь

            return new Film(id, title, description, year, director, posterPath, userId);
        }

        public void UpdateDetails(string title, string description, int year, string director, string posterPath)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название не может быть пустым.");
            }
            Title = title;
            Description = description;
            Year = year;
            Director = director;
            PosterPath = posterPath;
        }
    }
}

