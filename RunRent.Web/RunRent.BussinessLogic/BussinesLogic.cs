
using RunRent.BussinessLogic.Interface;
using System;

namespace RunRent.BussinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
