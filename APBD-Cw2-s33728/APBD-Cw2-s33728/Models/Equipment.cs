namespace APBD_Cw2_s33728.Models
{
    public abstract class Equipment(string name)
    {
        private static int _nextId = 1;

        public int Id { get; } = _nextId++;
        public string Name { get; set; } = name;
        public bool IsAvailable { get; private set; } = true;

        public void MarkUnavailable() => IsAvailable = false;
        public void MarkAvailable() => IsAvailable = true;
    }
}