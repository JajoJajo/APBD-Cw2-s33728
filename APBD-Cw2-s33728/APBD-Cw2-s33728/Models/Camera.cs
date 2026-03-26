namespace APBD_Cw2_s33728.Models;

public class Camera(string name, int resolution, bool hasVideo) : Equipment(name)
{
    public int ResolutionMp { get; set; } = resolution;
    public bool HasVideo { get; set; } = hasVideo;
}