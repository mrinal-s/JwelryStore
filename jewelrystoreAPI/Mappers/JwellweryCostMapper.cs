using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jewelrystoreAPI.Mappers
{
    public static class JwellweryCostMapper
    {
        public static JwelleryCost  MapToJwelleryCost(User user)
        {           
            if(user !=null)
            {
                JwelleryCost obj = new JwelleryCost();
                obj.User = new User();
                obj.User.IsPriviledgedUser = user.IsPriviledgedUser;
                obj.User.Password = user.Password;
                obj.User.UserId = user.UserId;
                obj.User.UserName = user.UserName;
                if(user.IsPriviledgedUser)
                {
                    obj.Discount = 2;
                }
                return obj;
            }

            return null;
        }
      
    }
}
