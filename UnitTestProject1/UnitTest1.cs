using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.RegularExpressions;

[TestClass]
public class ProgramTests
{
    private StringWriter _consoleOutput;

    [TestInitialize]
    public void Setup()
    {
        _consoleOutput = new StringWriter();
        Console.SetOut(_consoleOutput);
    }

    [TestCleanup]
    public void TearDown()
    {
        _consoleOutput.Dispose();
    }

    [TestMethod]
    public void ExamGrading_Positive()
    {
        string[] input = { "8", "45", "25", "9" }; 
        string expectedOutputPattern = @"^Сумма набранных баллов: 87\r?\nОценка: 5 \(Отлично\)$"; 

        using (StringReader sr = new StringReader(string.Join(Environment.NewLine, input)))
        {
            Console.SetIn(sr);
            Program.ExamGrading();
        }
        string actualOutput = _consoleOutput.ToString().Trim();
        Assert.IsTrue(Regex.IsMatch(actualOutput, expectedOutputPattern));
    }

    [TestMethod]
    public void ExamGrading_Negative()
    {
        string[] input = { "-5", "55", "35", "12" }; 
        string expectedOutputPattern = @"^Некорректное количество баллов\. Введите значение от 0 до \d+\.\r?\nНекорректное количество баллов\. Введите значение от 0 до \d+\.\r?\nСумма набранных баллов: 0\r?\nОценка: Некорректная сумма баллов\.$"; // Ожидаемый вывод

        using (StringReader sr = new StringReader(string.Join(Environment.NewLine, input)))
        {
            Console.SetIn(sr);
            Program.ExamGrading();
        }
        string actualOutput = _consoleOutput.ToString().Trim();
        Assert.IsTrue(Regex.IsMatch(actualOutput, expectedOutputPattern));
    }
}
