using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks;

public class RankedGradeBook : BaseGradeBook
{
    public RankedGradeBook(
        string name
    ) : base(name)
    {
        Type = GradeBookType.Ranked;
    }

    public override char GetLetterGrade(double averageGrade)
    {
        if(Students.Count < 5)
        {
            throw new InvalidOperationException();
        }

        var separatedCountStudents = (int)Math.Ceiling(Students.Count * 0.2);
        var studentGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

        if (averageGrade >= studentGrades[separatedCountStudents - 1])
            return 'A';
        if (averageGrade >= studentGrades[(separatedCountStudents * 2) - 1])
            return 'B';
        if (averageGrade >= studentGrades[(separatedCountStudents * 3) - 1])
            return 'C';
        if (averageGrade >= studentGrades[(separatedCountStudents * 4) - 1])
            return 'D';
        return 'F';
    }

    public override void CalculateStatistics()
    {
        if (Students.Count < 5)
        {
            Console.Write("Ranked grading requires at least 5 students.");
            return;
        }
        
        base.CalculateStatistics();
    }

    public override void CalculateStudentStatistics(string name)
    {
        if (Students.Count < 5)
        {
            Console.Write("Ranked grading requires at least 5 students.");
            return;
        }
        
        base.CalculateStudentStatistics(name);
    }
}