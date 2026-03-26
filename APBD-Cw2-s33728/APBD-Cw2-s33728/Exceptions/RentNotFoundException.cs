namespace APBD_Cw2_s33728.Exceptions;

public class RentNotFoundException(int rentId) : RentException($"Rent with ID {rentId} was not found.");