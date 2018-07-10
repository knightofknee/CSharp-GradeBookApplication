using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            List<double> GradeList = new List<double>();
            //double TotalPoints = 0;
            //int counter = 0;
            foreach (var student in Students)
            {
                GradeList.Add(student.AverageGrade);
                //foreach (var grade in student.Grades)
                //{
                //    TotalPoints += grade;
                //    counter++;
                //}
            }
            GradeList.Add(averageGrade);
            GradeList.Sort();
            Predicate<double> finder = (double d) => { return d == averageGrade; }; 
            int index = GradeList.FindIndex(finder);
            double comparisonAverage = (double)index / GradeList.Count;

            //double classAverage = TotalPoints / counter;
            if (comparisonAverage > 0.8) return 'A';
            if (comparisonAverage > 0.6) return 'B';
            if (comparisonAverage > 0.4) return 'C';
            if (comparisonAverage > 0.2) return 'D';
            return 'F';
        }
    }
}
