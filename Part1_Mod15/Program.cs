using System;
using System.Linq;
using System.Collections.Generic;

namespace Part1_Mod15
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_15_1_();
            //Task_15_1_4();
            //Task_15_1_5();
            //Task_15_1_6();
            //Task_15_2_1();
            //Task_15_2_2();
            //Task_15_2_3();
            //Task_15_2_6();
            //Task_15_2_8();
            //Task_15_3_0();
            //Task_15_3_3();
            //Task_15_4_0();
            //Task_15_4_1();
            //Task_15_4_2();
            //Task_15_4_5();
            //Task_15_5_0();
            Task_15_5_4();
        }

        private static void Task_15_5_4()
        {
            List<int> lst = new() { 1, 2, 3, 4, 5 };
            var res13 = lst.Skip(3).Take(5);
            foreach(var i in res13)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            List<int> lst2 = new() {};
            //var f1 = lst2.First();
            var f2 = lst2.FirstOrDefault();
            Console.WriteLine( f2);

            var r = lst.Union(lst2);
            foreach(int i in r)
            {
                Console.WriteLine(i);
            }

            var res = lst.Select(c => c);
            var res1 = lst.Select(c => c).ToArray();
            var res2 = (from c in lst where c > 2 select c).Count();

            lst.Remove(2);
            foreach(int i in res)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach(int i in res1)
            {
                Console.Write(i + " ");
            }

        }

        private static void Task_15_5_0()
        {
            var contacts = new List<OldContact>()
            {
                new OldContact() { Name = "Андрей", Phone = 79994500508 },
                new OldContact() { Name = "Сергей", Phone = 799990455 },
                new OldContact() { Name = "Иван", Phone = 79999675334 },
                new OldContact() { Name = "Игорь", Phone = 8884994 },
                new OldContact() { Name = "Анна", Phone = 665565656 },
                new OldContact() { Name = "Василий", Phone = 3434 }
            };

            var result = contacts.Where(c => c.Phone == 3434).Select(c => c);

            var res1 = contacts;
            Console.WriteLine(res1.Count());
            Console.WriteLine(result.Count());

            contacts.Add(new OldContact() { Name = "Василий", Phone = 3434 });

            Console.WriteLine(result.Count());
            Console.WriteLine(res1.Count());
        }

        private static void Task_15_4_5()
        {
            //var customers = new Customer[] {
            //    new Customer{ID = 5, Name = "Андрей"},
            //    new Customer{ID = 6, Name = "Сергей"},
            //    new Customer{ID = 7, Name = "Юлия"},
            //    new Customer{ID = 8, Name = "Анна"}
            //};

            //var orders = new Order[] 
            //{
            //    new Order{ID = 6, Product = "Игру"},
            //    new Order{ID = 7, Product = "Компьютер"},
            //    new Order{ID = 3, Product = "Рубашку"} ,
            //    new Order{ID = 5, Product = "Книгу"}
            //};

            //var query = from c in customers
            //            join o in orders on c.ID equals o.ID
            //            select new { c.Name, o.Product };
            //foreach (var group in query)
            //    Console.WriteLine($"{group.Name} покупает {group.Product}");


        }

        private static void Task_15_4_2()
        {
            var departments = new List<Department>()    
            {       
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };

            var employees = new List<Employee>()
            {
                new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var res = departments.GroupJoin(employees, dep => dep.Id, emp => emp.DepartmentId,
                (dep, emp) => new
                {
                    Name = dep.Name,
                    DepId = dep.Id,
                    Empl = emp.Select(e => e), //c  e => e.Name проверил тоже
                });
            foreach ( var d in res)
            {
                Console.Write($"{d.Name}, {d.DepId} : ");
                foreach(var e in d.Empl)
                {
                    Console.Write($"{e.Name} ");
                }
                Console.WriteLine();
            }
        }



        private static void Task_15_4_1()
        {
            var departments = new List<Department>()
            {
                new Department() {Id = 1, Name = "Программирование"},
                new Department() {Id = 2, Name = "Продажи"}
            };
            var employees = new List<Employee>()
            {
                new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
                new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
                new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
                new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var list1 = from e in employees
                        join d in departments on e.DepartmentId equals d.Id
                        select new
                        {
                            Name = e.Name,
                            DeptId = e.DepartmentId,
                            Dept = d.Name
                        };
            foreach (var item in list1)
                Console.WriteLine($"{item.Name} {item.DeptId} {item.Dept}");

            var list2 = employees.Join(departments,
                e => e.DepartmentId, d => d.Id,
                (e, d) => new
                {
                    Name = e.Name,
                    DeptId = e.DepartmentId,
                    Dept = d.Name
                });
            foreach (var item in list2)
                Console.WriteLine($"{item.Name} {item.DeptId} {item.Dept}");

        }

        private static void Task_15_4_0()
        {
            List<Car> cars = new () {
                new Car() { Model  = "SX4", Manufacturer = "Suzuki"},
                new Car() { Model  = "Grand Vitara", Manufacturer = "Suzuki"},
                new Car() { Model  = "Jimny", Manufacturer = "Suzuki"},
                new Car() { Model  = "Land Cruiser Prado", Manufacturer = "Toyota"},
                new Car() { Model  = "Camry", Manufacturer = "Toyota"},
                new Car() { Model  = "Polo", Manufacturer = "Volkswagen"},
                new Car() { Model  = "Passat", Manufacturer = "Volkswagen"},
            };

            List<Manufacturer> manufacturers = new () {
                new Manufacturer() { Country = "Japan", Name = "Suzuki" },
                new Manufacturer() { Country = "Japan", Name = "Toyota" },
                new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
            };

            var result = from c in cars
                         join m in manufacturers on c.Manufacturer equals m.Name
                         select new
                         {
                             Name = c.Model,
                             Manufacturer = m.Name,
                             Country = m.Country
                         };
            foreach (var item in result)
                Console.WriteLine($"{item.Name}, {item.Manufacturer}, {item.Country}");

            Console.WriteLine();
            var res2 = cars.Join(manufacturers,
                car => car.Manufacturer, m => m.Name,
                (car, m) => new
                {
                    Name = car.Model,
                    Manufacturer = m.Name,
                    Country = m.Country
                });
            foreach (var item in res2)
                Console.WriteLine($"{item.Name}, {item.Manufacturer}, {item.Country}");

            //
            Console.WriteLine("\n== GroupJoin ==");
            var result2 = manufacturers.GroupJoin(cars, m => m.Name, car => car.Manufacturer, 
                (m, crs) => new  
                {
                    Name = m.Name,
                    Country = m.Country,
                    Cars = crs.Select(c => c.Model)
                });
            // Вывод:
            foreach (var team in result2)
            {
                Console.WriteLine(team.Name + ":");

                foreach (string car in team.Cars)
                    Console.WriteLine(car);

                Console.WriteLine("==");
            }

        }

        private static void Task_15_3_3()
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
            phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

            var groups = from rec in phoneBook
                         let isFake = rec.Email.Contains("@example.com")
                         group rec by isFake;
            foreach (var g in groups)
            {
                Console.WriteLine($"\nisFake: {g.Key}");
                foreach (Contact c in g)
                    Console.WriteLine($"{c.Name}: {c.Email}");
            }

            var g2 = phoneBook.GroupBy(c => c.Email.Contains("@example.com"));
            foreach (var g in g2)
            {
                Console.WriteLine($"\nisFake: {g.Key}");
                foreach (Contact c in g)
                    Console.WriteLine($"{c.Name}: {c.Email}");
            }

        }

        private static void Task_15_3_0()
        {
            List<OldCar> cars = new () {
                new OldCar("Suzuki", "JP"),
                new OldCar("Toyota", "JP"),
                new OldCar("Opel", "DE"),
                new OldCar("Kamaz", "RUS"),
                new OldCar("Lada", "RUS"),
                new OldCar("Honda", "JP"),
            };

            var carsByCountry = from c in cars
                                group c by c.CountryCode;
            foreach (var grouping in carsByCountry)
            {
                Console.Write($"\n {grouping.Key}: ");
                foreach(OldCar c in grouping)
                    Console.Write(c.Manufacturer + " ");
            }

            var cbc = cars.GroupBy(c => c.CountryCode);
            foreach (var grouping in cbc)
            {
                Console.Write($"\n {grouping.Key}: ");
                foreach (OldCar c in grouping)
                    Console.Write(c.Manufacturer + " ");
            }

            var cbc2 = cars.GroupBy(c => c.CountryCode).Select(group => new { Name = group.Key, Amount = group.Count()});

            var cbc3 = from car in cars
                       group car by car.CountryCode into grouping
                       select new { Name = grouping.Key, Cnt = grouping.Count(), Cars = from p in grouping select p };
            foreach(var group in cbc3)
            {
                Console.Write($"\n{group.Name} ({group.Cnt}) : ");
                foreach(var c in group.Cars)
                {
                    Console.Write(c.Manufacturer + " ");
                }
            }

            Console.WriteLine();
            var cbc4 = cars.GroupBy(c => c.CountryCode).Select(g => new { Name = g.Key, Cnt = g.Count(), Cars = g.Select(c => c)});
            foreach (var group in cbc4)
            {
                Console.Write($"\n{group.Name} ({group.Cnt}) : ");
                foreach (var c in group.Cars)
                {
                    Console.Write(c.Manufacturer + " ");
                }
            }

        }

        private static void Task_15_2_8()
        {
            List<int> nums = new();
            while (true)
            {
                Console.WriteLine("Введите целое число или нажминте Ctrl+C ");
                nums.Add(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine($"Кол-во чисел: {nums.Count()}; Сумма чисел: {nums.Sum()}; Max: {nums.Max()}; Min: {nums.Min()}; Average: {nums.Average()}\n");
            }
        }

        private static void Task_15_2_6()
        {
            double[] numbs = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(numbs.Where(n => n%2 != 0).Sum());

            int[] nums = new[] { 2, 8, 11 };
            int avg = (int)nums.Average();
            Console.WriteLine(avg);
        }

        private static void Task_15_2_3()
        {
            double[] nums = { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(nums.Sum()/nums.Count());
            Console.WriteLine(nums.Sum() / nums.Length);

            Console.WriteLine(nums.Max());
            Console.WriteLine(nums.Min());
            Console.WriteLine(nums.Average());

            var contacts = new List<OldContact>()
            {
                new OldContact() { Name = "Андрей", Phone = 79994500508 },
                new OldContact() { Name = "Сергей", Phone = 799990455 },
                new OldContact() { Name = "Иван", Phone = 79999675334 },
                new OldContact() { Name = "Игорь", Phone = 8884994 },
                new OldContact() { Name = "Анна", Phone = 665565656 },
                new OldContact() { Name = "Василий", Phone = 3434 }
            };

            Console.WriteLine(contacts.Max(c => c.Phone));
            Console.WriteLine(contacts.Min(c => c.Phone));
            Console.WriteLine(contacts.Average(c => c.Phone));



        }

        private static void Task_15_2_2()
        {
            var contacts = new List<OldContact>() 
            {
                new OldContact() { Name = "Андрей", Phone = 79994500508 },
                new OldContact() { Name = "Сергей", Phone = 799990455 },
                new OldContact() { Name = "Иван", Phone = 79999675334 },
                new OldContact() { Name = "Игорь", Phone = 8884994 },
                new OldContact() { Name = "Анна", Phone = 665565656 },
                new OldContact() { Name = "Василий", Phone = 3434 }
            };

            Console.WriteLine(contacts.Count(c => (c.Phone < 70_000_000_000 || c.Phone > 79_999_999_999)));
        }

        private static void Task_15_2_1()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            Console.WriteLine(nums.Aggregate((x,y) => x+y));
            Console.WriteLine(nums.Aggregate((x,y) => x*y));

            int lessTanThree = (from int i in nums
                                where i < 3
                                select i).Count();
            Console.WriteLine(lessTanThree);
            Console.WriteLine( nums.Where(i => i < 3).Count());
            Console.WriteLine( nums.Count(i => i <3));

        }

        private static void Task_15_1_6()
        {
            string input = Console.ReadLine();
            string punkt = " ,.;:?!";
            foreach (char c in input.Except(punkt))
                Console.WriteLine(c);

        }

        private static void Task_15_1_5()
        {
            var softwareManufacturers = new List<string>()  {"Microsoft", "Apple", "Oracle"};
            var hardwareManufacturers = new List<string>() {"Apple", "Samsung", "Intel"};
            foreach (string man in softwareManufacturers.Union(hardwareManufacturers))
                Console.WriteLine(man);
            Console.WriteLine();
        }

        private static void Task_15_1_4()
        {
            string word1 = "aaqwerty12asd";
            string word2 = "aazxcvb12asd";
            foreach (char c in word1.Intersect(word2))
                Console.WriteLine(c);
            Console.WriteLine();
        }

        private static void Task_15_1_()
        {
            string[] drinks = { "Вода", "Кока-кола", "Лимонад", "Вино", "Вино", "Вода" };
            string[] alcohol = { "Вино", "Пиво", "Сидр" };
            foreach (string drink in drinks.Except(alcohol))
                Console.WriteLine(drink);
            Console.WriteLine();

            string[] cars = { "Волга", "Москвич", "Нива", "Газель" };
            string[] buses = { "Газель", "Икарус", "ЛиАЗ" };
            foreach (string mb in cars.Intersect(buses))
                Console.WriteLine(mb);
            Console.WriteLine();

            foreach (string v in cars.Union(buses))
                Console.WriteLine(v);
            Console.WriteLine();

            foreach (string v in cars.Concat(buses))
                Console.WriteLine(v);
            Console.WriteLine();

            foreach (string v in cars.Concat(buses).Distinct())
                Console.WriteLine(v);
            Console.WriteLine();

            int[] uneven = { 1, 3, 5 };
            int[] even = { 2, 4, 6, 2 };
            foreach (var num in uneven.Union(even))
                Console.WriteLine(num);
        }
    }

    public class Employee
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public Employee(System.Int32 DepartmentId, string name, int id)
        {
            this.DepartmentId = DepartmentId;
            Name = name;
            Id = id;
        }
        public Employee() { }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department()
        {
        }
    }
    public class Car
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }

    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    internal class OldCar
    {
        public string Manufacturer { get; set; }
        public string CountryCode { get; set; }
        public OldCar (string m, string c)
        {
            Manufacturer = m;
            CountryCode = c;
        }
    }

    internal class Contact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public Contact(string name, long phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
    }

    internal class OldContact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
    }
}
