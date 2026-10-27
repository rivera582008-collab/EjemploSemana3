namespace Zoo
{
    class DragonAbisal : Animal
    {
        public double TemperaturaFuego{get; set;}

        public DragonAbisal(string nombre, string planeta,double fuego) : base(nombre, planeta)
        {
            this.TemperaturaFuego = fuego;
        }

        public override string Hacer_Sonido()
        {
            
            if(this.TemperaturaFuego > 400)
            {
                Console.WriteLine($"Su Dragón Tiene El Máximo De Fuego Que Es De: {this.TemperaturaFuego}°C");
            }
            else
            {
                this.TemperaturaFuego += 60;
            }
            return $"!ROAAAAR ROAAAR¡ El Dragón: {this.Nombre} Escupe Fuego Azul Por Sus Fosas Nazales";
        }

        public override string Alimentar()
        {
            this.NivelEnergia += 30;

            if(this.TemperaturaFuego < 1)

                Console.WriteLine("Su Dragón No Puede Tener Fuego Negativo Por Lo Que Ya No Puede Comer Más");
            else
            {
                this.TemperaturaFuego -= 20;
            }
            return $"El Dragón {this.Nombre} Come Carne De Meteórito";
        }

        public override string MostrarEstado()
        {
            return $"Dragón: {this.Nombre}\nPlaneta De Origen: {this.PlanetaOrigen}\nNivel De Energia: {this.NivelEnergia}\nTemperatura De Su Fuego: {this.TemperaturaFuego}";
        }
    }
}