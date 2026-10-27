bool Continuar = true;

while (Continuar){

    Console.Clear();

    Console.WriteLine(new string ('*',60));
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("👋👋Bienvenido Al Sistema De Alquiler De Vehiculos👋👋");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine(new string ('*',60));

    Console.WriteLine("¿Qué Tipo De Vehiculo Desea Alquilar?\n1.Autos\n2.Camiones\n3.Salir");
    Console.Write("Ingresa Tu Opción (1, 2 o 3): ");
    string? eleccion = Console.ReadLine();
    

    switch (eleccion){

        case "1":
    
            Console.Write("Ingresa El Número De Placa Del Auto: ");
            string? placa2 = Console.ReadLine();
            Console.WriteLine(new string ('-',40));

            Console.Write("Ingresa La Cantidad De Pasajeros: ");
            string? pasajeros = Console.ReadLine();
            int passanger = int.Parse(pasajeros!);
            Console.WriteLine(new string ('-',40));

            Auto auto = new Auto(placa2!,passanger);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Su Total A Pagar Es De: ${auto.CalcularPeaje()} Dólares");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.WriteLine(new string ('-',40));
            break;
        
        case "2":
        
            Console.Write("Ingrese El Numero De Placa Del Camión: ");
            string? placa = Console.ReadLine();
            Console.WriteLine(new string ('-',40));

            Console.Write("Ingrese La Cnatidad De Ejes De El Camión: ");
            string? ejes = Console.ReadLine();
            int ejesBuenos = int.Parse(ejes!);
            Console.WriteLine(new string ('-',40));

            Camion camion = new Camion(placa!,ejesBuenos);
            Console.WriteLine(new string ('-',40));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Su Total A Pagar Es De: ${camion.CalcularPeaje()} Dólares");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.WriteLine(new string ('-',40));
            break;

        case "3":
        
            Console.WriteLine(new string ('-',40));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hasta Pronto.....👋👋");
            Console.ResetColor();
            Continuar = false;
            Console.WriteLine(new string ('-',40));
            break;

        default:

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ingrese Una Cantidad Valida");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
            Console.ResetColor();
            Console.ReadKey(true);
            break;
    }
}

public class Vehiculo
{
    public string? Placa{get; private set;}
    public double TarifaBase{get; private set;}

    public Vehiculo(string placa)
    {
        this.Placa = placa;
        this.TarifaBase = 5.00;

    }

    public virtual double CalcularPeaje()
    {
        return this.TarifaBase;
    }
}

public class Auto : Vehiculo
{
    public int CantidadPasajeros{get; private set;}

    public Auto(string placa, int pasajeros) : base(placa)
    {
        this.CantidadPasajeros = pasajeros;
    }

    public override double CalcularPeaje()
    {

        if (this.CantidadPasajeros <= 0)
        {
            return this.CantidadPasajeros;
        }
        else if (this.CantidadPasajeros > 3)
        {
            double tarifa = this.TarifaBase * 0.80;
            return tarifa;
        }
        else
        {
            return this.TarifaBase;
        }
    }
}

public class Camion : Vehiculo
{
    public int CantidadEjes{get; private set;}

    public Camion(string placa,int cantidadaejes) : base(placa)
    {
        this.CantidadEjes = cantidadaejes;

    }

    public override double CalcularPeaje()
    {
        double Tarifa_Total = this.TarifaBase + (this.CantidadEjes * 2.00);
        return Tarifa_Total;
    }
}
