import pyodbc

CONFIG_CONEXION = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=.\\SQLEXPRESS;"
    "DATABASE=Spotify;"
    "Trusted_Connection=yes;"
)

def mostrar_canciones_bd():
    try:
        conexion = pyodbc.connect(CONFIG_CONEXION)
        cursor = conexion.cursor()
        print("-----Conectando a Base De Datos----")

        cursor.execute("SELECT * FROM dbo.Canciones")
        registros = cursor.fetchall()

        if not registros:
            print("No Hay Canciones Registradas")
        else:
            for fila in registros:
                print(f"Titulo: {fila.Titulo}\nDuración En Segundos: {fila.DuracionSegundos}")
                

        cursor.close()
        conexion.close()

    except Exception as e:
        print(f"Error Al Conectar Con SQL Server: {e}")
mostrar_canciones_bd()

def mostrar_reproductor_completo():
    try:
        conexion = pyodbc.connect(CONFIG_CONEXION)
        cursor = conexion.cursor()

        consulta = """
            SELECT A.NombreArtistico,A.GeneroPrincipal,C.Titulo,C.DuracionSegundos
            FROM dbo.Artista AS A INNER JOIN dbo.Canciones AS C
            ON A.IdArtista = C.IdArtista
        """

        cursor.execute(consulta)
        registros = cursor.fetchall()

        print("---Historial De Reproducciones---")

        if not registros:
            print("No Hay Registros Disponibles")
        else:
            for fila in registros:
                print("*" * 40)
                print(f"Titulo: {fila.Titulo}\nArtista: {fila.NombreArtistico}\nGenero: {fila.GeneroPrincipal}\nDuración En Segundos: {fila.DuracionSegundos}")
                print("-" * 40)
        cursor.close()
        conexion.close()
    except Exception as e:
        print(f"Error Al Realizar La Union {e}")
mostrar_reproductor_completo()

from musica import Cancion,Podcast

reproduccion = [
    Cancion("Atrevete",400,"Wisin y Yandel"),
    Podcast("Cómo Cazar Un León",2000,"Juancho",20)   
]

print("*" * 40)
print(f"Bienvenido... ¿Que Deseas Registrar Ahora?\n1.Canciones\n2.Podcasts\n3.Ver Registros\n4.Salir")
print("*" * 40)

opcion = int(input("Ingresa el número: "))

if opcion == 1:
    cantidad = int(input("Cuantas Canciones Desea Registrar: "))

    canti = 0

    while canti < cantidad:
        titulo = input(f"Escribe El Título De la Canción Número: {canti + 1}: ")
        print("-" * 40)
        duracion = int(input("Escribe La Duación De La Canción (En Segundos): "))
        print("-" * 40)
        artista = input("Escribe El Nombre Del Artista: ")
        print("-" * 40)

        cancion_Completa = Cancion(titulo,duracion,artista)
        reproduccion.append(cancion_Completa)
        canti +=1
    print("Canciones Almacenadas Con Éxito....")
    print("-" * 40)
    print("Mostrando Resultados.....Presiona La Tecla ENTER")
    input()
    print("-" * 40)
    print(cancion_Completa.Reproducir())
    print("-" * 40)

elif opcion ==2:

    cantidad2 = int(input("Cuantos Podcast Desea Registrar: "))

    cantid = 0

    while cantid < cantidad2:
        titulo2 = input(f"Escribe El Título Del Podcast Número: {cantid + 1}: ")
        print("-" * 40)
        duracion2 = int(input("Escribe La Duación Del Podcast (En Segundos): "))
        print("-" * 40)
        anfitrion = input("Escribe El Nombre Del Anfitrión: ")
        print("-" * 40)
        episodio = int(input("Escribe La Cantidad De Episodios : "))
        print("-" * 40)

        podcast_Completo = Podcast(titulo2,duracion2,anfitrion,episodio)
        reproduccion.append(podcast_Completo)
        cantid +=1
    print("Podcast Almacenados Con Éxito....")
    print("-" * 40)
    print("Mostrando Resultados.....Presiona La Tecla ENTER")
    input()
    print("-" * 40)
    print(podcast_Completo.Reproducir())
    print("-" * 40)


elif opcion == 3:
    for i in reproduccion:
        i.Reproducir()
        print("-" * 40)

elif opcion == 4:
    print("👋👋 Hasta Pronto......")

else:
    print("Ingrese una opción valida")
 