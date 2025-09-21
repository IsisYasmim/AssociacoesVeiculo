public sealed class Vehicle
{
    public string Model { get; }
    public LicensePlate LicensePlate { get; } // 1:1 obrigatório
    public Tracker? Tracker { get; private set; } // 0..1 opcional

    public Vehicle(string model, LicensePlate licensePlate)
    {
        Model = string.IsNullOrWhiteSpace(model)
            ? throw new ArgumentException("Modelo obrigatório")
            : model;

        LicensePlate = licensePlate ?? throw new ArgumentNullException(nameof(licensePlate));
    }

    public bool AttachTracker(Tracker tracker)
    {
        if (tracker is null) return false;
        if (Tracker != null) return false; // não sobrescreve

        Tracker = tracker;
        return true;
    }

    public void DeleteTracker() => Tracker = null;
}