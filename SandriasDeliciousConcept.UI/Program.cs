using SandriasDeliciousConcept.Data;

namespace SandriasDeliciousConcept.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try { DatabaseInitializer.EnsureCreated(); }
            catch (Exception ex)
            {
                MessageBox.Show("Could not set up the database:\n" + ex.Message);
                return;
            }
            Application.Run(new Form1());
        }
    }
}