using SandriasDeliciousConcept.Contracts;

namespace SandriasDeliciousConcept.UI;

public class AppServices
{
    public required IEventBus Bus { get; init; }
    public required IUserService Users { get; init; }
    public required IItemCatalog Catalog { get; init; }
    public required IRequisitionService Requisition { get; init; }

    // Teammates: add IInventoryService Inventory, IPurchasingService Purchasing,
    // and IDeliveryService Delivery here when your module is ready.
}