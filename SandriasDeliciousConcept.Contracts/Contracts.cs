using System;
using System.Collections.Generic;
using System.Text;

namespace SandriasDeliciousConcept.Contracts;

public enum RequisitionStatus { Pending, Approved, Returned, Cancelled, PendingFulfillment, Fulfilled }

public record RequisitionItemDto(int ItemId, string ItemName, string Unit, decimal Quantity);

public record RequisitionDto(
    int RfId, string RfNumber, DateTime RequestDate, string Requester,
    string? CustomerName, DateTime? EventDate, string? Venue, int? Pax, string? Menu,
    string Purpose, DateTime? RequiredDate, RequisitionStatus Status,
    IReadOnlyList<RequisitionItemDto> Items);

public record StockCheckResult(int ItemId, decimal Requested, decimal AvailableUnreserved)
{
    public decimal Shortage => Math.Max(0, Requested - AvailableUnreserved);
}

public interface IRequisitionService
{
    int Create(RequisitionDto rf);
    RequisitionDto? GetById(int rfId);
    IReadOnlyList<RequisitionDto> GetAll(RequisitionStatus? status = null);
    void Approve(int rfId, string approvedBy);
    void Return(int rfId, string reason);
    void Cancel(int rfId, string reason);
    void SetStatus(int rfId, RequisitionStatus status);
    void Update(RequisitionDto rf);   // for a returned or pending request
}

public interface IInventoryService
{
    IReadOnlyList<StockCheckResult> CheckAvailability(IEnumerable<RequisitionItemDto> items);
    void Reserve(int rfId, IEnumerable<RequisitionItemDto> items);
    void Deduct(int rfId);
}

public interface IPurchasingService
{
    int CreatePurchaseRequisition(int rfId, IEnumerable<StockCheckResult> shortages);
}

public interface IDeliveryService
{
    // To be defined by the Delivery owner
}

public record RequisitionApproved(int RfId);
public record ShortageFound(int RfId, IReadOnlyList<StockCheckResult> Shortages);

public interface IEventBus
{
    void Publish<T>(T evt);
    void Subscribe<T>(Action<T> handler);
}

public class EventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public void Subscribe<T>(Action<T> handler)
    {
        if (!_handlers.TryGetValue(typeof(T), out var list))
            _handlers[typeof(T)] = list = new List<Delegate>();
        list.Add(handler);
    }

    public void Publish<T>(T evt)
    {
        if (_handlers.TryGetValue(typeof(T), out var list))
            foreach (var h in list.ToList()) ((Action<T>)h)(evt);
    }
}
