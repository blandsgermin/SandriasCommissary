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

        var bus = new EventBus();
        IRequisitionService requisition = new RequisitionService(bus);
        IItemCatalog catalog = new SqlItemCatalog();

        // TEMPORARY until the login screen exists: change "Owner" to "Chef" to test each role
        var user = new CurrentUser("chef", "Chef", "Chef");

        Application.Run(new RequisitionListForm(requisition, catalog, user));
    }
}