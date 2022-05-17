using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization.XML
{
        public class Student
        {
            public int Id { get; set; } = 1;
            public string FirstName { get; set; } = "";
            public string LastName { get; set; } = "";
            public DateTime DateOfBirth { get; set; } = DateTime.Now;
        }
        class Program
        {
            static void Main(string[] args)
            {
                var student = new Student
                {
                    Id = 1,
                    FirstName = "Nguyen Van",
                    LastName = "A",
                    DateOfBirth = new DateTime(1990, 12, 30)
                };
                Console.WriteLine("Original object:");
                Print(student);
                Save(student);
                var nva = Load();
                Console.WriteLine("Deserialized object:");
                Print(nva);
                Console.ReadKey();
            }
            static void Print(Student student)
            {
                Console.WriteLine($"Id: {student.Id}\r\nFirst Name: {student.FirstName}\r\nLast Name: {student.LastName}\r\nDate of birth: {student.DateOfBirth.ToShortDateString()}");
            }
            static void Save(Student student)
            {
                using (var stream = File.OpenWrite("data.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Student));
                    serializer.Serialize(stream, student);
            }
            }
            static Student Load()
            {
                Student student;
                using (var stream = File.OpenRead("data.xml"))
                {
                    var serializer = new XmlSerializer(typeof(Student));
                    student = serializer.Deserialize(stream) as Student;
                }
                return student;
            }
        }
    
}
