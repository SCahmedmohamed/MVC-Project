using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        public int id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
