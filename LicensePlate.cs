public sealed class LicensePlate
{
    public string Number { get; }

    public LicensePlate(string number)
    {
        Number = string.IsNullOrWhiteSpace(number)
            ? throw new ArgumentException("Placa obrigatória")
            : number;
    }
}