using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film
{
    public class User
    {
        public Guid Id { get;}
        public string Email { get; private set; }
        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        private readonly List<Film> _films = new List<Film>();
        public IReadOnlyCollection<Film> Films => _films.AsReadOnly();
        internal User(Guid id, string email, string firstName, string lastName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
        public static User Create(Guid id, string email, string firstName, string lastName)
        {
            return new User(id, email, firstName, lastName);
        }
        public void UpdateName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Имя не может быть пустым.");
            }
            FirstName = firstName;
            LastName = lastName;
        }
        public void AddFilm(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }
            if (film.UserId != Id)
            {
                throw new ArgumentException("Этот фильм не принадлежит пользователю.");
            }
            _films.Add(film);
        }
        public void RemoveFilm(Film film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }
            _films.Remove(film);
        }
    }
}
