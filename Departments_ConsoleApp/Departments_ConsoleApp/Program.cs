using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Departments_ClassLibrary;

namespace Departments_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = new List<Task>();

            var departments = new List<Department>()
            {
                new Department(".NET"),
                new Department("Java"),
                new Department("JS")
            };

            var random = new Random();
            var users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                string number = "";

                for (int j = 0; j < 10; j++)
                {
                    number += random.Next(10);
                }

                var user = new User()
                {
                    Email = $"test{number}@gmail.com",
                    Name = $"user{number}",
                    PhoneNumber = number
                };

                var subsribedDepartment = departments[random.Next(3)];

                subsribedDepartment.VacancyAdded += (Vacancy vacancy) =>
                {
                    tasks.Add(SendEmailAsync($"Vacancy '{vacancy.Name}' was added for department '{vacancy.Department.Name}'", user));
                };

                subsribedDepartment.VacancyClosed += (Vacancy vacancy) =>
                {
                    tasks.Add(SendEmailAsync($"Vacancy '{vacancy.Name}' was closed for department '{vacancy.Department.Name}'", user));
                };

                users.Add(user);
            }

            departments[0].AddVacancy(new Vacancy()
            {
                Name = "Junior .NET Developer",
                IsOpen = true
            });

            departments[0].AddVacancy(new Vacancy()
            {
                Name = "Middle .NET Developer",
                IsOpen = true
            });

            departments[0].AddVacancy(new Vacancy()
            {
                Name = "Seniour .NET Developer",
                IsOpen = true
            });

            departments[1].AddVacancy(new Vacancy()
            {
                Name = "Junior Java Developer",
                IsOpen = true
            });

            departments[1].AddVacancy(new Vacancy()
            {
                Name = "Middle Java Developer",
                IsOpen = true
            });

            departments[1].AddVacancy(new Vacancy()
            {
                Name = "Seniour Java Developer",
                IsOpen = true
            });

            departments[2].AddVacancy(new Vacancy()
            {
                Name = "Junior JS Developer",
                IsOpen = true
            });

            departments[2].AddVacancy(new Vacancy()
            {
                Name = "Middle JS Developer",
                IsOpen = true
            });

            departments[2].AddVacancy(new Vacancy()
            {
                Name = "Seniour JS Developer",
                IsOpen = true
            });

            departments[0].CloseVacancy(departments[0].Vacancies[0]);
            departments[1].CloseVacancy(departments[1].Vacancies[0]);
            departments[2].CloseVacancy(departments[2].Vacancies[0]);

            Task.WaitAll(tasks.ToArray());
        }

        public static async Task SendEmailAsync(string text, User user)
        {
            await Task.Run(() =>
            {
                var email = new Email()
                {
                    Text = text,
                    To = user
                };

                Thread.Sleep(3000);

                Console.WriteLine($"Email with text:\r\n{email.Text}\r\nwas sent to {user.Name}");
            });
        }
    }
    
}
