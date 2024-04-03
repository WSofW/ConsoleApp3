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
        // Arrange
        string[] input = { "8", "45", "25", "9" }; // Ввод корректных баллов для каждого задания

        // Act
        using (StringReader sr = new StringReader(string.Join(Environment.NewLine, input)))
        {
            Console.SetIn(sr);
            Program.ExamGrading();
        }

        // Assert
        string actualOutput = _consoleOutput.ToString().Trim();
        Assert.IsTrue(actualOutput.Contains("Сумма набранных баллов: 87"));
        Assert.IsTrue(actualOutput.Contains("Оценка: 5 (Отлично)"));
    }

    [TestMethod]
    public void ExamGrading_Negative()
    {
        // Arrange
        string[] input = { "-5", "55", "35", "12" }; // Ввод некорректных баллов для каждого задания

        // Act
        using (StringReader sr = new StringReader(string.Join(Environment.NewLine, input)))
        {
            Console.SetIn(sr);
            Program.ExamGrading();
        }

        // Assert
        string actualOutput = _consoleOutput.ToString().Trim();
        Assert.IsTrue(actualOutput.Contains("Сумма набранных баллов: 0"));
        Assert.IsTrue(actualOutput.Contains("Оценка: Некорректная сумма баллов"));
    }
}
