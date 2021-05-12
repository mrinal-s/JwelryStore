namespace jewelrystoreAPI
{
    /// <summary>
    /// IUserBusinessLogic
    /// </summary>
    public interface IUserBusinessLogic
    {
        //signature defined for print and get user data
        JwelleryCost GetUser(User user);
        bool PrintUser(JwelleryCost jwl);      
        
    }
}
