using APBD_Cw2_s33728.Service.EquipmentService;
using APBD_Cw2_s33728.Service.RentService;

namespace APBD_Cw2_s33728.Service.ReportService;

public class ReportService(IEquipmentService equipmentService, IRentService rentService) : IReportService
{
    private readonly IEquipmentService _equipmentService = equipmentService;
    private readonly IRentService _rentService = rentService;


    public string GenerateSummary()
    {
        var totalEquipment = _equipmentService.GetAll().Count;
        var availableEquipment = _equipmentService.GetAvailable().Count;
        var activeRents = _rentService.GetActiveRents().Count;
        var overdueRents = _rentService.GetOverdueRents().Count;

        return $"""
                ===== REPORT =====
                Total equipment: {totalEquipment}
                Available equipment: {availableEquipment}
                Active rents: {activeRents}
                Overdue rents: {overdueRents}
                """;
    }
}