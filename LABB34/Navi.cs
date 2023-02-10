using LABB34.Data;
using LABB34.Models;

namespace LABB34
{
    public class Navi
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("< ---------------------------------------- <");
                Console.WriteLine("| Welcome choose what to see from database |");
                Console.WriteLine("|  [1] Choose a class                      |");
                Console.WriteLine("|  [2] Get the students                    |");
                Console.WriteLine("|  [3] Add staff member                    |");
                Console.WriteLine("|  [4] Subject                             |");
                Console.WriteLine("|  [5] Total staff members                 |");
                Console.WriteLine("|  [6] Student information                 |");
                Console.WriteLine("|  [7] Grades                              |");
                Console.WriteLine("|  [8] Close the programe                  |");
                Console.WriteLine("> ---------------------------------------- <");
                //Console.Writeline("");
                int option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                //int input = checkNr();
                //switch (input); 
                //var choice = Console.ReadLine();
                //switch (choice)
                {
                    case 1:
                        ChooseAClass();
                        break;

                    case 2:
                        SeeAllStudents();
                        break;

                    case 3:
                        AddStaffMember();
                        break;

                    case 4:
                        StudentInfo(); 
                        break;

                    case 5:
                        Subject(); 
                        break;

                    case 6:
                        Grades();
                        break;

                    case 7:
                        StaffId(); 
                        break;

                    case 8:
                        System.Environment.Exit(0);
                        break;
                }
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            }
        }
    }

    public void ChooseAClass()
    {

        using (var sc = new Labb4Context())
        {
            var students = from c in sc.Students
                           select c;
            foreach (var it in students)
            {
                Console.WriteLine($"Classname:{it.Class} StudentId:{it.StudentId}");
            }
            Console.WriteLine("Write class you want to look at");
            int option = int.Parse(Console.ReadLine());
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            var Students1 = from s in sc.Students
                            join c in sc.Students on s.StudentId equals c.Class
                            where c.StudentId == option
                            select new
                            {
                                c.StudentId,
                                c.Class1,
                                s.FirstName,
                                s.LastNname
                            };

            foreach (var it in Students1)
            {
                Console.WriteLine($"classid:{it.StudentId} class:{it.Class1} FirstName:{it.FirstName} LastName:{it.LastName}");
            }
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Enter returns you to meny");
            Console.ReadKey();
            Console.Clear();

        }

    }

    public void SeeAllStudents()
    {
        Console.WriteLine("< -------------------------------------------- >");
        Console.WriteLine("|  Choose to see students by first or lastname |");
        Console.WriteLine("|  [1]   See students sorted by firstname      |");
        Console.WriteLine("|  [2]   See students sorted by lastname       |");
        Console.WriteLine("< -------------------------------------------- >");
        Console.Write(" [1] firstname, [2] lastname : ");
        int input = int.Parse(Console.ReadLine());
        //int input = checkNr();
        Console.Clear();

        if (input == 1)
        {
            Console.WriteLine("Choose sorting order for the students in firstname and in order by rising or falling");
            Console.WriteLine("[1] Rising");
            Console.WriteLine("[2] Falling");
            int choice = checkNr();
            int anwser = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
                using (var db = new Labb4Context())
                {
                    var SeeAllStudents = from a in db.Students orderby a.FirstName select a;
                    Console.WriteLine("");
                    foreach (var item in SeeAllStudents)
                    {
                        Console.WriteLine(item.FirstName + " " + item.LastName);

                    }
                }
                Console.WriteLine("Enter will return you to the meny");
                Console.ReadKey();
                Console.Clear();
            }
            else if (choice == 2)
            {
                using (var db = new Labb4Context())
                {
                    var SeeAllStudents = from a in db.Students.OrderByDescending(a => db.StudentContactLists) select a;
                    Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    foreach (var it in SeeAllStudents)
                    {

                        Console.WriteLine(it.FirstName + " " + it.LastName);
                    }
                }
                Console.WriteLine("Enter will return you to the meny");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (input == 2)
        {
            Console.WriteLine("Choose sorting by lastname rising or falling");
            Console.WriteLine("[1] Sorting lastname by rising");
            Console.WriteLine("[2] Sorting firstname by rising");
            int anwser = int.Parse(Console.ReadLine());
            if (anwser == 1)
            {
                using (var db = new Labb4Context())
                {
                    var SeeAllStudents = from a in Students orderby a.LastName select a;
                    Console.WriteLine("");
                    foreach (var item in SeeAllStudents)
                    {
                        Console.WriteLine(item.LastName + " " + item.FirstName);

                    }
                }
                Console.WriteLine("Enter will return you to the meny");
                Console.ReadKey();
                Console.Clear();
            }
            else if (anwser == 2)
            {
                using (var db = new Labb4Context())
                {
                    var Student = from a in StudentContactList.OrderByDescending(a => a.FirstName) select a;
                    Console.WriteLine("");
                    foreach (var item in Student)
                    {

                        Console.WriteLine(item.LastName + " " + item.FirstName);
                    }
                }
                Console.WriteLine("Enter will return you to the meny");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }


    public void AddStaffMember()
    {
        using Labb4Context context = new Labb4Context();
        StaffContactList e1 = new StaffContactList();
        Console.Write("Firstname : ");
        e1.FirstName = Console.ReadLine();
        Console.Write("Lastname : ");
        e1.LastName = Console.ReadLine();
        Console.Write("Work title : ");
        //e1.Staff = Console.ReadLine();
        context.StaffContactLists.Add(e1);
        context.SaveChanges();
        Console.WriteLine("Database updated");
        Console.WriteLine("Enter will return you to the meny");
        Console.ReadKey();
        Console.Clear();
    }

    public void StudentInfo()
    {
        using (var sc = new Labb4Context())
        {
            var Students1 = from s in sc.Students
                        join c in sc.Class on s.FkStudentId equals c.ClassId
                        select new
                        {
                            c.StudentId,
                            c.Class1,
                            s.Firstname,
                            s.Lastname
                        };

            Console.WriteLine("");
            foreach (var it in Students1)
            {
                Console.WriteLine($"classid:{it.ClassId} classname:{it.Class1} Firstname:{it.Firstname} Lastname:{it.Lastname}");
            }
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Tryck Enter för att återvända till menyn");
            Console.ReadKey();
            Console.Clear();
        }

    }

    public void Grades()
    {
        using (var sc = new Labb4Context())
        {
            var Students1 = from e in sc.Grades
                        select new
                        {
                            e.Grades,
                        };

            Console.WriteLine("Active grades");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            foreach (var it in Students1)
            {
                Console.WriteLine($"{it.Grades}");
            }
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Enter returns you to the meny");
            Console.ReadKey();
            Console.Clear();
        }

    }
    public void StaffId()
    {
        using (var sc = new Labb4Context())
        {
            var staff = from c in sc.staff
                        select c;
            foreach (var it in staff)
            {
                Console.WriteLine($"{it.StaffContactLists}");
            }
            Console.WriteLine("Write what teacher you want to se information about");
            string option = (Console.ReadLine());
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            var staff1 = from s in sc.StaffContactLists
                         where s. == option
                         select new
                         {
                             s.FkStaffId,
                             s.SocialSecufrityNumber,
                             s.FirstName,
                             s.LastName,
                             s.Startdate,                            
                         };

            foreach (var it in staff1)
            {
                Console.WriteLine($"FkstaffId:{it.FkStaffId} Socialsecuritynumber:{it.SocialSecufrityNumber} Firstname:{it.FirstName} Lastname:{it.LastName} Startdate: {it.Startdate}");
            }
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Enter returns you to meny");
            Console.ReadKey();
            Console.Clear();

        }
    }
}

