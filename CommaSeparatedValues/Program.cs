using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

namespace CommaSeparatedValues
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"D:\projects\CommaSeparatedValues\CommaSeparatedValues\bin\Debug\net5.0\users.csv";
            if (filePath == null || filePath == string.Empty || filePath == "")
            {
                Console.WriteLine("Please Enter Path File CVS\n");
                filePath = Console.ReadLine();
            }

          

            int id; string fName; string lName; string dateOfBirth;

            Console.WriteLine("Please Enter ID ");

            id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please Enter FName ");

            fName = Console.ReadLine();

            Console.WriteLine("Please Enter LName ");

            lName = Console.ReadLine();

            Console.WriteLine("Please Enter DateOfBirth Same (01/02/2000)");

            dateOfBirth = Console.ReadLine();

           // Replace(filePath, fName);

            AddRecord(filePath, id, fName, lName, dateOfBirth);

            Console.WriteLine("Enter Name Or Id");

            string searchName = Console.ReadLine();

            GetByName(filePath, searchName);

            Console.WriteLine("===================");




            if (filePath.Length <= 0)
            {
                Console.WriteLine("This File Is Empty");
                return;
            }

            GetDataFromCVS(filePath);

            Console.ReadKey();


        }

        private static void GetDataFromCVS(string csv_file_path)
        {

            StreamReader reader = null;
            if (File.Exists(csv_file_path))
            {
                reader = new StreamReader(File.OpenRead(csv_file_path));
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    foreach (var item in values)
                    {
                        listA.Add(item);
                        Console.WriteLine("\n" + item);
                    }

                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
        }

        private static string GetByName(string filepath, string searchName)
        {
            var strLines = File.ReadLines(filepath);
            foreach (var line in strLines)
            {

                if (line.Split(',')[0].Equals(searchName) || line.Split(',')[1].Equals(searchName) || line.Split(',')[2].Equals(searchName))
                {
                    Console.WriteLine(line);
                    return line.Split(',')[2];
                }
            }

            return "";
        }
        private static void AddRecord(string filePath, int id, string fname, string lname, string dateOfBirth)
        {
            try
            {

                using (StreamWriter file = new StreamWriter(@filePath, true))
                {
                    file.WriteLine(id + "," + fname + "," + lname + "," + dateOfBirth);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public static void Replace(string filePath,  string fname)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(System.IO.File.OpenRead(filePath)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(","))
                    {
                        string[] split = line.Split(',');

                        if (split[1] == fname)
                        {
                            split[1] = "Yasser";
                            line = string.Join(",", split);
                            lines.Add(line);
                        }
                    }

                }
            }

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }
        }

    }



}
