using SmartHomeMaster.Data;

namespace SmartHomeMaster;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        try
        {
            Database.Initialize();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Не удалось инициализировать базу данных:\n" + ex.Message,
                "SmartHome Master Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}
