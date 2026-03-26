namespace APBD_Cw2_s33728.Exceptions;

public class TooManyRentedException(int current, int max) : RentException($"User has {current} active rents. Max allowed is {max}.");