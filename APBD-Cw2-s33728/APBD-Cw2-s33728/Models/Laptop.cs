namespace APBD_Cw2_s33728.Models
{
    public class Laptop(string name, int storage, string cpu) : Equipment(name)
    {
        public int StorageGb { get; set; } = storage;
        public string Cpu { get; set; } = cpu;
    }
}