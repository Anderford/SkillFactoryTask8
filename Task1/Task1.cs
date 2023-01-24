using System;
using System.IO;
using System.IO.Enumeration;
using static System.Net.WebRequestMethods;


namespace Task1
{
    class Task1
    {
        public static void Main(string[] args)
        {
            DeleteFiles();
        }

        static void DeleteFiles()
        {
            string DirName = @"C:\Users\Iliasheg\Desktop\TestFile";
            string[] Directroies = Directory.GetDirectories(DirName);
            string[] Files = Directory.GetFiles(DirName);
           
            try
            {
                DirectoryInfo DeleteDir = new DirectoryInfo(DirName);
                if (DeleteDir.Exists)
                {
                    foreach (var d in Directroies)
                    {
                        Console.WriteLine(d);
                    }

                    foreach (var s in Files)
                    {
                        Console.WriteLine(s);
                    }

                    foreach (DirectoryInfo Dir in DeleteDir.GetDirectories())
                    {
                        var LastEnter = Dir.LastAccessTime;
                        var DateNow = DateTime.Now;
                        var Duration = TimeSpan.FromMinutes(30);
                        var Duration30 = DateNow - LastEnter;
                        if (Duration30 >= Duration)
                        {
                            Dir.Delete(true);
                        }
                        else
                        {
                            Console.WriteLine("Нет папок которые можно удалить");
                        }
                    }
                    foreach (FileInfo File in DeleteDir.GetFiles())
                    {
                        var LastEnter = File.LastAccessTime;
                        var DateNow = DateTime.Now;
                        var Duration = TimeSpan.FromMinutes(30);
                        var Duration30 = DateNow - LastEnter;

                        if (Duration30 >= Duration)
                        {
                            File.Delete();
                        }
                        else
                        {
                            Console.WriteLine("Нет файлов которые можно удалить");
                        }
                    }

                }
            }
            catch (Exception ex)
{
                Console.WriteLine(ex.Message);
            }

        }
    } 
}