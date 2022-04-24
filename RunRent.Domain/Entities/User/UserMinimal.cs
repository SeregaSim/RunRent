using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunRent.Domain.Enums;

namespace RunRent.Domain.Entities.User
{
    public class UserMinimal
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public URole Role { get; set; }
    }
}
