using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("==== TESTES DE VEÍCULO / Placa / RASTREADOR ====");

        // 1. Criar entidade raiz com dependente 1:1 válido -> deve instanciar
        try
        {
            var licensePlate = new LicensePlate("ABC-1234");
            var vehicle = new Vehicle("Sedan", licensePlate);
            Console.WriteLine("Teste 1 OK ✅ -> Veículo criado com placa válida.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Teste 1 FALHOU ❌ -> {ex.Message}");
        }

        // 2. Tentar criar sem dependente 1:1 -> deve falhar
        try
        {
            var vehicleBad = new Vehicle("SUV", null!);
            Console.WriteLine("Teste 2 FALHOU ❌ -> Criou veículo sem placa!");
        }
        catch
        {
            Console.WriteLine("Teste 2 OK ✅ -> Não permitiu criar veículo sem placa.");
        }

        // 3. Atribuir dependente 0..1 uma vez -> deve funcionar
        try
        {
            var licensePlate = new LicensePlate("XYZ-9999");
            var vehicle = new Vehicle("Hatch", licensePlate);

            var tracker = new Tracker("R-001");
            bool attach = vehicle.AttachTracker(tracker);

            Console.WriteLine(attach
                ? "Teste 3 OK ✅ -> Rastreador atribuído com sucesso."
                : "Teste 3 FALHOU ❌ -> Não conseguiu atribuir rastreador válido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Teste 3 FALHOU ❌ -> {ex.Message}");
        }

        // 4. Atribuir 0..1 segunda vez -> deve falhar
        try
        {
            var licensePlate = new LicensePlate("LMN-4567");
            var vehicle = new Vehicle("Pickup", licensePlate);

            var r1 = new Tracker("R-101");
            var r2 = new Tracker("R-102");

            vehicle.AttachTracker(r1);
            bool attachBad = vehicle.AttachTracker(r2);

            Console.WriteLine(!attachBad
                ? "Teste 4 OK ✅ -> Impediu atribuição duplicada de rastreador."
                : "Teste 4 FALHOU ❌ -> Permitiu sobrescrever rastreador!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Teste 4 FALHOU ❌ -> {ex.Message}");
        }

        // 5. Remover 0..1 (se permitido) -> estado volta a null
        try
        {
            var licensePlate = new LicensePlate("QWE-2025");
            var vehicle = new Vehicle("SUV", licensePlate);

            var tracker = new Tracker("R-500");
            vehicle.AttachTracker(tracker);

            vehicle.DeleteTracker();

            Console.WriteLine(vehicle.Tracker == null
                ? "Teste 5 OK ✅ -> Rastreador removido e voltou a null."
                : "Teste 5 FALHOU ❌ -> Rastreador ainda está definido.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Teste 5 FALHOU ❌ -> {ex.Message}");
        }
    }
}
