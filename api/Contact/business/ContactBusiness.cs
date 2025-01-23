using Contact.Data;
using Contact.model;
using Contact.model.table;

namespace Contact.business
{
    public class ContactBusiness
    {
        private ContactData data;
        public ContactBusiness(ContactData contactData) { 
        this.data = contactData;
        }
        public BusinessResult<IEnumerable<phonetypetable>> getphonetypes()
        {
BusinessResult<IEnumerable<phonetypetable>> result = new ();
result.Success = true;
            result.Data=this.data.getphonetypes();
            return result;



        }
    }
}
