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
        public ContactData(SqlConnection connection ,crud crud)
        {
            this.connection = connection;
            this.crud = crud;

        }

        public IEnumerable<phonetypetable> getphonetypes()
        {
            return this.crud.select<phonetypetable>();

        }

    }
}
