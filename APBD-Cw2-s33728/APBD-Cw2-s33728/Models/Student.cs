namespace APBD_Cw2_s33728.Models;

public class Student (string fName, string lName) : User(fName, lName)
{
    public override int GetMaxRentals() => 2;
}