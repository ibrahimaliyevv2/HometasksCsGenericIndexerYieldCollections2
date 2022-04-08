using System;
using System.Collections.Generic;
using Models;

namespace StudentSystemTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            bool check = true;
            string strNo;
            int no;
            int choice;
            string fullName = " ";
            string examName = " ";
            string strExamPoint;
            double examPoint;

            do
            {
                Console.WriteLine($" 1. Telebe elave et \n 2. Telebeye imtahan elave et \n 3. Telebenin bir imtahan balina bax ");
                Console.WriteLine($" 4. Telebenin butun imtahanlarini goster \n 5. Telebenin imtahan ortalamasini goster \n 6. Telebeden imtahan sil ");
                Console.WriteLine($" 0. Proqrami bitir");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("Telebenin adini daxil edin:");
                            fullName = Console.ReadLine();

                        } while (String.IsNullOrWhiteSpace(fullName));

                        Student student = new Student
                        {
                            FullName = fullName
                        };

                        students.Add(student);
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("Telebenin nomresini daxil edin:");
                            strNo = Console.ReadLine();

                        } while (!int.TryParse(strNo, out no));

                        do
                        {
                            Console.WriteLine("Imtahanin adini daxil edin:");
                            examName = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(examName));

                        do
                        {
                            Console.WriteLine("Imtahan balini daxil edin:");
                            strExamPoint = Console.ReadLine();
                        } while (!double.TryParse(strExamPoint, out examPoint));

                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                item.AddExam(examName, examPoint);
                            }
                        }
                        break;

                    case 3:
                        do
                        {
                            Console.WriteLine("Telebenin nomresini daxil edin:");
                            strNo = Console.ReadLine();
                        } while (!int.TryParse(strNo, out no));

                        do
                        {
                            Console.WriteLine("Baxmaq ucun imtahanin adini daxil edin:");
                            examName = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(examName));

                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                Console.WriteLine($"Telebenin imtahan neticesi: {item.GetExamResult(examName)}");
                            }
                        }
                        break;

                    case 4:
                        do
                        {
                            Console.WriteLine("Telebenin nomresini daxil edin:");
                            strNo = Console.ReadLine();
                        } while (!int.TryParse(strNo, out no));

                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                foreach (var exam in item.Exams)
                                {
                                    Console.WriteLine($"Imtahan: {exam.Key}, Bal: {exam.Value}");
                                }
                            }
                        }
                        break;

                    case 5:
                        do
                        {
                            Console.WriteLine("Telebenin nomresini daxil edin:");
                            strNo = Console.ReadLine();
                        } while (!int.TryParse(strNo, out no));

                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                Console.WriteLine($"Telebenin imtahan ortalamasi: {item.GetExamAvg()}");
                            }
                        }
                        break;

                    case 6:
                        do
                        {
                            Console.WriteLine("Telebenin nomresini daxil edin:");
                            strNo = Console.ReadLine();
                        } while (!int.TryParse(strNo, out no));

                        do
                        {
                            Console.WriteLine("Hansi imtahani silmek isteyirsiniz?");
                            examName = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(examName));

                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                item.Exams.Remove(examName);
                            }
                        }
                        break;

                    case 0:
                        check = false;
                        break;

                    default:
                        Console.WriteLine("Daxil etdiyiniz deyer menyuda yoxdur!");
                        break;
                }
            } while (check);
        }
    }
}
