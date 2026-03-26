namespace APBD_Cw2_s33728.Models;

public class Employee(string fName, string lName) : User(fName, lName)
{
    public override int GetMaxRentals() => 5;
}