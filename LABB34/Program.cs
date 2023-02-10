using LABB34;

using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;

using LABB34.Data;
using LABB34.Models;

namespace LABB34
{
    public class Program
    {
        static void Main(string[] args)
        {
            Navi navi = new Navi();
            //navi.Show();
            navi.Start();

            using Labb4Context db = new Labb4Context();

            Console.WriteLine("Hello, World!");
        }
    }
}

// Lab 4
// nr 1

// See all staffmembers
/*
Select concat(Fname,' ', Lname) As Name, WorkTitle, DATEDIFF(year, HiredDate, '2022-12-20') As Years  From Employee
Join Title on TitleId = FK_TitleId
join SubjectSchool on SubjectSchoolId = FK_SchoolSubjectId
--Where WorkTitle = 'Nurse'-- Principal, Nurse, Janitor, Additional_Staff
order by Years DESC;
*/

// newstaffmenmber

/*
Insert into Employee (FName,LName,DateOfBirth,HiredDate,PhoneNr,Sex)
Values('Noomi','Rapace','1968-04-04','2023-01-02','070-2848787','F') 
*/


// nr 2
// See students grades staff member who put grades and date for grades
/*
 Select concat (Student.Fname,' ', Student.LName) As Student,Class, DateOfGrade, GivenGrade, Lesson ,concat (Employee.FName, ' ' ,Employee.LName) As Teacher From Grade
Join Student on StudentId = FK_StudentId
join Employee on EmployeeId = FK_EmployeeId
join SubjectSchool on SubjectSchoolId = FK_SchoolSubjectId
join Class on ClassId = FK_ClassId
order by Class  ASC 
*/

// See students grades
/*
 Select concat (Student.Fname,' ', Student.LName) As Student,Class, DateOfGrade, GivenGrade, Lesson ,concat (Employee.FName, ' ' ,Employee.LName) As Teacher From Grade
Join Student on StudentId = FK_StudentId
join Employee on EmployeeId = FK_EmployeeId
join SubjectSchool on SubjectSchoolId = FK_SchoolSubjectId
join Class on ClassId = FK_ClassId
where Student.FName = 'Hedvig'
*/

// Vilken klass eleven går i
/*
 select CONCAT (Student.Fname, ' ' , Student.LName) As Name ,Class From  Student
Join Class on ClassId = FK_ClassId
where FName = 'Lena'
*/


// nr 6 och 7
// salary
/*
 Select  SUM(Wage) AS Total_Wage, WorkTitle From Employee
join Title on TitleId = FK_TitleId
group by WorkTitle
order by Total_Wage DESC
*/

// Medellön på alla avdelningar
/*
 Select  Avg(Wage) AS Average_Wage,WorkTitle From Employee
join Title on TitleId = FK_TitleId
group by WorkTitle
order by Average_Wage DESC 
*/


// nr 9 Transaction
/*
 Begin Transaction Grade1 
Begin Try
update Grade
set GivenGrade = 5, DateOfGrade = GETDATE()
where GradeId = 1
Commit Transaction Grade1
End Try
Begin Catch
Rollback Transaction Grade1
End Catch
--select * from Grade
*/