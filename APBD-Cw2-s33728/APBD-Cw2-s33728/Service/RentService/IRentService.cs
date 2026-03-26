using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Service.RentService;

public interface IRentService
{
    void Rent(User user, Equipment equipment, int days);
    int Return(int rentId);
    int ForceReturnWithAdditionalDays(int rentId, int days);

    List<IRent> GetUserRents(User user);
    List<IRent> GetActiveRents();
    List<IRent> GetOverdueRents();
    List<IRent> GetAll();
}