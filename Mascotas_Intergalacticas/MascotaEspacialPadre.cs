public class MascotaEspacial
{
    public string? Nombre{get; private set;}
    public string? PlanetaOrigen{get; private set;}
    public int NivelEnergia{get; set;}

    public MascotaEspacial(string nombre, string planeta)
    {
        this.Nombre = nombre;
        this.PlanetaOrigen = planeta;
        this.NivelEnergia = 50;
    }

    public virtual void Alimentar()
    {
        this.NivelEnergia += 10;
        Console.WriteLine($"La Mascota {this.Nombre} Esta Comiendo....");
    }
    public virtual void EmitirSonido()
    {
        Console.WriteLine("Las Mascotas Hacen Sus Sonidos");
    }
    public virtual void MostrarEstado()
    {
        Console.WriteLine($"Mascota: {this.Nombre}\nPlaneta De Origen: {this.PlanetaOrigen}\nEnergia: {this.NivelEnergia}");
    }
}
