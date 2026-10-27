class ContenidoMultimedia:
    def __init__(self,Titulo,duracionsegundos):
        self.Titulo = Titulo
        self.duracionsegundos = duracionsegundos

    def Reproducir(self):
        pass


class Cancion(ContenidoMultimedia):
    def __init__(self, Titulo, duracionsegundos,artista):
        super().__init__(Titulo, duracionsegundos)
        self.artista = artista

    def Reproducir(self):
        print(f"Escuchando La Canción {self.Titulo}\nArtista: {self.artista}")


class Podcast(ContenidoMultimedia):
    def __init__(self, Titulo, duracionsegundos,anfitrion,capitulo):
        super().__init__(Titulo, duracionsegundos)
        self.anfitrion = anfitrion
        self.capitulo = capitulo

    def Reproducir(self):
        print(f"Escuchando El Podcast...\nTitulo: {self.Titulo}\nEpisodio: #{self.capitulo}\nAnfitrión: {self.anfitrion}")

