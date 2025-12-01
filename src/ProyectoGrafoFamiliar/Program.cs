using System;
using System.IO;
using System.Windows.Forms;
using ProyectoGrafoFamiliar.Datos;
using ProyectoGrafoFamiliar.Logica;
using ProyectoGrafoFamiliar.Presentacion;

static class Program
{
    private static readonly string LogDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
    private static readonly string LogFile = Path.Combine(LogDir, "startup.log");

    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            Directory.CreateDirectory(LogDir);


            Application.ThreadException += (s, e) => LogException(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                    LogException(ex);
                else
                    File.AppendAllText(LogFile, $"Unhandled exception object: {e.ExceptionObject}\n");
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new MenuForm());
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw;
        }
    }

    public static void LogException(Exception ex)
    {
        try
        {
            Directory.CreateDirectory(LogDir);
            var msg = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType()}: {ex.Message}\n{ex.StackTrace}\n";
            if (ex.InnerException != null)
                msg += $"Inner: {ex.InnerException.GetType()}: {ex.InnerException.Message}\n{ex.InnerException.StackTrace}\n";
            File.AppendAllText(LogFile, msg + "\n");
        }
        catch
        {
            
        }
    }
}

