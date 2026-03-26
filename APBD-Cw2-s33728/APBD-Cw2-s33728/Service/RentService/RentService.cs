using APBD_Cw2_s33728.Exceptions;
using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Service.RentService;

public class RentService : IRentService
{
    private readonly List<IRent> _rents = [];

    public void Rent(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable)
            throw new EquipmentUnavailableException(equipment.Id);

        int activeRents = _rents.Count(rents => rents.User == user && !rents.IsReturned);

        if (activeRents >= user.GetMaxRentals())
        {
            throw new TooManyRentedException(activeRents, user.GetMaxRentals());
        }
        
        var rent = new Rent(user, equipment, days);
        _rents.Add(rent);
        
        equipment.MarkUnavailable();
    }

    public int Return(int rentId)
    {
        var rent = _rents.FirstOrDefault(r => r.Id == rentId);

        if (rent is null)
        {
            throw new RentNotFoundException(rentId);
        }
        rent.Return();
        rent.Equipment.MarkAvailable();
        return CalculatePenalty(rent);
    }
    
    public int ForceReturnWithAdditionalDays(int rentId, int days)
    {
        var rent = _rents.FirstOrDefault(r => r.Id == rentId);

        if (rent is null)
        {
            throw new RentNotFoundException(rentId);
        }
        rent.ForceReturnWithAdditionalDays(days);
        rent.Equipment.MarkAvailable();
        return CalculatePenalty(rent);
    }

    public List<IRent> GetUserRents(User user)
    {
        return _rents.Where(r => r.User == user && !r.IsReturned).ToList();
    }

    public List<IRent> GetActiveRents()
    {
        return _rents.Where(r => !r.IsReturned).ToList();
    }

    public List<IRent> GetOverdueRents()
    {
        return _rents.Where(r => !r.IsReturned && DateTime.Now > r.DueDate).ToList();
    }

    public List<IRent> GetAll()
    {
        return _rents;
    }

    private int CalculatePenalty(IRent rent)
    {
        if (!rent.IsLate())
            return 0;
        int daysLate = (rent.ReturnDate.Value - rent.DueDate).Days;

        return daysLate * 10;
    }
}