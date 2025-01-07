using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    [ApiController]
    public class HomeController
    {
        [HttpGet("time")]
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }

    }
}
