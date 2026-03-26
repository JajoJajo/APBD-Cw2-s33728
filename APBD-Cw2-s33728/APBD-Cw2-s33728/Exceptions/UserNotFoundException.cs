namespace APBD_Cw2_s33728.Exceptions;

public class UserNotFoundException(int userId) : RentException($"User with ID {userId} was not found.");