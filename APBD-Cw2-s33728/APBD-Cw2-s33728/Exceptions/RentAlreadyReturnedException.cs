namespace APBD_Cw2_s33728.Exceptions;

public class RentAlreadyReturnedException(int rentId) : RentException($"Rent {rentId} was already returned.");