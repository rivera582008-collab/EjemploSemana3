public static class Funciones
{

    public static int ValidarNumerosEnteros(string mensaje,int DebeSerMayorOIgualA = int.MinValue,int DebeSerMenorOIgualA = int.MaxValue)
    {
        int entrada = 0;
        bool DatoCorrecto = false;

        while (!DatoCorrecto)
        {   
            Console.WriteLine(new string ('_',40));
            Console.Write(mensaje);
            string? eleccion = Console.ReadLine();
            Console.WriteLine(new string ('_',40));
            if (int.TryParse(eleccion, out entrada))
            {
                if (entrada >= DebeSerMayorOIgualA && entrada <= DebeSerMenorOIgualA)
                {
                    DatoCorrecto = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                        // Pusieron Ambos limites
                    if (DebeSerMayorOIgualA != int.MinValue && DebeSerMenorOIgualA != int.MaxValue)
                    {
                        Console.WriteLine($"Cantidad Invalida El Valor Debe Estar Entre {DebeSerMayorOIgualA} y {DebeSerMenorOIgualA}. Intenta De Nuevo");    
                    }
                        // Pusieron solo el limite minimo
                    else if (DebeSerMayorOIgualA != int.MinValue && DebeSerMenorOIgualA == int.MaxValue)
                    {
                        Console.WriteLine($"Cantidad Invalida El Valor Debe Ser Mayor O Igual {DebeSerMayorOIgualA}. Intenta De Nuevo");    
                    }
                        // Solo pusieron el limite máximo
                    else if (DebeSerMayorOIgualA == int.MinValue && DebeSerMenorOIgualA != int.MaxValue)
                    {
                        Console.WriteLine($"Cantidad Invalida El Valor Debe Ser Menor O Igual {DebeSerMenorOIgualA}. Intenta De Nuevo");   
                    }
                    else
                    {
                        Console.WriteLine("El Número Ingresado Esta Fuera Del Rango Permitido.Intentalo De Nuevo");
                    }    
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
        return entrada;
    }

    // Evita que deje el campo vacio

    public static string LeerTextoQueNoQuedeVacio(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();

            // Validar que no quede vacio
            if (!string.IsNullOrWhiteSpace(entrada))
            {
                return entrada;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Este Campo No Puede Quedar Vacio.");
            Console.ResetColor();
        }
    }

    public static string LeerSoloLetras(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Este Campo No Puede Quedar Vacio.");
                Console.ResetColor();
                continue;
            }

            bool EsValido = true;

            foreach (char caracter in entrada)
            {
                // validacion para ver si es una letra o un espacio de nombre como "juan carlos"
                if (!char.IsLetter(caracter) && caracter != ' ')
                {
                    EsValido = false;
                    break;
                }
            }
            if (EsValido)
            {
                return entrada;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: No Se Permiten Números Ni Simbolos. Ingrese Solo Letras");
            Console.ResetColor();
        }
    }

    // Casos Del Switch del menu principal
    // Caso 1
    public static void RegistrarMascotas(List<MascotaEspacial> mascotas)
    {
        System.Console.WriteLine("¿Qué Criatura Deseas Registrar?");
        Console.WriteLine(new string ('-',40));
        System.Console.WriteLine("1.Zorgon Flotante");
        Console.WriteLine(new string ('-',40));
        System.Console.WriteLine("2.Gato De Fuego");
        System.Console.Write("Selecciona Una Opción: ");
        string? opcion = Console.ReadLine();
        Console.WriteLine(new string ('-',40));
        bool D = true;
        while(D)
        {

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingresa El Nombre De Tu Mascota: ");
                    string? nombre = Console.ReadLine();
                    Console.WriteLine(new string ('-',40));

                    System.Console.Write("Ingresa El Planeta De Origen: ");
                    string? planeta = Console.ReadLine();

                    int altitud = ValidarNumerosEnteros("Ingresa La Altitud Del Vuelo: ",1,200);

                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("Registro Almacenado Con Éxito");
                    Console.ResetColor();

                    ZorgonFlotante zorgon = new ZorgonFlotante(nombre!,planeta!,altitud);
                    mascotas.Add(zorgon);  

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
                    Console.ReadKey(true);
                    Console.ResetColor();
                    D = false;
                    break;
                case "2":
                    Console.Write("Ingresa El Nombre De Tu Mascota: ");
                    string? nombre2 = Console.ReadLine();
                    Console.WriteLine(new string ('-',40));

                    System.Console.Write("Ingresa El Planeta De Origen: ");
                    string? planeta2 = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine("Registro Almacenado Con Éxito");
                    Console.ResetColor();

                    GatoFuego gato = new GatoFuego(nombre2!,planeta2!);
                    mascotas.Add(gato); 

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
                    Console.ReadKey(true);
                    Console.ResetColor();
                    D = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Error: Ingrese Una Opcion Valida");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
                    Console.ReadKey(true);
                    Console.ResetColor();
                    break;
            }
            
        }
        
    }

    // Caso 2...
    public static void AlimentarATodos(List<MascotaEspacial> mascotas)
    {
        foreach (MascotaEspacial m in mascotas)
        {
            m.Alimentar();
            Console.WriteLine(new string ('-',40));
        }
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
        Console.ReadKey(true);
        Console.ResetColor();
    }

    // Caso 3..

    public static void HacerSonido(List<MascotaEspacial> mascotas)
    {
        foreach (MascotaEspacial m in mascotas)
        {
            m.EmitirSonido();
            Console.WriteLine(new string ('-',40));
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
        Console.ReadKey(true);
        Console.ResetColor();
    }

    // Caso 4....

    public static void AlimentarAUnaEnEspecifico(List<MascotaEspacial> mascotas)
    {
        if (mascotas.Count == 0)
        {
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("El Refugio Esta Vacío.¡Registra Una Mascota!");
            Console.ResetColor();
            System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
            Console.ReadKey(true);
            return;
        }
        System.Console.WriteLine("\n---- SELECCIONA LA MASCOTA A ALIMENTAR ---");

        for (int i= 0; i < mascotas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {mascotas[i].Nombre}\nOrigen: {mascotas[i].PlanetaOrigen}");
            Console.WriteLine(new string ('-',40));
            
        }

        int seleccion = ValidarNumerosEnteros("Elige El Número De La Mascota: ",1,mascotas.Count);

        MascotaEspacial mascotaElegida = mascotas[seleccion - 1];

        Console.WriteLine($"Has Seleccionado a {mascotaElegida.Nombre}");
        mascotaElegida.Alimentar();
        Console.WriteLine(new string ('-',40));
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
        Console.ReadKey(true);
        Console.ResetColor();
     
    }

    // Caso 5....

    public static void MostrarEstado(List<MascotaEspacial> mascotas)
    {
        foreach (MascotaEspacial m in mascotas)
        {
            m.MostrarEstado();
            Console.WriteLine(new string ('-',40));
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
        Console.ReadKey(true);
        Console.ResetColor();
    }

    // Caso 6..

    public static void Salir(string nombre)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine($"............Hasta Pronto {nombre}................");
        Console.ResetColor();
    }

    // funcion del por defecto

    public static void Default()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Error: Ingrese Una Opcion Valida");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("Presiona Cualquier Letra Para Continuar....");
        Console.ReadKey(true);
        Console.ResetColor();
    }
}