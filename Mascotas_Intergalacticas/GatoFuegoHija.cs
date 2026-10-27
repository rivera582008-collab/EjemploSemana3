public class GatoFuego : MascotaEspacial
{
    public int TemperaturaCuerpo{get; set;}

    public GatoFuego(string nombre,string planeta) : base(nombre, planeta)
    {
        this.TemperaturaCuerpo = 100;
    }

    public override void Alimentar()
    {
        NivelEnergia += 10;
        this.TemperaturaCuerpo += 20;
        System.Console.WriteLine($"El Gato {this.Nombre} Come Comida Especial Y Su Teperatura Aumenta A {this.TemperaturaCuerpo}");

        if (this.NivelEnergia >= 100)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine($"🔥🔥¡CUIDADO! {this.Nombre} Llego A 100 De Energía Y Su Cuerpo Se Rodea Con Un Fuego Azul🔥🔥");
            Console.ResetColor();
            NivelEnergia = 50;
        }
    }

    public override void EmitirSonido()
    {
        System.Console.WriteLine($"¡Miau Miau Miau! El Gato {this.Nombre} Esta Conetnto");
    }

    public override void MostrarEstado()
    {
        Console.WriteLine($"Mascota: {this.Nombre}\nPlaneta De Origen: {this.PlanetaOrigen}\nEnergia: {this.NivelEnergia}\nTemperatura Del Cuerpo: {this.TemperaturaCuerpo}");
    }
}