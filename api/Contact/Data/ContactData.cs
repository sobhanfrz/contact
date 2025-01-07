using Contact.model;
using Contact.model.table;
using Contact.utility;
using Microsoft.Data.SqlClient;

namespace Contact.Data
{
    public class ContactData
    {
        private SqlConnection connection;
        private crud crud;
        public ContactData()
        {

            string connectionstring = "Data Source=.;Database=contacts;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
             connection = new(connectionstring);
            crud = new(connection);

        }

        public IEnumerable<phonetypetable> getphonetypes()
        {
            return this.crud.select<phonetypetable>();

        }

    }
}
