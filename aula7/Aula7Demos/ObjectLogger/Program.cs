using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace ObjectLogger
{
    //Mock class
    public class StudentInscription
    {
        private String courses = "AVE;SO";

        public override string ToString()
        {
            return courses;
        }
    }

    class Student
    {
        private int number;
        private String address;
        private List<StudentInscription> inscriptions;

        public Student()
        {
            inscriptions = new List<StudentInscription>();
            inscriptions.Add(new StudentInscription());
        }

        public String Address
        {
            get
            {
                return address;
            }
            set
            {
                // validate 'value' structure
                /*if (!value.Contains("..."))
                {
                    throw new Exception("validation failed...");
                }*/
                address = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                // TODO: validate 'value'
                number = value;
            }
        }

        // auto-property
        public String Name
        {
            get; set;
        }

        // indexer with parameter of type int
        public StudentInscription this[int i]
        {
            get
            {
                return inscriptions[i];
            }
            /*set
            {

            }*/
        }

    }


    class Program
    {
        public static void Log(object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("{");
            if (t.IsArray)
            {
                int idx = 0;
                IEnumerable sequence = (IEnumerable)obj;
                IEnumerator it = sequence.GetEnumerator();
                while (it.MoveNext())
                {
                    object curr = it.Current;
                    Console.WriteLine("\t[{0}]={1}", idx++, curr);
                }
            } else {
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    if (pi.GetIndexParameters().Length == 0)
                    {
                        Console.WriteLine("\t{0}={1}", pi.Name, pi.GetValue(obj));
                    }
                    else
                    {
                        Console.WriteLine("\t{0}={1}",
                            pi.Name,
                            // this is *not* a general solution because it assumes the index
                            // parameter has the 'int' type
                            pi.GetValue(obj, new object[] { 0 }));
                    }
                }
            }
            Console.WriteLine("}");
        }
        static void Main(string[] args)
        {
            Student s = new Student();
            s.Name = "jose";
            s.Address = "lisboa";
            s.Number = 20674;
            Log(s);
            Log(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            Log(new string[] { "AVE", "SO" });
            Log(new Student[] { new Student() });
        }
    }
}
