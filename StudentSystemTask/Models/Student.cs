using System;
using System.Collections.Generic;

namespace Models
{
    public class Student
    {
        public Student()
        {
            _no++;
            No = _no;
        }

        private static int _no;

        public int No { get; set; }
        public string FullName { get; set; }

        public Dictionary<string, double> Exams = new Dictionary<string, double>();

        public void AddExam(string examName, double point)
        {
            Exams.Add(examName, point);
        }

        public double GetExamResult(string examName)
        {
            foreach (var item in Exams)
            {
                if(item.Key == examName)
                {
                    return item.Value;
                }
            }
            return -1;
        }

        public double GetExamAvg()
        {
            double sum = 0;
            int count = 0;
            foreach (var item in Exams)
            {
                sum += item.Value;
                count++;
            }
            return sum / count;
        }
    }
}
