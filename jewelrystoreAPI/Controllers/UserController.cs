using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jewelrystoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Constructor
        IUserBusinessLogic _userBusinessLogic;
        public UserController(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }
        #endregion

        #region Fetch user Details

        [HttpPost]
        public async Task<ActionResult<JwelleryCost>> LoginUser(User user)
        {
            return _userBusinessLogic.GetUser(user);
        }
        #endregion

        #region PrintData in file or pdf
        //note:*Here if we get IsFilePrint is false then we go for pdf print otherwise if its true we go for .txt file write input condition is kept on front side
        [Route("print")]
        [HttpPost]
        public async Task<ActionResult<bool>> PrintUser(JwelleryCost jwl)
        {
            return _userBusinessLogic.PrintUser(jwl);
        }
        #endregion

    }
}
