namespace Zoo
{
    public class SmileEspacial : Animal
    {
        public int Viscosidad{get; private set;}

        public SmileEspacial(string nombre,string planeta,int viscosidad) : base(nombre, planeta)
        {
            this.Viscosidad = viscosidad;

        }

        public override string Hacer_Sonido()
        {
            return $"!Glup Glup¡ El Smile: {this.Nombre} Salta En El Espacio Dividiendose En Dos Y Uniendose De Nuevo";
        }

        public override string Alimentar()
        {
            this.NivelEnergia += 15;

            if(this.Viscosidad < 10)

                this.Viscosidad += 1;
            else
            {
                Console.WriteLine("Su Smile Esta Lleno Si Lo Alimenta Mas Engordará");
            }
            return $"El Smile {this.Nombre} Come Desechos Rdioactivos";
        }

        public override string MostrarEstado()
        {
            return $"Smile: {this.Nombre}\nPlaneta De Origen: {this.PlanetaOrigen}\nNivel De Energia: {this.NivelEnergia}\nNivel De Viscosidad: {this.Viscosidad}";
        }

    }

}