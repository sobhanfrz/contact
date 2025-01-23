using Contact.model;
using Contact.model.table;
using Contact.utility;
using Microsoft.Data.SqlClient;

namespace Contact.Data
{
    public class ContactData
    {
        private SqlConnection connection;
        private Crud crud;
        public ContactData(SqlConnection connection ,Crud crud)
        {
            this.connection = connection;
            this.crud = crud;

        }

        public IEnumerable<PhonetypeTable> getphonetypes()
        {
            return this.crud.select<PhonetypeTable>();

        }

    }
}
