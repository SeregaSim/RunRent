using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunRent.Domain.Entities;
using RunRent.Domain.Entities.User;

namespace RunRent.Domain.Interfaces
{
    public interface IUserWithoutID
    {
        IEnumerable<Session> GetAllUsers();
        Session GetUserById(int id);
    }

}
