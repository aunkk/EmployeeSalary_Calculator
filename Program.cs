using System;
namespace Company
{
    class SalaryCalculator
    {
        public static void Main(string[] args)
        {
            Employee[] employees = getInput();

            CalculateSalary(employees);

            Console.WriteLine("\nEmployee Details with Calculated Salaries:");

            foreach (Employee emp in employees)
            {
                emp.DisplayInfo();
                Console.WriteLine();
            }
        }

        public static String Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public static Employee[] getInput()
        {
            Console.Write("Enter number of employees: ");
            int employeesCount = Convert.ToInt32(Console.ReadLine());
            Employee[] employees = new Employee[employeesCount];
            for (int i = 0; i < employeesCount; i++)
            {
                employees[i] = new Employee();
                Console.WriteLine($"\nEnter details for employee {i + 1}");
                Console.Write("ID: ");
                employees[i].Id = Console.ReadLine();
                Console.Write("First Name: ");
                employees[i].FName = Capitalize(Console.ReadLine());
                Console.Write("Last Name: ");
                employees[i].LName = Capitalize(Console.ReadLine());
                Console.Write("Position: ");
                employees[i].Position = Capitalize(Console.ReadLine());
                Console.Write("Age: ");
                employees[i].Age = Convert.ToInt32(Console.ReadLine());
                //Console.Write("Salary: ");
                //employees[i].Salary = Convert.ToDouble(Console.ReadLine());
                //Console.Write("Hire Date (yyyy-mm-dd): ");
                //employees[i].HireDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Work Duration (in months): ");
                employees[i].WorkDuration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("====================");
            }
            return employees;
        }

        public static void CalculateSalary(Employee[] employees)
        {
            foreach (Employee emp in employees)
            {
                switch (emp.Position.ToLower())
                {
                    case "manager":
                        emp.Salary = 60000;
                        emp.Bonus_percentage += 10;
                        break;
                    case "team leader":
                        emp.Salary = 45000;
                        emp.Bonus_percentage += 5;
                        break;
                    case "staff":
                        emp.Salary = 30000;
                        emp.Bonus_percentage += 0;
                        break;
                    case "intern":
                        emp.Salary = 12000;
                        emp.Bonus_percentage += 0;
                        break;
                    default:
                        emp.Salary = 8000;
                        break;
                }

                if (emp.WorkDuration/12 > 10)
                {
                    emp.Bonus_percentage += 10;
                }
                else if ((emp.WorkDuration/12 >= 5) && (emp.WorkDuration/12 <= 9) )
                {
                    emp.Bonus_percentage += 5;
                }
                else
                {
                    emp.Bonus_percentage += 0;
                }

                emp.Salary += (emp.Salary * emp.Bonus_percentage) / 100;
            }
        }
    }
    class Employee
    {
        private string id;
        private string firstName;
        private string lastName;
        private string position;
        private int age;
        private double salary;
        //private DateTime hireDate;
        private int workDuration; // in months
        private int bonus_percentage;
        public Employee()
        {
            this.id = "null";
            this.firstName = "null";
            this.lastName = "null";
            this.position = "null";
            this.age = 0;
            this.salary = 0.0;
            //this.hireDate = DateTime.MinValue;
            this.workDuration = 0;
            this.bonus_percentage = 0;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"\nID: {Id} Name: {FName} {LName}, {Age} years old\nPosition: {Position}, salary: {Salary}\nwork duration: {WorkDuration}");
            Console.Write("--------------------");
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (value == "")
                    { throw new ArgumentException("ID cannot be empty."); }
                else
                {
                    id = value;
                }
            }
        }
        public string FName
        {
            get { return firstName; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("First name cannot be empty.");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        public string LName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 65)
                    { throw new ArgumentException("Age must be between 18 and 65."); }
                else
                {
                    age = value;
                }
            }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    { throw new ArgumentException("Salary cannot be negative."); }
                else
                {
                    salary = value;
                }
            }
        }
        //public DateTime HireDate
        //{
        //    get { return hireDate; }
        //    set { hireDate = value; }
        //}
        public int WorkDuration
        {
            get { return workDuration; }
            set
            {
                if (value < 0)
                    { throw new ArgumentException("Work duration cannot be negative."); }
                else
                {
                    workDuration = value;
                }
            }
        }
        public int Bonus_percentage
        {
            get { return bonus_percentage; }
            set
            {
                if (value < 0 || value > 100)
                    { throw new ArgumentException("Bonus percentage must be between 0 and 100."); }
                else
                {
                    bonus_percentage = value;
                }
            }
        }

    }
}