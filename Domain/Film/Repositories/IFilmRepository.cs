using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Repositories
{
    public interface IFilmRepository
    {
        Task<Film> GetByIdAsync(Guid id);
        Task<IEnumerable<Film>> GetAllAsync();
        Task AddAsync(Film film);
        Task UpdateAsync(Film film);
        Task DeleteAsync(Film film);
    }
}
