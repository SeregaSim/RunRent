using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RunRent.BusinessLogic;
using RunRent.BusinessLogic.Interface;
using RunRent.Domain.Entities.User;
using RunRent.Models;
using RunRent.BusinessLogic.Core;



namespace RunRent.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        private readonly UserApi _userApi;
        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
            _userApi = new UserApi();
        }

        // GET: Login
        public ActionResult Register ()
        {
            UDbTable newUser = new UDbTable();
            return View(newUser);
           
        }
        // POST: Login/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UDbTable user)
        {
            if (ModelState.IsValid)
            {
                _userApi.UserRegister(user);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                //Mapper.Initialize(cfg => cfg.CreateMap<UserLogin, ULoginData>());
                //var data = Mapper.Map<ULoginData>(login);

                var data = new ULoginData();
                data.Password = login.Password;
                data.Credential = login.Credential;

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
            }

            return View();
        }
    }
}