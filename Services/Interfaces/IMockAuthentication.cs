using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLSecurity.Services.Interfaces
{
    interface IMockAuthentication
    {
        public bool CheckAuth(string email, string token);
    }
}
