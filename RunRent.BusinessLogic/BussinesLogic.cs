using RunRent.BusinessLogic.Interface;

namespace RunRent.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
    }
}
