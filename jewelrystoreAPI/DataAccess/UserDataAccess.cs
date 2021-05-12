using jewelrystoreAPI.Database;
using System;
using System.Linq;

namespace jewelrystoreAPI
{
    public class UserDataAccess : IUserDataAccess
    {
        #region Constructor
        private readonly JwelleryDbContext _context;
        public UserDataAccess(JwelleryDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserData(User user)
        {
            try
            {
                if (user != null)
                {
                    var getUserDetails = _context.UserData.Where(x => x.UserName == user.UserName && x.Password == user.Password);
                    return getUserDetails.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          

            return user;
        }
        #endregion

    }
}
