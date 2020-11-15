using MessagingApi.Entities;
using MessagingApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Services
{
    public class TokenService : ITokenService
    {
        private DataContext _context;

        public TokenService(DataContext context)
        {
            _context = context;
        }
        public void Save(Token token)
        {
            _context.Tokens.Add(token);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var token = _context.Tokens.Find(id);
            if(token != null)
            {
                _context.Tokens.Remove(token);
                _context.SaveChanges();
            }
        }
    }
}
