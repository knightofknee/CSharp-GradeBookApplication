﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
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
            //GradeList.Add(averageGrade);
            GradeList.Sort();
            //Predicate<double> finder = (double d) => { return d == averageGrade; };
            List<double> newList = GradeList.FindAll(delegate(double score) { return score > averageGrade; });
            int studentsAhead = newList.Count;
            double comparisonAverage = (double)(Students.Count - studentsAhead) / Students.Count;

            //int index = GradeList.FindIndex(finder);
            //double comparisonAverage = (double)index / GradeList.Count;

            ////double classAverage = TotalPoints / counter;
            if (comparisonAverage > 0.8) return 'A';
            if (comparisonAverage > 0.6) return 'B';
            if (comparisonAverage > 0.4) return 'C';
            if (comparisonAverage > 0.2) return 'D';
            return 'F';
        }
        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
