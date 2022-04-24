using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunRent.Domain.DBModel;
using RunRent.Domain.Entities;
using RunRent.Domain.Entities.User;
using RunRent.Domain.Interfaces;


namespace RunRent.Domain.Repositories
{
    public class UserRepository : IUserRep
    {
        private readonly RunRentDBContext _db;

        public UserRepository(RunRentDBContext db)
        {
            this._db = db;
        }

        public IEnumerable<UDbTable> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public UDbTable GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
