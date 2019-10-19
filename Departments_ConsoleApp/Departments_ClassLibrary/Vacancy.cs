using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_ClassLibrary
{
    public class Vacancy
    {
        public string Name { get; set; }

        public bool IsOpen { set; get; }

        public Department Department { get; set; }
    }
}
