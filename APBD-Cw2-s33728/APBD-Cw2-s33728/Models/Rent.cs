using System;
using APBD_Cw2_s33728.Exceptions;
using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Models;

public class Rent : IRent
{
    private static int _idCounter = 1;

    public int Id { get; }
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime StartDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }

    public bool IsReturned => ReturnDate.HasValue;
    public void Return()
    {
        if (IsReturned)
            throw new RentAlreadyReturnedException(Id);
        ReturnDate = DateTime.Now;
    }

    public bool IsLate()
    {
        return IsReturned && ReturnDate > DueDate;
    }

    public Rent(User user, Equipment equipment, int days)
    {
        Id = _idCounter++;
        User = user;
        Equipment = equipment;
        StartDate = DateTime.Now;
        DueDate = StartDate.AddDays(days);
    }
    
    public void ForceReturnWithAdditionalDays(int days)
    {
        if (IsReturned)
            throw new RentAlreadyReturnedException(Id);
        ReturnDate = DateTime.Now.AddDays(days);
    }
}