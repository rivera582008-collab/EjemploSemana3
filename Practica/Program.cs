static int ValidarNumerosEnteros(string mensaje,int DebeSerMayorOIgualA = int.MinValue,int DebeSerMenorOIgualA = int.MaxValue)
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

static string LeerTextoQueNoQuedeVacio(string mensaje)
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

static string LeerSoloLetras(string mensaje)
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

// Validar numeros solo numeros ---------

int ValidarNumeros(string mensaje)
{
    int ViscosidadValida = 0;
    bool DatoCorrecto = false;

    while (!DatoCorrecto)
    {   
        System.Console.Write(mensaje);
        string? n = Console.ReadLine();
      
        if (int.TryParse(n, out ViscosidadValida))
        {
            DatoCorrecto = true;

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Por Favor Ingrese Un Número Entero. Intentalo De Nuevo");
            Console.ResetColor();
        }
    }
    return ViscosidadValida;

}


// Pruebas --------------



bool i = false;
while(!i)
{
    int Numero = ValidarNumerosEnteros("Ingresa Un Número Entre: ",1);

    if (Numero == 12)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("GANASTE");
        Console.ResetColor();
        i= true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine("Intentalo de nuevo");  
        Console.ResetColor(); 
    }
}


bool s = false;

while (!s)
{
 
    int num = ValidarNumeros("Ingresa Un Número No Menor A 1 Y No Mayor A 14: ");

    if (num < 1 || num > 14)
    {
        System.Console.WriteLine("Negativo-y No Mayor A 14");
    }

    else
    {
        System.Console.WriteLine("Hola ");
        s = true;
    }


}

