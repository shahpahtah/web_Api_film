namespace Data
{
    public class FilmDb
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string PosterPath { get; set; }

        public Guid UserId { get; set; }  
        public UserDb User { get; set; }
    }
}