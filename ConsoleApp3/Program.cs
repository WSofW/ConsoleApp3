using System;

public class Program
{
    static void Main(string[] args)
    {
        ExamGrading();
    }

    public static void ExamGrading()
    {
        int[] maxPoints = { 10, 50, 30, 10 };
        int totalPoints = 0;

        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Введите количество баллов за задание {i + 1}: ");
            int points;
            if (int.TryParse(Console.ReadLine(), out points))
            {
                if (points >= 0 && points <= maxPoints[i])
                {
                    totalPoints += points;
                }
                else
                {
                    Console.WriteLine($"Некорректное количество баллов. Введите значение от 0 до {maxPoints[i]}.");
                    i--;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                i--;
            }
        }

        Console.WriteLine($"Сумма набранных баллов: {totalPoints}");

        int grade;
        if (totalPoints >= 70 && totalPoints <= 100)
        {
            grade = 5;
        }
        else if (totalPoints >= 40 && totalPoints <= 69)
        {
            grade = 4;
        }
        else if (totalPoints >= 20 && totalPoints <= 39)
        {
            grade = 3;
        }
        else if (totalPoints >= 0 && totalPoints <= 19)
        {
            grade = 2;
        }
        else
        {
            grade = -1;
        }

        switch (grade)
        {
            case 5:
                Console.WriteLine("Оценка: 5 (Отлично)");
                break;
            case 4:
                Console.WriteLine("Оценка: 4 (Хорошо)");
                break;
            case 3:
                Console.WriteLine("Оценка: 3 (Удовлетворительно)");
                break;
            case 2:
                Console.WriteLine("Оценка: 2 (Неудовлетворительно)");
                break;
            default:
                Console.WriteLine("Некорректная сумма баллов.");
                break;
        }

        Console.ReadLine();
    }
}
