using SandriasDeliciousConcept.Contracts;
using SandriasDeliciousConcept.Data;
using SandriasDeliciousConcept.Requisition;

namespace SandriasDeliciousConcept.UI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
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