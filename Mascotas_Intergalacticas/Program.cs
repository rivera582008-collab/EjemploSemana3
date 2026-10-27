List<MascotaEspacial> mascotas = new List<MascotaEspacial>();
mascotas.Add(new ZorgonFlotante("Nexus","Jupiter",20));
mascotas.Add(new GatoFuego("Chispitas","Marte"));

string nombre = Funciones.LeerSoloLetras("Hola Para Entrar Al Sistema Ingresa Tu Nombre: ");
string Contra = "P1234P";
bool Validar = true;
while (Validar)
{
    string contraseña = Funciones.LeerTextoQueNoQuedeVacio("Ingresa Tu Contraseña: ");

    if(contraseña == Contra)
    {
        IniciarMenu(nombre);
        Validar = false;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Contraseña Incorrecta Intentalo De Nuevo.");
        Console.ResetColor();
    }
}
























void IniciarMenu(string nombre)
{
    bool dato = true;

    while (dato)
    {
        Console.Clear();
        System.Console.WriteLine(new string ('=',60));
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine();
        System.Console.WriteLine("   BIENVENIDO AL REFUGIO DE CRIATURAS ALIENIGENAS   ");
        System.Console.WriteLine();
        Console.ResetColor();
        System.Console.WriteLine(new string ('=',60));

        Console.WriteLine(new string ('*',60));
        System.Console.WriteLine($"¿Qué Deseas Hacer {nombre}?");
        Console.WriteLine(new string ('*',60));
        System.Console.WriteLine("1.Registrar Una Criatura");
        Console.WriteLine(new string ('-',60));
        System.Console.WriteLine("2.Alimentar Todas Las Mascotas");
        Console.WriteLine(new string ('-',60));
        System.Console.WriteLine("3.Hcer Que Las Mascotas Emitan Sonido");
        Console.WriteLine(new string ('-',60));
        System.Console.WriteLine("4.Alimentar A Una Criatura Específica");
        Console.WriteLine(new string ('-',60));
        System.Console.WriteLine("5.Ver Estado De Las Mascotas");
        Console.WriteLine(new string ('-',60));
        System.Console.WriteLine("6.Salir");
        Console.WriteLine(new string ('-',60));
        Console.Write("Selecciona Una Opcion Entre 1 y 6: ");
        
        string? opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                Funciones.RegistrarMascotas(mascotas);
                break;
            case "2":
                Funciones.AlimentarATodos(mascotas);
                break;
            case "3":
                Funciones.HacerSonido(mascotas);
                break;
            case "4":
                Funciones.AlimentarAUnaEnEspecifico(mascotas);
                break;
            case "5":
                Funciones.MostrarEstado(mascotas);
                break;
            case "6":
                Funciones.Salir(nombre);
                dato = false;
                break;
            default:
                Funciones.Default();
                break;
        }
    }
}
