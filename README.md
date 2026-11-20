# Sandria's Commissary System (SIA / DBMS project)

A Windows Forms (.NET 10) system with four modules: Requisition, Inventory, Purchasing, Delivery.

## Setup
1. Install Visual Studio 2026 with the .NET desktop workload and the "Data storage and processing" workload (for SQL Server LocalDB).
2. Clone the repo into a folder outside OneDrive, e.g. `C:\Dev\SandriasCommissary`.
3. Open `SandriasDeliciousConcept.slnx`, set `SandriasDeliciousConcept.UI` as the startup project, and press F5.
4. The database `SandriasCommissaryDb` is created automatically on first run from the scripts in `SandriasDeliciousConcept.Data/Scripts`.

## Demo accounts (school project only)
| Username | Password | Role |
|---|---|---|
| chef | chef123 | Chef |
| owner | owner123 | Owner |
| clerk | clerk123 | Inventory clerk |
| purchaser | purchaser123 | Purchaser |

## Rules for the team
- Modules reference only `Contracts` (and `Data` for the connection). **Modules never reference each other.**
- Talk to other modules through the interfaces in `Contracts.cs`, and through the `IEventBus` events (`RequisitionApproved`, `ShortageFound`).
- SQL script numbering: 001-009 shared, 010-019 Requisition, 020-029 Inventory, 030-039 Purchasing, 040-049 Delivery. Edit only your own range.
- Every script must be safe to run many times (`CREATE OR ALTER`, `IF NOT EXISTS`).
- Use stored procedures for all database access.
- Pull before you start working, commit small, and never commit `bin`, `obj`, or database files.

## How to add your module to the app
1. Implement your interface from `Contracts.cs` in your project.
2. Add your service to `AppServices.cs` and create it in `Program.cs`.
3. Replace the `ComingSoon(...)` line for your button in `MainMenuForm.cs` with your own form.
4. If you react to an event, subscribe in `Program.cs`, e.g. `bus.Subscribe<RequisitionApproved>(...)`.