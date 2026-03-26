using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Service.EquipmentService;

public interface IEquipmentService
{
    void Add(Equipment equipment);

    List<Equipment> GetAll();
    List<Equipment> GetAvailable();

    Equipment GetById(int id);

    void MarkUnavailable(int id);
}