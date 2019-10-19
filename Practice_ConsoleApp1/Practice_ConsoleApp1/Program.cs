using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Practice_ClassLibrary1;

namespace Practice_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWorker fileworker = new FileWorker();
            var ls = fileworker.readSalary().ToList();

            var lw = fileworker.readWorkers().ToList();

            var sal =new XElement("Salaries", ls.Select(x => new XElement("Salary",
                            new XAttribute("idCode", x.idCode),
                             new XAttribute("Salary1", x.Salary1),
                              new XAttribute("Salary2", x.Salary2))));

            sal.Save("SalaryXML.xml");

            var wor = new XElement("Workers", lw.Select(x => new XElement("Worker",
                           new XAttribute("idCode", x.idCode),
                            new XAttribute("Name", x.Name),
                            new XAttribute("Education", x.Education),
                            new XAttribute("Specialty", x.Specialty),
                             new XAttribute("Year", x.Year))));

            wor.Save("WorkerXML.xml");

            var names = from nm in lw
                        where nm.Year < (2019 - 35)
                        select nm.Name;
            lw.Clear();
            foreach (string s in names)

                Console.WriteLine();

            var maxSalary = (from ms in ls
                             select ms.Salary2).Max();
            Console.WriteLine(maxSalary);

            //var result = from w in lw
            //             from sl in ls
            //             let avg = (from s in ls
            //                        select (s.Salary1 + s.Salary2)).Average()
            //             where ((sl.Salary1 + sl.Salary2) < avg) && (w.idCode == sl.idCode)
            //             select w.Name + " - " + w.Specialty;
            lw.Where(w =>
                ls.All(sl =>
                    sl.idCode == w.idCode &&
                    sl.Salary1 + sl.Salary2 < ls.Average(s => s.Salary1 + s.Salary2)))
               .Select(w => w.Name + " - " + w.Specialty);

        }
    }
    
}
