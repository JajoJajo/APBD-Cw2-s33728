namespace APBD_Cw2_s33728.Exceptions;

public class EquipmentUnavailableException(int equipmentId)
    : RentException($"Equipment with ID {equipmentId} is unavailable.");