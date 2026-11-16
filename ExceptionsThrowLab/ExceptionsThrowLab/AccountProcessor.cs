namespace ExceptionsThrowLab;

public class AccountProcessor
{
    public void ProcessTransaction(int status, int amount)
    {
        try
        {
            if (status < 0)
                throw new InvalidOperationException($"Неизвестный статус транзакции: {status}");

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), amount, "Сумма не может быть отрицательной");

            Console.WriteLine($"Транзакция выполнена: статус {status}, сумма {amount}");
        }
        catch (ArgumentOutOfRangeException ex) when (amount < -1000)
        {
            Console.WriteLine("Критически недопустимая сумма!");
            Console.WriteLine($"  Сообщение: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Базовый обработчик ошибок диапазона аргументов: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Универсальный перехватчик: {ex.GetType().Name}: {ex.Message}");
        }
    }
}
