using System.Configuration;

namespace ADO.BL.Services
{
    public class SwimStyleService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    }
}
