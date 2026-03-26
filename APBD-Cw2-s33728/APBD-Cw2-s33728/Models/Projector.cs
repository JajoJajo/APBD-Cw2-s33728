namespace APBD_Cw2_s33728.Models;

public class Projector(string name, int brightness, bool isPortable) : Equipment(name)
{
    public int Lumens { get; set; } = brightness;
    public bool IsPortable { get; set; } = isPortable;
}