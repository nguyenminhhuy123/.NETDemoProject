using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.net_core.Static
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        
        public const string User = "User";

        public const string AdminAndUser = User + "," + Admin;
    }
}