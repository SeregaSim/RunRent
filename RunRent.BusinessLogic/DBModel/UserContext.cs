using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunRent.Domain.Entities.User;



    namespace RunRent.BusinessLogic.DBModel
    {
        class UserContext : DbContext
        {
            public UserContext() :
                base("name=RunRent") // connectionstring name define in your web.config
            {
            }

            public virtual DbSet<UDbTable> Users { get; set; }


        }

    }

