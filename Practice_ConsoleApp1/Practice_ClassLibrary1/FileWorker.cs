using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_ClassLibrary1
{
    public class FileWorker
    {
        public List<Worker> readWorkers()
        {
            List<Worker> listWorkers = new List<Worker>();
            StreamReader streamReader = System.IO.File.OpenText("Workers.txt");
            string[] fields;
            string line = null;
            line = streamReader.ReadLine();

            while (line != null)
            {
                fields = line.Split(';');
                Worker worker = new Worker();
                worker.idCode = fields[0];
                worker.Name = fields[1];
                worker.Education = fields[2];
                worker.Specialty = fields[3];
                worker.Year = Int32.Parse(fields[4]);

                listWorkers.Add(worker);
                line = streamReader.ReadLine();
            }
            return listWorkers;

        }
        public List<Salary> readSalary()
        {
            List<Salary> listSalaries = new List<Salary>();
            StreamReader streamReader = System.IO.File.OpenText("Salary.txt");
            string[] fields;
            string line = null;
            line = streamReader.ReadLine();

            while (line != null)
            {
                fields = line.Split(';');
                Salary salary = new Salary();
                salary.idCode = fields[0];
                salary.Salary1 = Int32.Parse(fields[1]);
                salary.Salary2 = Int32.Parse(fields[2]);

                listSalaries.Add(salary);
                line = streamReader.ReadLine();
            }
            return listSalaries;
        }

    }
}
