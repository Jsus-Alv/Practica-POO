class PracticaPOO : Coche
{
    public PracticaPOO(string marca, string modelo) : base(marca, modelo) {}

    static void Main()
    {
        Garaje garaje = new Garaje();

        PracticaPOO coche1 = new PracticaPOO("Daihatsu", "Mira");
        PracticaPOO coche2 = new PracticaPOO("Hyundai", "Sonata");

        for (int i = 0; i < 2; i++)
        {
            if (garaje.AceptarCoche(coche1, "aceite"))
            {
                coche1.AcumularAveria("aceite");
                Console.WriteLine($"Coche 1 esta en el garaje. Litros de aceite: {coche1.Motor.LitrosDeAceite}, Precio de averías acumulado: {coche1.AcumuladoAverias.ToString("C2")}");
                garaje.DevolverCoche();
            }

            if (garaje.AceptarCoche(coche2, "frenos"))
            {
                coche2.AcumularAveria("frenos");
                Console.WriteLine($"Coche 2 esta en el garaje. Precio de averías acumulado: {coche2.AcumuladoAverias.ToString("C2")}");
                garaje.DevolverCoche();
            }
        }

        Console.WriteLine($"Total de coches atendidos: {garaje.CochesAtendidos}");
    }
}


// Desarrollar una clase llamada Motor
class Motor
{
    private int litros_de_aceite;
    private int potencia;
    
    public Motor(int potencia)
    {
        this.litros_de_aceite = 0; //default
        this.potencia = potencia;
    }
    
    public int LitrosDeAceite
    {
        get{return litros_de_aceite;}
        set{litros_de_aceite = value;}
    }

    public int Potencia
    {
        get{return potencia;}
        set{potencia = value;}
    }
}

// Desarrollar una clase llamada Coche
class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double acumuladoAverias;

    public Coche(string marca, string modelo)
    {
        this.motor = new Motor(0);
        this.marca = marca;
        this.modelo = modelo;
        this.acumuladoAverias = 0.0;
    }

    public Motor Motor
    {
        get {return motor;}
    }

    public string Marca
    {
        get {return marca;}
    }

    public string Modelo
    {
        get {return modelo;}
    }

    public double AcumuladoAverias
    {
        get {return acumuladoAverias;}
    }

    public void AcumularAveria(string averiaAsociada)
    {
        if (averiaAsociada.ToLower() == "aceite") // Si la avería es "aceite", incrementar en 10 litros de aceite
        {
            motor.LitrosDeAceite += 10;
        }
        Random random = new Random();
        double randomPrice = random.NextDouble() * 100;
        acumuladoAverias += randomPrice;
    }
}

class Garaje
{
    private Coche coche;
    private string averiaAsociada;
    private int cochesAtendidos;

    public Garaje()
    {
        this.coche = null;
        this.averiaAsociada = "";
        this.cochesAtendidos = 0;
    }

    public bool AceptarCoche(Coche coche, string averiaAsociada)
    {
        if (this.coche == null)
        {
            this.coche = coche;
            this.averiaAsociada = averiaAsociada;
            this.cochesAtendidos++;
            return true;
        }
        else
        {
            return false; // Ya esta atendiendo uno
        }
    }

    public void DevolverCoche()
    {
        this.coche = null;
        this.averiaAsociada = "";
    }

    public int CochesAtendidos
    {
        get {return cochesAtendidos;}
    }

}

