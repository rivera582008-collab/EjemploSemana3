using System.Net;

List<ContenidoMultimedia> Contenido = new List<ContenidoMultimedia>();

Contenido.Add(new Cancion("Yo Perreo Sola",300,"Beky G"));

Contenido.Add(new Cancion("Atrevete",350,"Wisin y Yandel"));

Contenido.Add(new Cancion("Punto Y Aparte",300,"Tego Calderon"));

Contenido.Add(new Podcast("Como Sobrevivir Al Ataque De Un León",2000,"Juancho",6));

Contenido.Add(new Podcast("Dinosaurios",4000,"Lic.Oscar",8));

Contenido.Add(new Podcast("Como Manejar Tus Emociones",2000,"Lic.Daniela",10));


Console.WriteLine("Bienvenido... ¿Que Deseas Registrar Ahora?\n1.Canciones\n2.Podcasts\n3.Ver Registros\n4.Salir");
string? desicion = Console.ReadLine();
int desicionbuena = int.Parse(desicion!);

if (desicionbuena == 1)
{
    Console.Write("Cuantas Canciones Desea Registrar: ");
    string? canci = Console.ReadLine();
    int cantidad = int.Parse(canci!);

    int Canti = 0;
    while ( Canti < cantidad)
    {
       Console.Write($"Escribe El Título De la Canción Número: {Canti + 1}: ");
       string? tituo1 = Console.ReadLine();

       Console.Write($"Escribe La Duación De La Canción (En Segundos): ");
       string? duracion = Console.ReadLine();
       int duracionbuena = int.Parse(duracion!);

       Console.Write($"Escribe El Nombre Del Artista: ");
       string? artista = Console.ReadLine();

       Cancion cancio = new Cancion(tituo1!,duracionbuena,artista!);
       Contenido.Add(cancio);
       Canti +=1;
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Canciones Almacenadas Con Éxito");
    Console.ResetColor();
}

else if (desicionbuena == 2)
{
    Console.Write("Cuantos Podcast Desea Registrar: ");
    string? canci = Console.ReadLine();
    int cantidad = int.Parse(canci!);

    int Cantid = 0;
    while ( Cantid < cantidad)
    {
       Console.Write($"Escribe El Título Del Podcast Número: {Cantid + 1}: ");
       string? tituo2 = Console.ReadLine();

       Console.Write($"Escribe La Duación Del Podcast (En Segundos): ");
       string? duracion2 = Console.ReadLine();
       int duracionbuena2 = int.Parse(duracion2!);

       Console.Write($"Escribe El Nombre Del Anfitrón: ");
       string? anfitrion = Console.ReadLine();

       Console.Write($"Escribe La Cantidad De Episodios: ");
       string? episo = Console.ReadLine();
       int episodio = int.Parse(episo!);

       Podcast cancio2 = new Podcast(tituo2!,duracionbuena2,anfitrion!,episodio);
       Contenido.Add(cancio2);
       Cantid +=1;
       Console.ForegroundColor = ConsoleColor.Blue;
       Console.WriteLine(new string ('*',40));
       Console.WriteLine("Mostrando Registro...");
       Console.WriteLine(cancio2.Reproducir());
       Console.WriteLine(new string ('*',40));
       Console.ResetColor();
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Podcast Almacenados Con Éxito");
    Console.ResetColor();
}

else if (desicionbuena == 3)
{
    foreach (ContenidoMultimedia i in Contenido)
    {
        Console.WriteLine(i.Reproducir());
        Console.WriteLine(new string ('*',40));
    } 
}

else if (desicionbuena == 4)
{
    Console.WriteLine("👋 Hasta Pronto....");
    Console.WriteLine(new string ('*',40));
}

else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Ingrese Un Número Valido");
    Console.ResetColor();
    
}




public class ContenidoMultimedia
{
    public string? Titulo {get; private set;}
    public int DuracionSegundos{get; private set;}

    public ContenidoMultimedia(string titulo, int duracion)
    {
        this.Titulo = titulo;
        this.DuracionSegundos = duracion;

    }

    public virtual string Reproducir()
    {
        return $"Reproduciendo Contenido";
    }
}

public class Cancion : ContenidoMultimedia
{
    public string? Artista{get; private set;}

    public Cancion(string titulo, int duracion, string artista) : base(titulo, duracion)
    {
        this.Artista = artista;
    }

    public override string Reproducir()
    {
        return $"Escuchando La Canción {this.Titulo}\nArtista: {this.Artista}";
    }
}

public class Podcast : ContenidoMultimedia
{
    public string? Anfitrion{get; private set;}
    public int NumeroEpisodio{get; private set;}

    public Podcast(string titulo, int duracion, string anfitrion, int episodio) : base(titulo, duracion)
    {
        this.Anfitrion = anfitrion;
        this.NumeroEpisodio = episodio;
    }

    public override string Reproducir()
    {
        return $"Escuchando El Podcast...\nTitulo: {this.Titulo}\nEpisodio: #{this.NumeroEpisodio}\nAnfitrión: {this.Anfitrion}";

    }
}


