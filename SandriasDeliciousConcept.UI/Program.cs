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
        var services = new AppServices
        {
            Bus = bus,
            Users = new SqlUserService(),
            Catalog = new SqlItemCatalog(),
            Dishes = new SqlDishCatalog(),
            Requisition = new RequisitionService(bus)
        };

        while (true)
        {
            using var login = new LoginForm(services.Users);
            if (login.ShowDialog() != DialogResult.OK || login.LoggedInUser is null) break;

            using var menu = new MainMenuForm(login.LoggedInUser, services);
            menu.ShowDialog();
            if (!menu.LoggedOut) break;
        }
    }
}