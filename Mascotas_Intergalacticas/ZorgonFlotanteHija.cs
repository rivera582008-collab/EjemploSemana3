public class ZorgonFlotante : MascotaEspacial
{
    public int AltitudVuelo{get; set;}

    public ZorgonFlotante(string nombre,string planeta,int altitud) : base(nombre, planeta)
    {
        this.AltitudVuelo = altitud;
    }

    public override void Alimentar()
    {
        this.NivelEnergia += 20;
        this.AltitudVuelo += 5;
        System.Console.WriteLine($"La Mascota {this.Nombre} Esta Comiendo Meteoritos");
    }
    public override void EmitirSonido()
    {
        System.Console.WriteLine($"¡Glup Glup Blup! El Pulpo {this.Nombre} Esta Feliz");
    }
    public override void MostrarEstado()
    {
        Console.WriteLine($"Mascota: {this.Nombre}\nPlaneta De Origen: {this.PlanetaOrigen}\nEnergia: {this.NivelEnergia}\nAltidud De Vuelo: {this.AltitudVuelo}");
    }
}