using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace Example1
{
    [Serializable]
    public class Subject
    {
        public string name;
        public Subject() { }
        public Subject(string name)
        {
            this.name = name;
        }
    }

    [Serializable]
    public class Student
    {
        public string name;
        public string surname;
        public int age;
        public List<Subject> subjects;

        public Student() {}
        public Student(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            subjects = new List<Subject>();
            subjects.Add(new Subject("Programming languages"));
            subjects.Add(new Subject("Programming technologies"));
        }
    }

    class Program
    {
        static void F1()
        {
            Student student = new Student("Almas", "Abeuov", 23);
            FileStream fs = new FileStream("example.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            xs.Serialize(fs, student);
            fs.Close();
        }
        static void F2()
        {
            FileStream fs = new FileStream("example.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            Student student = (Student) xs.Deserialize(fs);
            Console.WriteLine(student.name + " " + student.surname);
            Console.ReadKey();
            fs.Close();
        }

        static void F3()
        {
            FileStream fs = new FileStream("example.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Student student = new Student("Almas", "Abeuov", 23);
            bf.Serialize(fs, student);
            fs.Close();
        }
        static void F4()
        {
            FileStream fs = new FileStream("example.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            Student student = bf.Deserialize(fs) as Student;
            foreach(Subject sub in student.subjects) {
                Console.WriteLine(sub.name);
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            F4();
        }
    }
}
