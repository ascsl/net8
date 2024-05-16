using System;

// Definimos la excepción personalizada
public class CustomDalException : Exception
{
    public CustomDalException(string message) : base(message) { }
}

// Clase DalDemo con el método dalAlta
public class DalDemo
{
    public void dalAlta()
    {
        try
        {
            // Simulamos un error que lanza la excepción personalizada
            throw new CustomDalException("Error en la capa DAL");
        }
        catch (CustomDalException ex)
        {
            // Podemos hacer algo con la excepción aquí si es necesario
            // y luego la volvemos a lanzar para que se maneje en el siguiente nivel
            throw;
        }
    }
}

// Clase BrlDemo con el método brlAlta
public class BrlDemo
{
    private DalDemo dalDemo;

    public BrlDemo()
    {
        dalDemo = new DalDemo();
    }

    public void brlAlta()
    {
        try
        {
            dalDemo.dalAlta();
        }
        catch (CustomDalException ex)
        {
            // Manejar la excepción y luego propagarla
            Console.WriteLine("Excepción manejada en BRL: " + ex.Message);
            throw;
        }
    }
}

// Clase WslDemo con el método wslAlta
public class WslDemo
{
    private BrlDemo brlDemo;

    public WslDemo()
    {
        brlDemo = new BrlDemo();
    }

    public void wslAlta()
    {
        try
        {
            brlDemo.brlAlta();
        }
        catch (CustomDalException ex)
        {
            // Manejar la excepción aquí
            Console.WriteLine("Excepción manejada en WSL: " + ex.Message);
        }
    }
}

// Programa principal para ejecutar el ejemplo
public class Program
{
    public static void Main(string[] args)
    {
        WslDemo wslDemo = new WslDemo();
        wslDemo.wslAlta();
    }
}
