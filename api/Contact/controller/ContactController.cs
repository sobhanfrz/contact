using Contact.business;
using Contact.model;
using Contact.model.table;
using Microsoft.AspNetCore.Mvc;

namespace Contact.controller
{
    [ApiController]
    public class ContactController
    {
        private ContactBusiness busssiness;

        public ContactController()
        {

            busssiness = new ContactBusiness();
        }
        [HttpGet("phonetypes")]
        public BusinessResult<IEnumerable<phonetypetable>> getphonetypes()
        {
            return busssiness.getphonetypes();
        }
    }
}
