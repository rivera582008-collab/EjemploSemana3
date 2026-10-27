class Empleado:
    def __init__(self,Nombre,IdEmpleado):
        self.Nombre = Nombre
        self.IdEmpleado = IdEmpleado
        self.Salario = 1000

    def CalcularSalario(self):
        pass

class EmpleadoDesarrollador(Empleado):
    def __init__(self, Nombre, IdEmpleado,lenguajePrincipal,Bono):
        super().__init__(Nombre, IdEmpleado)

        self.lenguajePrincipal = lenguajePrincipal
        self.Bono = Bono

    def CalcularSalario(self):
        self.Salario += self.Bono
        print(f"{self.Nombre} Recibe un total de {self.Salario:.2f} Dólares")

class EmpleadoFreelancer(Empleado):
    def __init__(self, Nombre, IdEmpleado,PrecioHora,HorasTrabajadas):
        super().__init__(Nombre, IdEmpleado)

        self.PrecioHora = PrecioHora
        self.HorasTrabajadas = HorasTrabajadas

    def CalcularSalario(self):

        salario = self.PrecioHora * self.HorasTrabajadas
        print(f"{self.Nombre} Recibe un total de {salario:.2f} Dólares")
        

empleados = [
    EmpleadoDesarrollador("Sofía",1,"C#,Python y .NET",900),
    EmpleadoFreelancer("Juan",2,18,46),
    EmpleadoDesarrollador("Lucas",2,"C#,Python,Django y .NET",800),
    EmpleadoFreelancer("Carlos",3,10,100),
    EmpleadoDesarrollador("María",4,"C#,Python y .NET",800),
    EmpleadoFreelancer("Oscar",5,20,60),
    
]

for i in empleados:
    i.CalcularSalario()
    print("-" * 50)
        