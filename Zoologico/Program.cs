List<Animal> lista = new List<Animal>();

lista.Add(new DragonAbisal("Morongo","Jupiter",260));
lista.Add(new SmileEspacial("Roky","Venus",8));
bool Salir = false;

Console.WriteLine(new string ('=',60));
System.Console.WriteLine();
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("🌌🌌 BIENVENIDO Al REFUGIO INTERGALÁCTICO 🌌🌌");
Console.ResetColor();
System.Console.WriteLine();
Console.WriteLine(new string ('=',60));
Console.Write("Para Comenzar Ingresa Tu Nombre: ");
string? nombre = Console.ReadLine();
Console.WriteLine(new string ('-',40));

while (!Salir)
{
    Console.Clear();

    Console.WriteLine(new string ('=',60));
    System.Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("🌌🌌 BIENVENIDO Al REFUGIO INTERGALÁCTICO 🌌🌌");
    Console.ResetColor();
    System.Console.WriteLine();


    Console.WriteLine(new string ('*',40));
    Console.WriteLine("¿Qué Deseas Hacer Ahorita?\n---------------------------------------\n1.Registrar Una Nueva Criatura\n---------------------------------------\n2.Ver Estado De Las Criaturas\n---------------------------------------\n3.Hacer Que Las Criaturas Emitan Sonidos\n---------------------------------------\n4.Alimentar A Las Criaturas\n---------------------------------------\n5.Alimentar A Toda Las Mascotas\n---------------------------------------\n6.Salir");
    Console.WriteLine(new string ('_',40));
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{nombre} Selecciona Una Opción: ");
    Console.ResetColor();
    string? opcion = Console.ReadLine();
    Console.WriteLine(new string ('*',40));

    switch (opcion)
    {
        case "1":
           GenerarMascotas();
           break;
        
        case "2":
           EstadoDeMascotas();
            break;
        case "3":
            HacerSonido();
            break;

        case "4":
            AlimentarCriaturas();
            break;

        case "5":
            AlimentarTodasLasCriaturas();
            break;

        case "6":

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($".........Hasta Pronto {nombre}.........");
            Console.ResetColor();
            Console.WriteLine(new string ('_',40));
            Salir = true;
            break;

        default:

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ingrese Un Número Valido Entre 1 y 5");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
            Console.ResetColor();
            Console.ReadKey(true);
            break;
    }
}


void GenerarMascotas()
{
    Console.WriteLine(new string ('_',40));
    Console.WriteLine("¿Qué Criatura Desea Registar?\n1.Smile\n---------------------\n2.Dragón\n---------------------");
    System.Console.Write("Selecciona Una Opción: ");
    string? criatura = Console.ReadLine();
    Console.WriteLine(new string ('_',40));

        switch (criatura)
        {
            case "1":
                Console.WriteLine(new string ('_',40));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingresa El Nombre De Tu Smile: ");
                Console.ResetColor();
                string? smile = Console.ReadLine();
                Console.WriteLine(new string ('_',40));

                Console.WriteLine(new string ('_',40));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Ingresa El Planeta De Origen: ");
                Console.ResetColor();
                string? planeta = Console.ReadLine();
                Console.WriteLine(new string ('_',40));

                int ViscosidadValida = 0;
                bool DatoCorrecto = false;

                while (!DatoCorrecto)
                {   
                    Console.WriteLine(new string ('_',40));
                    Console.Write("Ingrese El Nivel De Viscosidad Del Slime Entre (1 y 10): ");
                    string? viscosidad1 = Console.ReadLine();
                    Console.WriteLine(new string ('_',40));
                    if (int.TryParse(viscosidad1, out ViscosidadValida))
                    {
                      if (ViscosidadValida >= 1 && ViscosidadValida <= 10)
                        {
                            DatoCorrecto = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cantidad Invalida La Viscosidad Debe Ser Entre 1 y 10. Intenta De Nuevo");
                            Console.ResetColor();
                        }

                   }
                    else
                    {
                       Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por Favor Ingrese Un Número Entero. Intentalo De Nuevo");
                        Console.ResetColor();
                    }
                }

                SmileEspacial smileEspacial = new SmileEspacial(smile!,planeta!,ViscosidadValida);
                lista.Add(smileEspacial); 
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Registro Almacenado Con Éxito");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
                Console.ResetColor();
                Console.ReadKey(true);    
                break;

            case "2":
                Console.WriteLine(new string ('_',40));
                Console.Write("Ingresa El Nombre De Tu Dragón: ");
                string? dragon = Console.ReadLine();
                Console.WriteLine(new string ('_',40));
                   
                Console.WriteLine(new string ('_',40));
                Console.Write("Ingresa El Planeta De Origen: ");
                string? planeta2 = Console.ReadLine();
                Console.WriteLine(new string ('_',40));

                double fuego = 0;
                bool DatoCorrecto2 = false;

                while (!DatoCorrecto2)
                {
                    Console.WriteLine(new string ('_',40));
                    Console.Write("Ingrese El Nivel De Fuego Del Dragón: ");
                    string? viscosidad1 = Console.ReadLine();
                    Console.WriteLine(new string ('_',40));

                    if (double.TryParse(viscosidad1, out fuego))
                    {
                        if (fuego >= 1 && fuego <= 400)
                        {
                            DatoCorrecto2 = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Cantidad Invalida El Nivel De Fuego Debe Ser Debe Entre 1 y 400. Intenta De Nuevo");
                            Console.ResetColor();
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por Favor Ingrese Un Número Válido. Intentalo De Nuevo");
                        Console.ResetColor();
                    }
                }

                DragonAbisal dragonAbisal = new DragonAbisal(dragon!,planeta2!,fuego);
                lista.Add(dragonAbisal); 
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Registro Almacenado Con Éxito");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
                Console.ResetColor();
                Console.ReadKey(true);
                break;

            default:

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ingrese Un Número Valido Entre 1 y 2");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
                Console.ResetColor();
                Console.ReadKey(true);
                break;

            }
}

void EstadoDeMascotas()
{
    foreach (Animal a in lista)
    {
        Console.WriteLine(a.MostrarEstado());
        Console.WriteLine(new string ('*',40));
            
    }
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
    Console.ResetColor();
    Console.ReadKey(true);
}

void HacerSonido()
{
    foreach (Animal an in lista)
    {
        Console.WriteLine(an.Hacer_Sonido());
        Console.WriteLine(new string ('*',40));
    }
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
    Console.ResetColor();
    Console.ReadKey(true);
}

void AlimentarCriaturas()
{
    int alimentarvalida = 0;
    bool DatoCorrecto4 = false;

    while (!DatoCorrecto4)
    {
        Console.Write("¿A Quién Desea Alimentar?\n--------------------------------\n1.Flubber (Smile)\n-----------------------\n2.Sparky (Dragón): ");
        string? alimento = Console.ReadLine();
        Console.WriteLine(new string ('_',40));

        if (int.TryParse(alimento, out alimentarvalida))
        {
            if (alimentarvalida >= 1 && alimentarvalida <= 2)
            {
                DatoCorrecto4 = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cantidad Invalida Ingrese 1 o 2. Intenta De Nuevo");
                Console.ResetColor();
            }

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Por Favor Ingrese Un Número Entero. Intentalo De Nuevo");
            Console.ResetColor();
        }
    }

    if(alimentarvalida == 1)
    {
        SmileEspacial smileespacial = new SmileEspacial("Flubber","Marte",6);
        Console.WriteLine(smileespacial.Alimentar());
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
        Console.ResetColor();
        Console.ReadKey(true);
    }
    else
    {
        DragonAbisal d = new DragonAbisal("Sparky","Saturno",200.90);
        Console.WriteLine(d.Alimentar());
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
        Console.ResetColor();
        Console.ReadKey(true);
             
    }
}

void AlimentarTodasLasCriaturas()
{
    foreach(Animal ani in lista)
        {
            Console.WriteLine(ani.Alimentar());
            Console.WriteLine(new string ('_',40));
                
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Presiona Cualquier Tecla Para Continuar....");
        Console.ResetColor();
        Console.ReadKey(true);
}

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
        return $"El Smile Come Desechos Rdioactivos";
    }

    public override string MostrarEstado()
    {
        return $"Smile: {this.Nombre}\nPlaneta De Origen: {this.PlanetaOrigen}\nNivel De Energia: {this.NivelEnergia}\nNivel De Viscosidad: {this.Viscosidad}";
    }

}

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
        return $"El Dragón Come Carne De Meteórito";
    }

    public override string MostrarEstado()
    {
        return $"Dragón: {this.Nombre}\nPlaneta De Origen: {this.PlanetaOrigen}\nNivel De Energia: {this.NivelEnergia}\nTemperatura De Su Fuego: {this.TemperaturaFuego}";
    }
}