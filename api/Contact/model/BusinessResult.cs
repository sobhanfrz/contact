using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.model
{
    public class BusinessResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public int Errorcode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
