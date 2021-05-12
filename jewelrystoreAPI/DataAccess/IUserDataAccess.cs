using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jewelrystoreAPI
{
    public interface IUserDataAccess
    {
        User GetUserData(User user);
       
    }
}
