namespace APBD_Cw2_s33728.Exceptions;

public class EquipmentNotFoundException(int equipmentId) : RentException($"Equipment with ID {equipmentId} was not found.");