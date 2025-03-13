using Film.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        public async Task AddAsync(Film.Film film)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Film.Film film)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Film.Film>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Film.Film> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Film.Film film)
        {
            throw new NotImplementedException();
        }
    }
}
