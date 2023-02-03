using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LABB34.Data;
using LABB34.Models;
using Microsoft.EntityFrameworkCore;

namespace LABB34
{
    internal class Navi
    {
        //public class Start        
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
                //int option = int.Parse(Console.ReadLine());
                Console.Clear();

                //switch (option)
                //int input = checkNr();
                //switch (input)
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case 1:                        
                        ChooseAClass();
                        break;

                    case 2:
                        SeeAllStudents();
                        break;

                    case 3:
                        //AddStaffMember();
                        break;

                    case 4:
                        //Subject();
                        break;
                    case 5:
                        //SeeAllStaffMembers();
                        break;
                    case 6:
                        //StudentInfo();
                        break;
                    case 7:
                        //Grades();
                        break;

                    case 8:
                        System.Environment.Exit(0);
                        break;
                }
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>");
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
                //int choice = checkNr();
                //int choice = checkNr();
                int anwser = int.Parse(Console.ReadLine());
                if (answer == 1)
                {
                    using (var db = new Labb4Context())
                    {
                        var SeeAllStudents = from a in db.Students orderby a.Fname select a;
                        Console.WriteLine("");
                        foreach (var item in SeeAllStudents)
                        {
                            Console.WriteLine(item.Fname + " " + item.Lname);

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

                            Console.WriteLine(it.Fname + " " + it.Lname);
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
                        var Student = from a in StudAll orderby a.Lname select a;
                        Console.WriteLine("");
                        foreach (var item in Student)
                        {
                            Console.WriteLine(item.Lname + " " + item.Fname);

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
                        var Student = from a in Schoolcontext.OrderByDescending(a => a.Fname) select a;
                        Console.WriteLine("");
                        foreach (var item in Student)
                        {

                            Console.WriteLine(item.Lname + " " + item.Fname);
                        }
                    }
                    Console.WriteLine("Enter will return you to the meny");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
        // public void AddStaff()
        //{
        //  using Labb4Context = new Labb4Context();
        // StaffAdmin e1 = new StaffAdmin();
        // Console.Write("Firstname : ");
        // e1.Fname = Console.ReadLine();
        // Console.Write("Lastname : ");
        // e1.Lname = Console.ReadLine();
        // Console.Write("Work title : ");
        //  e1.Position = Console.ReadLine();
        //  Labb4Context.StaffAdmins.Add(e1);
        //  Labb4Context.SaveChanges();
        //  Console.WriteLine("Database updated");
        //  Console.WriteLine("TrEnter will return you to the meny");
        //  Console.ReadKey();
        // Console.Clear();
    }


}



//}