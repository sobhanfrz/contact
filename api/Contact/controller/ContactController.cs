using Contact.business;
using Contact.model;
using Contact.model.table;
using Microsoft.AspNetCore.Mvc;

namespace Contact.controller
{
    [ApiController]
    [Route("contact")]
    public class ContactController
    {
        private ContactBusiness busssiness;

        public ContactController(ContactBusiness contactBusiness)
        {

          busssiness= contactBusiness;
        }
        [HttpGet("phonetypes")]
        public BusinessResult<IEnumerable<phonetypetable>> getphonetypes()
        {
            return busssiness.getphonetypes();
        }
    }
}
