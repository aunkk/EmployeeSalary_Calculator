using System;
namespace Calculation
{
    class SalaryCalculator
    {
        public static void Main(string[] args)
        {
            Employee[] employees = GetInput();

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

        public static Employee[] GetInput()
        {
            Console.Write("Enter number of employees: ");
            int employeesCount = Convert.ToInt32(Console.ReadLine());
            Employee[] emp = new Employee[employeesCount];
            for (int i = 0; i < employeesCount; i++)
            {
                emp[i] = new Employee();
                Console.WriteLine($"\nEnter details for employee {i + 1}");
                // >>ID Input<<
                while (true)
                {
                    try
                    {
                        Console.Write("ID: ");
                        string idInput = Console.ReadLine();
                        emp[i].Id = idInput;
                        break; // Exit loop if input is valid
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //Console.Write("ID: ");
                //employees[i].Id = Console.ReadLine();

                // >>First Name Input<<
                while (true)
                {
                    try
                    {
                        Console.Write("First Name: ");
                        string fnameInput = Console.ReadLine();
                        emp[i].FName = Capitalize(fnameInput);
                        break; // Exit loop if input is valid
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //Console.Write("First Name: ");
                //emp[i].FName = Capitalize(Console.ReadLine());

                // >>Last Name Input<<
                while (true)
                {
                    try
                    {
                        Console.Write("Last Name: ");
                        string lnameInput = Console.ReadLine();
                        emp[i].LName = Capitalize(lnameInput);
                        break; // Exit loop if input is valid
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //Console.Write("Last Name: ");
                //emp[i].LName = Capitalize(Console.ReadLine());

                // >>Position Input<<
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Position List:");
                        for (int pos = 0; pos < Company.positionWork.Length; pos++)
                        {
                            Console.WriteLine($"{pos + 1} : {Company.positionWork[pos]}");
                        }

                        Console.Write("Position (1-4): ");
                        int positionInput = Convert.ToInt32(Console.ReadLine());
                        emp[i].Position = positionInput;   // ให้ property เช็ค validate
                        break;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                //Console.Write("Position: ");
                //emp[i].Position = Convert.ToInt32(Console.ReadLine());

                // >>Age Input<<
                while (true)
                {
                    try
                    {
                        Console.Write("Age: ");
                        int ageInput = Convert.ToInt32(Console.ReadLine());
                        emp[i].Age = ageInput;
                        break; // Exit loop if input is valid
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //Console.Write("Age: ");
                //emp[i].Age = Convert.ToInt32(Console.ReadLine());

                //Console.Write("Salary: ");
                //employees[i].Salary = Convert.ToDouble(Console.ReadLine());
                //Console.Write("Hire Date (yyyy-mm-dd): ");
                //employees[i].HireDate = DateTime.Parse(Console.ReadLine());

                // >>Work Duration Input<<
                while (true)
                {
                    try
                    {
                        Console.Write("Work Duration (in months): ");
                        int workDurationInput = Convert.ToInt32(Console.ReadLine());
                        emp[i].WorkDuration = workDurationInput;
                        break; // Exit loop if input is valid
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //Console.Write("Work Duration (in months): ");
                //emp[i].WorkDuration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("====================");
            }
            return emp;
        }

        public static void CalculateSalary(Employee[] employees)
        {
            foreach (Employee emp in employees)
            {
                int year = emp.WorkDuration / 12;
                switch (emp.Position)
                {
                    case 1:
                        emp.Salary = 60000;
                        emp.Bonus_percentage += 10;
                        break;
                    case 2:
                        emp.Salary = 45000;
                        emp.Bonus_percentage += 5;
                        break;
                    case 3:
                        emp.Salary = 30000;
                        emp.Bonus_percentage += 0;
                        break;
                    case 4:
                        emp.Salary = 12000;
                        emp.Bonus_percentage += 0;
                        break;
                    default:
                        emp.Salary = 8000;
                        break;
                }

                if (year > 10)
                {
                    emp.Bonus_percentage += 10;
                }
                else if ((year/12 >= 5) && (year/12 <= 9) )
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
        private int position;
        private int age;
        private double salary;
        private int workDuration; // in months
        private int bonus_percentage;
        public Employee()
        {
            this.id = "null";
            this.firstName = "null";
            this.lastName = "null";
            this.position = 0;
            this.age = 0;
            this.salary = 0.0;
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
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Last name cannot be empty.");
                }
                else
                {
                    lastName = value;
                }
            }
        }
        public int Position
        {
            get { return position; }
            set
            {
                if (value <= 0)
                { throw new ArgumentException("Please enter positive number."); }
                else if (value > 4)
                { throw new ArgumentException("Please enter valid position number."); }
                else
                {
                    position = value;
                }
            }
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

    class Company
    {
        public static string[] positionWork = { "Manager", "Team Leader", "Staff", "Intern" };
    }

}