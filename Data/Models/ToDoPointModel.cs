using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ToDoPointModel
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public string ToDo { get; set; }
        public string Status { get; set; }
    }
}
