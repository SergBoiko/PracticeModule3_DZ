using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments_ClassLibrary
{
    public class Department
    {
        public Department(string name)
        {
            Name = name;

            Vacancies = new List<Vacancy>();
        }

        public string Name { get; set; }

        public List<Vacancy> Vacancies { get; set; }

        public delegate void VacancyChanged(Vacancy vacancy);

        public event VacancyChanged VacancyAdded;
        public event VacancyChanged VacancyClosed;

        public void AddVacancy(Vacancy vacancy)
        {
            vacancy.Department = this;

            Vacancies.Add(vacancy);

            VacancyAdded(vacancy);
        }

        public void CloseVacancy(Vacancy vacancy)
        {
            if (!vacancy.IsOpen)
            {
                return;
            }

            vacancy.IsOpen = false;

            VacancyClosed(vacancy);
        }
    }
}

