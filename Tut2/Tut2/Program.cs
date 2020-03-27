using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TutorialSolution2;

namespace Tut2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            
            Console.WriteLine("testestestest");
            Console.WriteLine("Enter a path to CSV file:");
            String filePathToCsv = Console.ReadLine();

            Console.WriteLine("Enter a destination path:");
            String destinationPath = Console.ReadLine() + "result";
            Console.WriteLine(destinationPath);

            Console.WriteLine("Enter data format:");
            String dataFormat = Console.ReadLine();
            destinationPath = destinationPath + "." + dataFormat;
            Console.WriteLine(destinationPath);

            String LogFilePath = "E://PJA//APBD//TutorialSolution2//TutorialSolution2//log.txt";
            Console.WriteLine(LogFilePath);
            using (FileStream logging = new FileStream(LogFilePath, FileMode.Create))
            {
                try
                {
                    if (!File.Exists(filePathToCsv))
                    {
                        AddText(logging, "Path to File CSV not found.");
                        throw new FileNotFoundException("CSV file does not exist.");
                    }

                    if (File.Exists(destinationPath))
                    {
                        File.Delete(destinationPath);
                    }

                    using (FileStream fs = File.Create(destinationPath))
                    using (var stream = new StreamReader(File.OpenRead(filePathToCsv)))
                    {
                        string line;
                        while ((line = stream.ReadLine()) != null)
                        {
                            string[] students = line.Split(',');

                            if (students.Length < 9)
                            {
                                continue;
                            }

                            var student = new Student()
                            {
                                FirstName = students[0],
                                LastName = students[1],
                                IndexNumber = students[4],
                                BirthDate = students[5],
                                Email = students[6],
                                MotherName = students[7],
                                FatherName = students[8],
                                studies = new Studies()
                                {
                                    Course = students[2],
                                    StudiesMode = students[3]
                                }
                            };
                            list.Add(student);
                        }

                        XmlSerializer sr = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("university"));

                        sr.Serialize(fs, list);
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                    AddText(logging, "Exception caught.");
                }
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] data = new UTF8Encoding(true).GetBytes(value);
            fs.Write(data, 0, data.Length);
        }
    }
}