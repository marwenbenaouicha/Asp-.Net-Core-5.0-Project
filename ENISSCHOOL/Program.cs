using System;
using ENISSCHOOL ;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ENISSCHOOL
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, surname, classEtd ;
            Console.WriteLine("The student name :");
            name = Console.ReadLine(); // pour lire la valeur de name saisi par le client
            Console.WriteLine("The student Surname :");
            surname = Console.ReadLine();
            Console.WriteLine("The student class :");
            classEtd = Console.ReadLine();
            using (var context = new ENISContext())
            {
                var grd = new Grade()
                {
                    ClassNumber = 3,
                    Speciality = "GI"
                };
                var adr = new StudentAddress()
                {
                    Adress = "BP 208 route Gremda, SFAX",
                    City = "sfax" ,
                    State = "sfax" ,
                    Country =" Tunisia"
                };
                var std = new Student()
                {
                    Name = name ,
                    SurName = surname ,
                    Class = classEtd ,
                    Grade = grd,
                    Address =adr
                   
                };
                context.Students.Add(std) ;
                context.SaveChanges() ;
                //afficher le student qui à le nom Marwen
                var studentsWithSameName = context.Students.Where(s => s.Name == GetName())
                                                           .ToList();
                if (studentsWithSameName.Count != 0)
                {
                    // pour afficeher la liste des student qui on le meme nom
                    foreach (var elt in studentsWithSameName)
                        Console.WriteLine($"{elt.Name},{elt.SurName}, {elt.Class}");
                }
                else
                    Console.WriteLine("Not Found");

                //modifer le nom d'un étudiant
                Console.WriteLine("The name of the student that you want to modify");
                string modif = Console.ReadLine();
                var studentsModif = context.Students.Where(s => s.Name == modif)
                                                    .ToList();
                if (studentsModif.Count != 0)
                {
                    var stdMod = studentsModif.First(); // le First() pour modifier la premier occurence du nom q'on veut modifier
                    Console.WriteLine("The new Surname");
                    string newSurName = Console.ReadLine();
                    stdMod.SurName = newSurName;
                    context.SaveChanges();
                }
                else
                    Console.WriteLine("Not Found");

                //supprimer un élment de la base
                Console.WriteLine("The name of the student that you want to Delete");
                string rmv = Console.ReadLine();
                var studentsRemv = context.Students.Where(s => s.Name == rmv)
                                                    .ToList();
                if (studentsRemv.Count != 0)
                {
                    var stdRemv = studentsRemv.First(); // le First() pour modifier la premier occurence du nom q'on veut modifier
                    context.Students.Remove(stdRemv);
                    context.SaveChanges();
                }
                else
                    Console.WriteLine("Not Found");
                // Insérer les données à une entité déconnectée la table Grade n'est pas declarer comme DBSet
                var newGrade = new Grade()
                {
                    ClassNumber = 88,
                    Speciality = "GEE"
                };
                using( var context1 = new ENISContext())
                {
                    //Attach an entity to context with added entityState
                    context1.Add<Grade>(newGrade);
                    context1.SaveChanges();
                }


                // ajouter une liste de Grade et une Liste de Student
                var gradeList = new List<Grade>
                {
                    new Grade()
                    {
                        ClassNumber = 8 ,
                        Speciality = "GC" },
                    new Grade()
                    {
                        ClassNumber = 2 ,
                        Speciality = "GB"}
                };
                var studentList = new List<Student>()
                {
                    new Student(){ Name = "Mahmoud", SurName = "Ben Salah" },
                    new Student(){ Name = "Maha", SurName = "Ben Mohamed" }
                };
                using ( var context1 = new ENISContext())
                {
                    context1.AddRange(studentList);
                    context1.AddRange(gradeList);
                    context1.SaveChanges();
                }
                //suppression le grade d'ID = 1
                var GrdToDelete = new Grade()
                {
                    Id = 2
                };
                using ( var context1 = new ENISContext())
                {
                    context1.Remove<Grade>(GrdToDelete);
                    context1.SaveChanges();
                }

            }


        }
        public static String GetName()
        {
            String searchedName;
            Console.WriteLine("The name of the searched student ");
            searchedName = Console.ReadLine();
            return searchedName;
        }
     
    }
}
