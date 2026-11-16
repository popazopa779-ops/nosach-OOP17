using System.Text;

namespace ExceptionsThrowLab;

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
        try
        {
            Console.WriteLine("--- SafeDivide(10, 2): успех -> результат и finally ---");
            double res1 = MathOperations.SafeDivide(10, 2);

            Console.WriteLine();
            Console.WriteLine("--- SafeDivide(5, 0): исключение -> перехват в catch и finally ---");
            double res2 = MathOperations.SafeDivide(5, 0);
            Console.WriteLine($"Возвращено значение: {res2} (результата нет)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Внешний перехват: {ex.Message}");
        }
    }

    private static void Task2()
    {
        var processor = new AccountProcessor();

        Console.WriteLine("--- (status 1, amount 500): ошибки нет ---");
        processor.ProcessTransaction(1, 500);

        Console.WriteLine();
        Console.WriteLine("--- (status 1, amount -5000): amount < -1000 -> первый catch с when ---");
        processor.ProcessTransaction(1, -5000);

        Console.WriteLine();
        Console.WriteLine("--- (status 1, amount -50): when ложно -> базовый catch диапазона ---");
        processor.ProcessTransaction(1, -50);

        Console.WriteLine();
        Console.WriteLine("--- (status -1, amount 100): другой тип исключения -> catch (Exception) ---");
        processor.ProcessTransaction(-1, 100);

        Console.WriteLine();
        Console.WriteLine("--- Демонстрация фильтров catch when (пример из задания) ---");
        int x = 0; int y = 1;
        try
        {
            int result1 = x / y;
            Console.WriteLine($"x / y = {result1}");
            int result2 = y / x; 
            Console.WriteLine($"y / x = {result2}");
        }
        catch (DivideByZeroException) when (y == 0)
        {
            Console.WriteLine("y не должен быть равен 0");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Обработано во втором catch: {ex.Message}");
        }
    }

    private static void Task3()
    {

        Console.WriteLine("--- RegisterUser(\"Anna\", 25): успешный сценарий ---");
        RunRegistration("Anna", 25);

        Console.WriteLine();
        Console.WriteLine("--- RegisterUser(\"A\", 25): имя короче 2 символов ---");
        RunRegistration("A", 25);

        Console.WriteLine();
        Console.WriteLine("--- RegisterUser(\"Anna\", 15): возраст меньше 18 ---");
        RunRegistration("Anna", 15);
    }

    private static void RunRegistration(string name, int age)
    {
        try
        {
            try
            {
                RegisterUser(name, age);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Локальный лог]: {ex.Message}");
                throw; 
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Глобальный лог]: {ex.StackTrace}");
        }
    }

    private static void RegisterUser(string name, int age)
    {
        if (name == null || name.Length < 2)
            throw new ArgumentException("Длина имени меньше 2 символов");

        if (age < 18)
            throw new ArgumentOutOfRangeException(nameof(age), age, "Возраст должен быть не меньше 18");

        Console.WriteLine($"Пользователь {name}, {age} лет, зарегистрирован");
    }
}
