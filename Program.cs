using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("==== SISTEMA DE GERENCIAMENTO DE VEÍCULOS ====");
        Console.WriteLine("Testes das associações 1:1 (Placa) e 0..1 (Rastreador)\n");
        
        TestVehicleCreationWithValidLicensePlate();
        TestVehicleCreationWithoutLicensePlate();
        TestAttachTrackerFirstTime();
        TestAttachTrackerSecondTime();
        TestRemoveTracker();
        
        Console.WriteLine("\n==== FIM DOS TESTES ====");
    }
    
    static void TestVehicleCreationWithValidLicensePlate()
    {
        Console.WriteLine("1. Criar veículo com placa válida (1:1)");
        
        try
        {
            var licensePlate = new LicensePlate("ABC-1234");
            var vehicle = new Vehicle("Sedan", licensePlate);
            
            Console.WriteLine($"✅ SUCESSO: Veículo {vehicle.Model} criado com placa {vehicle.LicensePlate.Number}");
            Console.WriteLine($"   Estado do rastreador: {(vehicle.Tracker == null ? "Não possui" : "Possui")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ FALHA: {ex.Message}");
        }
        Console.WriteLine();
    }
    
    static void TestVehicleCreationWithoutLicensePlate()
    {
        Console.WriteLine("2. Tentar criar veículo sem placa (1:1)");
        
        try
        {
            var vehicle = new Vehicle("SUV", null!);
            Console.WriteLine("❌ FALHA: Permitiu criar veículo sem placa!");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"✅ SUCESSO: Impediu criação - {ex.ParamName} não pode ser nulo");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✅ SUCESSO: Impediu criação - {ex.Message}");
        }
        Console.WriteLine();
    }
    
    static void TestAttachTrackerFirstTime()
    {
        Console.WriteLine("3. Atribuir rastreador pela primeira vez (0..1)");
        
        try
        {
            var licensePlate = new LicensePlate("XYZ-9999");
            var vehicle = new Vehicle("Hatch", licensePlate);
            var tracker = new Tracker("R-001");
            
            bool success = vehicle.AttachTracker(tracker);
            
            if (success)
            {
                Console.WriteLine($"✅ SUCESSO: Rastreador {vehicle.Tracker!.SerialNumber} atribuído");
                Console.WriteLine($"   Veículo agora possui rastreador: {vehicle.Tracker != null}");
            }
            else
            {
                Console.WriteLine("❌ FALHA: Não conseguiu atribuir rastreador válido");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ FALHA: {ex.Message}");
        }
        Console.WriteLine();
    }
    
    static void TestAttachTrackerSecondTime()
    {
        Console.WriteLine("4. Tentar atribuir segundo rastreador (0..1)");
        
        try
        {
            var licensePlate = new LicensePlate("LMN-4567");
            var vehicle = new Vehicle("Pickup", licensePlate);
            
            var tracker1 = new Tracker("R-101");
            var tracker2 = new Tracker("R-102");
            
            // Primeira atribuição deve funcionar
            vehicle.AttachTracker(tracker1);
            
            // Segunda atribuição deve falhar
            bool secondAttempt = vehicle.AttachTracker(tracker2);
            
            if (!secondAttempt)
            {
                Console.WriteLine("✅ SUCESSO: Impediu segunda atribuição de rastreador");
                Console.WriteLine($"   Rastreador atual mantido: {vehicle.Tracker!.SerialNumber}");
            }
            else
            {
                Console.WriteLine("❌ FALHA: Permitiu sobrescrever rastreador existente");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ FALHA: {ex.Message}");
        }
        Console.WriteLine();
    }
    
    static void TestRemoveTracker()
    {
        Console.WriteLine("5. Remover rastreador existente (0..1)");
        
        try
        {
            var licensePlate = new LicensePlate("QWE-2025");
            var vehicle = new Vehicle("SUV", licensePlate);
            var tracker = new Tracker("R-500");
            
            vehicle.AttachTracker(tracker);
            Console.WriteLine($"   Rastreador antes da remoção: {vehicle.Tracker!.SerialNumber}");
            
            vehicle.DeleteTracker();
            
            if (vehicle.Tracker == null)
            {
                Console.WriteLine("✅ SUCESSO: Rastreador removido corretamente");
                Console.WriteLine($"   Estado do rastreador: {(vehicle.Tracker == null ? "Não possui" : "Ainda possui")}");
            }
            else
            {
                Console.WriteLine("❌ FALHA: Rastreador não foi removido");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ FALHA: {ex.Message}");
        }
        Console.WriteLine();
    }
}