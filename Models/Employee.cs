using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_NET_Core_Web_API_Dapper.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string CITY { get; set; }
        public string DEPARTMENT { get; set; }
        public string GENDER { get; set; }
        public string ACTIVE_STATUS { get; set; }
    }
}
