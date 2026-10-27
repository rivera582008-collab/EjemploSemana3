namespace Zoo
{
    public class Animal
    {
        public string? Nombre{get; private set;}
        public int NivelEnergia{get; set;}
        public string? PlanetaOrigen{get; private set;}

        public Animal(string nombre,string planeta)
        {
            this.Nombre = nombre;
            this.PlanetaOrigen = planeta;
            this.NivelEnergia = 100;
        }

        public virtual string Hacer_Sonido()
        {
            return "Los Animales Hacen Sonidos Diferentes";
        }

        public virtual string Alimentar()
        {
            return "Los Animales Rstan Comiendo";
        }

        public virtual string MostrarEstado()
        {
            return "Estado De Las Mascotas";
        }

    }
}