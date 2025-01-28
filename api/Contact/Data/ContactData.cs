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
        public void AddContactData(contacttable contact)
        {
            this.crud.insert(contact);
        }
        public IEnumerable<contacttable> getcontactdata(int userid)
        {

            return this.crud.select<contacttable>();
        }
        //هم میگذاریم که چک کنیم آیا این userid
        //مربوط به همین یوزر ای دی باشد  id
        public void removecontactdata(int contactid,int userid)
        {
            this.crud.deletebyid<contacttable>(contactid);
        }


    }
}
