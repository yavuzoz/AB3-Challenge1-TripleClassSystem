using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data.Models
{
    public class Kurs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DozentID { get; set; }
    }
}
