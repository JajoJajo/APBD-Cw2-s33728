using System;
using APBD_Cw2_s33728.Models;

namespace APBD_Cw2_s33728.Service;

public interface IRent
{
    int Id { get; }
    User User { get; }
    Equipment Equipment { get; }
    
    DateTime StartDate { get; }
    DateTime DueDate { get; }
    DateTime? ReturnDate { get; }
    
    bool IsReturned { get; }

    void Return();
    void ForceReturnWithAdditionalDays(int days);
    bool IsLate();
}