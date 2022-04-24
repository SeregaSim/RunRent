//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using RunRent.BusinessLogic.Interface;
//using RunRent.Domain.Entities.User;
//using RunRent.Helpers;
//using RunRent.Domain.DBModel;
//using RunRent.Domain.Interfaces;

//namespace RunRent.BusinessLogic.Service
//{
//    class UserServiceWithoutID:IUser
//    {
//        public IUserRep _userRepository;

//        public UserServiceWithoutID()
//            {
//                this._userRepository = new IUserWithoutID();
//            }

//            public ULoginResp UserLogin(ULoginData userData)
//            {
//                Session result;

//                var validate = new EmailAddressAttribute();
//                if (validate.IsValid(userData.Credential))
//                {
//                    var password = LoginHelper.HashGen(userData.Password);
//                    using (var db = new RunRentDBContext())
//                    {
//                        result = db.Sessions.FirstOrDefault();
//                    }

//                    if (result == null)
//                    {
//                        return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
//                    }

//                    using (var todo = new RunRentDBContext())
//                    {
//                        todo.Entry(result).State = EntityState.Modified;
//                        todo.SaveChanges();
//                    }

//                    return new ULoginResp { Status = true };
//                }
//                else
//                {
//                    var password = LoginHelper.HashGen(userData.Password);
//                    using (var db = new RunRentDBContext())
//                    {
//                        result = db.Sessions.FirstOrDefault();
//                    }

//                    if (result == null)
//                    {
//                        return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
//                    }

//                    using (var todo = new RunRentDBContext())
//                    {
//                        todo.Entry(result).State = EntityState.Modified;
//                        todo.SaveChanges();
//                    }

//                    return new ULoginResp { Status = true };
//                }
//            }

//            public HttpCookie Cookie(string loginCredential)
//            {
//                var apiCookie = new HttpCookie("X-KEY")
//                {
//                    Value = CookieGenerator.Create(loginCredential)
//                };

//                using (var db = new RunRentDBContext())
//                {
//                    Session current;
//                    var validate = new EmailAddressAttribute();
//                    if (validate.IsValid(loginCredential))
//                    {
//                        current = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
//                    }
//                    else
//                    {
//                        current = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
//                    }

//                    if (current != null)
//                    {
//                        current.CookieString = apiCookie.Value;
//                        current.ExpireTime = DateTime.Now.AddMinutes(60);
//                        using (var todo = new RunRentDBContext())
//                        {
//                            todo.Entry(current).State = EntityState.Modified;
//                            todo.SaveChanges();
//                        }
//                    }
//                    else
//                    {
//                        db.Sessions.Add(new Session
//                        {
//                            Username = loginCredential,
//                            CookieString = apiCookie.Value,
//                            ExpireTime = DateTime.Now.AddMinutes(60)
//                        });
//                        db.SaveChanges();
//                    }
//                }

//                return apiCookie;
//            }

//            public UserMinimal UserCookie(string cookie)
//            {
//                Session session;
//               Session currentUser;

//                using (var db = new RunRentDBContext())
//                {
//                    session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
//                }

//                if (session == null) return null;
//                using (var db = new RunRentDBContext())
//                {
//                    var validate = new EmailAddressAttribute();
//                    if (validate.IsValid(session.Username))
//                    {
//                        currentUser = db.Sessions.FirstOrDefault();
//                    }
//                    else
//                    {
//                        currentUser = db.Sessions.FirstOrDefault(u => u.Username == session.Username);
//                    }
//                }

//                if (currentUser == null) return null;


//                var userMinimal = new UserMinimal();

//                userMinimal.Username = currentUser.Username;
               

//                return userMinimal;
//            }

//            public void UserRegister(Session user)
//            {
//                var foundUser = new Session();
//                using (var db = new MeContext())
//                {
//                    foundUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
//                }


//                var password = LoginHelper.HashGen(user.Password);
//                user.Password = password;

//                if (foundUser == null)
//                {
//                    using (var db = new MegapodDbContext())
//                    {
//                        db.Users.Add(user);
//                        db.SaveChanges();
//                    }
//                }
//                else
//                {
//                    throw new Exception();
//                }
//            }

//            public IEnumerable<User> GetAllUsers()
//            {
//                return _userRepository.GetAllUsers();
//            }

//            public User GetUserById(int id)
//            {
//                return _userRepository.GetUserById(id);
//            }
//        }
//    }
//}

