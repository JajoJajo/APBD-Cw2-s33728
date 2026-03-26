using APBD_Cw2_s33728.Exceptions;
using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Service.EquipmentService;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipment = [];
    
    public void Add(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAll()
    {
        return _equipment;
    }

    public List<Equipment> GetAvailable()
    {
        return _equipment.Where(e => e.IsAvailable).ToList();
    }

    public Equipment GetById(int id)
    {
        var equipment = _equipment.FirstOrDefault(e => e.Id == id);
        return equipment ?? throw new EquipmentNotFoundException(id);
    }

    public void MarkUnavailable(int id)
    {
        var equipment = GetById(id);
        equipment.MarkUnavailable();
    }
}