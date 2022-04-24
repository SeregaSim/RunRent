using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RunRent.Domain.Entities.User;

namespace RunRent.BusinessLogic.Interface
{
    public  class IUser
    {
        public interface IUserService
        {
            ULoginResp UserLogin(ULoginData userData);

            HttpCookie Cookie(string loginCredential);

            UserMinimal UserCookie(string cookie);

            void UserRegister(UDbTable user);

            IEnumerable<UDbTable> GetAllUsers();
            UDbTable GetUserById(int id);
        }
    }
}
