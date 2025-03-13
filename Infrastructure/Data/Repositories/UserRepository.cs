using AutoMapper;
using Film;
using Film.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FilmContext _context;
        private readonly IMapper _mapper;
        public UserRepository(FilmContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
