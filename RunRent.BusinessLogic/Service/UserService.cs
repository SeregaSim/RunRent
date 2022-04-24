using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RunRent.BusinessLogic.Interface;
using RunRent.Domain.Entities.User;
using RunRent.Helpers;
using RunRent.Domain.DBModel;
using RunRent.Domain.Interfaces;


namespace BusinessLogic.Service
{
    public class UserService : IUser
    {
        public IUserRep _userRepository;

        public UserService(IUserRep userRepository)
        {
            this._userRepository = userRepository;
        }

        public ULoginResp UserLogin(ULoginData userData)
        {
            UDbTable result;

            var validate = new EmailAddressAttribute();
            if (validate.IsValid(userData.Credential))
            {
                var password = LoginHelper.HashGen(userData.Password);
                using (var db = new RunRentDBContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == userData.Credential && u.Password == userData.Password);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new RunRentDBContext())
                {
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
            else
            {
                var password = LoginHelper.HashGen(userData.Password);
                using (var db = new RunRentDBContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == userData.Credential && u.Password == password);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new RunRentDBContext())
                {
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
        }

        public HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new RunRentDBContext())
            {
                Session current;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    current = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    current = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (current != null)
                {
                    current.CookieString = apiCookie.Value;
                    current.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new RunRentDBContext())
                    {
                        todo.Entry(current).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        public UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable currentUser;

            using (var db = new RunRentDBContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new RunRentDBContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    currentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    currentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (currentUser == null) return null;


            var userMinimal = new UserMinimal();

            userMinimal.Username = currentUser.Username;
            userMinimal.Email = currentUser.Email;
            userMinimal.Role = currentUser.Role;

            return userMinimal;
        }

        public void UserRegister(UDbTable user)
        {
            var foundUser = new UDbTable();
            using (var db = new RunRentDBContext())
            {
                foundUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
            }


            var password = LoginHelper.HashGen(user.Password);
            user.Password = password;

            if (foundUser == null)
            {
                using (var db = new RunRentDBContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public IEnumerable<UDbTable> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UDbTable GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
