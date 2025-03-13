using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class UserDb:IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<FilmDb> Films { get; set; } = new List<FilmDb>();
    }
}
