using Contact.Data;
using Contact.model;
using Contact.model.table;

namespace Contact.business
{
    public class ContactBusiness
    {
        private ContactData data;
        public ContactBusiness() { 
        this.data = new ContactData();
        }
        public BusinessResult<IEnumerable<phonetypetable>> getphonetypes()
        {
BusinessResult<IEnumerable<phonetypetable>> result = new ();
result.Success = true;
            result.Data=data.getphonetypes();
            return result;



        }
    }
}
