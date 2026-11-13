using System.Diagnostics;
using System.Text;

namespace ExceptionsLab;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Task1();
        Task2();
        Task3();

        Console.WriteLine();
        Console.WriteLine("Все демонстрационные сценарии выполнены.");
    }

    private static void Header(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 70));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 70));
    }

    private static void Task1()
    {
        Header("1");

        Console.WriteLine("Нормальные аргументы: SafeDivide(10, 2)");
        SafeDivide(10, 2);

        Console.WriteLine();
        Console.WriteLine("Ошибочные аргументы: SafeDivide(10, 0)");
        SafeDivide(10, 0);

        Console.WriteLine();
        Console.WriteLine("Ошибочные аргументы: SafeDivide(0, 0)");
        SafeDivide(0, 0);
    }

    private static void SafeDivide(int x, int y)
    {
        try
        {
            int result = x / y;
            Console.WriteLine($"Результат {x} / {y} = {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Ошибка деления на 0: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Операция деления завершена (блок finally)");
        }
    }

    private static void Task2()
    {
        Header("2");

        Console.WriteLine("ProcessTransaction(0, 0): attempts == 0, ожидается Фильтр 1");
        ProcessTransaction(0, 0);

        Console.WriteLine();
        Console.WriteLine("ProcessTransaction(-5, 3): errorCode < 0, ожидается Фильтр 2");
        ProcessTransaction(-5, 3);

        Console.WriteLine();
        Console.WriteLine("ProcessTransaction(10, 2): ни одно условие when, ожидается Общий catch");
        ProcessTransaction(10, 2);

        Console.WriteLine();
        Console.WriteLine("Анализ выбора CLR: блоки catch проверяются сверху вниз. Подходящим считается");
        Console.WriteLine("первый блок, у которого совпал тип исключения И условие when равно true.");
        Console.WriteLine("Для (0, 0) истинно attempts == 0, поэтому выбран Блок 1, хотя errorCode < 0 не проверяется.");
        Console.WriteLine("Для (-5, 3) первый фильтр ложен, второй истинен -> Блок 2.");
        Console.WriteLine("Для (10, 2) оба фильтра ложны -> Блок 3 (без when).");
    }

    private static void ProcessTransaction(int errorCode, int attempts)
    {
        int x = 1, y = 0;
        try
        {
            int res = x / y; 
            Console.WriteLine($"Результат: {res}");
        }
        catch (DivideByZeroException) when (attempts == 0)
        {
            Console.WriteLine("Фильтр 1: Попытки исчерпаны (attempts == 0)");
        }
        catch (DivideByZeroException ex) when (errorCode < 0)
        {
            Console.WriteLine($"Фильтр 2: Отрицательный код {errorCode}: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Общий catch: {ex.Message}");
        }
    }

    private static void Task3()
    {
        Header("3");

        Console.WriteLine("Вариант 1 (try-catch, накладный)");
        CalculateSquareTryCatch("abc");
        CalculateSquareTryCatch("15");

        Console.WriteLine();
        Console.WriteLine("Вариант 2 (TryParse, быстрый и оптимальный)");
        CalculateSquareTryParse("abc");
        CalculateSquareTryParse("15");

        Console.WriteLine();
        Console.WriteLine("Сравнительный тест производительности");
        const int iterations = 10_000;
        foreach (string input in new[] { "abc", "15" })
        {
            long tryCatchMs = Measure(() => ParseWithTryCatchSilent(input), iterations);
            long tryParseMs = Measure(() => ParseWithTryParseSilent(input), iterations);
            Console.WriteLine($"Строка \"{input}\", {iterations} итераций: try-catch = {tryCatchMs} мс, TryParse = {tryParseMs} мс");
        }

        Console.WriteLine();
        Console.WriteLine("Вывод: на некорректной строке 'abc' try-catch заметно медленнее, на валидной '15' разница минимальна.");
    }

    private static void CalculateSquareTryCatch(string data)
    {
        try
        {
            int val = int.Parse(data);
            Console.WriteLine($"Квадрат: {val * val}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректный формат числа");
        }
    }

    private static void CalculateSquareTryParse(string data)
    {
        if (int.TryParse(data, out int val))
            Console.WriteLine($"Квадрат: {val * val}");
        else
            Console.WriteLine("Некорректный ввод (без исключения)");
    }

    private static void ParseWithTryCatchSilent(string data)
    {
        try
        {
            int val = int.Parse(data);
            _ = val * val;
        }
        catch (FormatException)
        {
        }
    }

    private static void ParseWithTryParseSilent(string data)
    {
        if (int.TryParse(data, out int val))
            _ = val * val;
    }

    private static long Measure(Action action, int iterations)
    {
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
            action();
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
