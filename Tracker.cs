public sealed class Tracker
{
    public string SerialNumber { get; }

    public Tracker(string serialNumber)
    {
        SerialNumber = string.IsNullOrWhiteSpace(serialNumber)
            ? throw new ArgumentException("Número de série obrigatório")
            : serialNumber;
    }

}