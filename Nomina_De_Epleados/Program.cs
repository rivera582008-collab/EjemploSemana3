List<Empleado> empleados = new List<Empleado>();

empleados.Add(new EmpleadoDesarrllador("Carlos Portillo",101,"C# y .NET",450.75m));
empleados.Add(new EmpleadoFreelancer("Lucas Hernández",102,35.50,42));
empleados.Add(new EmpleadoDesarrllador("Carlos Portillo",101,"C# y .NET",450.75m));
empleados.Add(new EmpleadoFreelancer("Sofía Hernández",103,35.50,42));
empleados.Add(new EmpleadoDesarrllador("Camila Portillo",105,"C# y .NET",500.75m));
empleados.Add(new EmpleadoFreelancer("Juan Hernández",104,35.50,42));
empleados.Add(new EmpleadoDesarrllador("Juan Portillo",105,"C# y .NET",500.75m));
empleados.Add(new EmpleadoFreelancer("Julio Hernández",106,35.50,42));
empleados.Add(new EmpleadoDesarrllador("Marcos Portillo",107,"C# y .NET y Python",600.75m));
empleados.Add(new EmpleadoFreelancer("Luis Hernández",102,35.50,42));
empleados.Add(new EmpleadoDesarrllador("Rosa Portillo",101,"C# y .NET",450.75m));
empleados.Add(new EmpleadoFreelancer("Oscar Hernández",102,35.50,42));


foreach (Empleado i in empleados)
{
    System.Console.WriteLine(i.CalcularSalario());
    
    Console.WriteLine(new string ('-',100));
}


public class Empleado
{
    public string? Nombre {get; private set;}
    public int IdEmpleado {get; private set;}

    public decimal Salario;

    public Empleado(string nombre_ini, int Id)
    {
        this.Nombre = nombre_ini;
        this.IdEmpleado = Id;
        this.Salario = 1000;
    }

    public virtual string CalcularSalario()
    {
        return $"{this.Nombre} Calculando salario base....\n Su salario base es de " + this.Salario;
        
    }


}

public class EmpleadoDesarrllador : Empleado
{
    public string? Lenguaje_Principal {get; private set;}
    public decimal BonoProyecto {get; private set;}

    public EmpleadoDesarrllador(string nombr, int id_ini,string lenguaje, decimal bono) : base(nombr,id_ini)
    {
        this.Lenguaje_Principal = lenguaje;
        this.BonoProyecto = bono;
    }

    public override string CalcularSalario()
    {
        this.Salario += this.BonoProyecto;
        return $"{this.Nombre} Desarrollador de {this.Lenguaje_Principal} recibe un total de ${this.Salario:F2} Dólares";
    }
}

public class EmpleadoFreelancer : Empleado
{
    public double PrecioHora {get; private set;}
    public int HorasTrabajadas {get; private set;}

    public EmpleadoFreelancer(string nom,int id,double preciohora, int horas) : base(nom, id)
    {
        this.PrecioHora = preciohora;
        this.HorasTrabajadas = horas;
    }

    public override string CalcularSalario()
    {
        double salario = this.PrecioHora * this.HorasTrabajadas;
        return $"{this.Nombre} (Freelancer) trabajó {this.HorasTrabajadas} horas y recibe ${salario:F2} Dólares";
    }
}
