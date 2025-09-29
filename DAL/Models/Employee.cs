using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee : BaseEntity
    {

      
        public string Address { get; set; }
        public int Salary { get; set; }


    }
}
