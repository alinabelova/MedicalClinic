using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalClinic.Model;

namespace MedicalClinic.RecreateDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Check DB exists...");
            if (Database.Exists("MedicalClinicDb"))
            {
                Console.WriteLine("DB exists. Deleting...");
                Database.Delete("MedicalClinicDb");
            }
            else
            {
                Console.WriteLine("DB does not exist. Skip deleting.");
            }
            using (var db = new Db())
            {
                Console.WriteLine("Creating DB..");
                Console.WriteLine("Employees...");
                var belova = new Employee
                {
                    FirstName = "Alina",
                    MiddleName = "Leonidovna",
                    LastName = "Belova",
                    LastLoginTime = DateTime.Now,
                    Login = "ab",
                    Password = PasswordManager.CreateHash("123")
                };
                var admin = new Employee
                {
                    FirstName = "-",
                    MiddleName = "-",
                    LastName = "-",
                    LastLoginTime = DateTime.Now,
                    Login = "admin",
                    Password = PasswordManager.CreateHash("admin")
                };
                db.Employees.Add(belova);
                db.Employees.Add(admin);
                db.SaveChanges();


                Console.WriteLine("Clients..");
                var cl1 = new Client()
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanovich",
                    LastName = "Ivanov",
                    BirthDate = new DateTime(2000, 01, 10),
                    Address = "Mira, 98",
                    Pasport = "1234567890",
                    Policy = "001122",
                    Disease = "Caries"
                };
                var cl2 = new Client()
                {
                    FirstName = "Petr",
                    MiddleName = "Petrovich",
                    LastName = "Petrov",
                    BirthDate = new DateTime(1960, 05, 20),
                    Address = "Lenina, 74",
                    Pasport = "0987654312",
                    Policy = "213456",
                    Disease = "Poor eyesight"
                };
                var cl3 = new Client()
                {
                    FirstName = "Petr",
                    MiddleName = "Ivanovich",
                    LastName = "Sidorov",
                    BirthDate = new DateTime(1971, 10, 11),
                    Address = "K.Marksa, 2",
                    Pasport = "4984654312",
                    Policy = "234567",
                    Disease = "/---/"
                };
                db.Clients.Add(cl1);
                db.Clients.Add(cl2);
                db.Clients.Add(cl3);
                db.SaveChanges();

                Console.WriteLine("Doctors...");
                var doc1 = new Doctor()
                {
                    Speciality = "Dentist",
                    FirstName = "Svetlana",
                    MiddleName = "Victorovna",
                    LastName = "Konova",
                    Cabinet = 15,
                    WorkHours = "10.00 - 15.00",
                    Cost = 750,
                    Talons = new List<Talon>
                    {
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 10, 00, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 10, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 14, 30, 00)},
                         new Talon(){DateStart = new DateTime(2015, 07, 23, 10, 00, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 24, 10, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 25, 14, 30, 00)}
                    }
                   
                };
                var doc2 = new Doctor()
                {
                    Speciality = "Ophthalmologist",
                    FirstName = "Svetlana",
                    MiddleName = "Anatolyevna",
                    LastName = "Mangileva",
                    Cabinet = 2,
                    WorkHours = "8.00 - 13.00",
                    Cost = 600,
                    Talons = new List<Talon>
                    {
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 8, 00, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 8, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 11, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 23, 8, 00, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 24, 8, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 25, 11, 30, 00)}
                    }
                    
                };
                var doc3 = new Doctor()
                {
                    Speciality = "Therapist",
                    FirstName = "Tatyana",
                    MiddleName = "Alexandrovna",
                    LastName = "Zavyalova",
                    Cabinet = 10,
                    WorkHours = "12.00 - 17.00",
                    Cost = 800,
                    Talons = new List<Talon>
                    {
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 12, 00, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 12, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 22, 16, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 28, 12, 00, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 29, 12, 30, 00)},
                        new Talon(){DateStart = new DateTime(2015, 07, 29, 16, 30, 00)}
                    }
                };
         
                db.Doctors.Add(doc1);
                db.Doctors.Add(doc2);
                db.Doctors.Add(doc3);
                db.SaveChanges();

                Console.WriteLine("Services..");
                var s1 = new Service()
                {
                    Name = "Whitening teeth",
                    Price = 1000
                };
                var s2 = new Service()
                {
                    Name = "Injections",
                    Price = 300
                };
                var s3 = new Service()
                {
                    Name="Massage",
                    Price = 2000
                };
                db.Services.Add(s1);
                db.Services.Add(s2);
                db.Services.Add(s3);
                db.SaveChanges();

           
            }
            Console.WriteLine("Done! Cancel..");
            Console.ReadKey();
        }
    }
}
