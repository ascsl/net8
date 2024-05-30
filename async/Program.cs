using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Iniciando tareas asincrónicas...");

        // Crear instancias de las tareas asincrónicas
        Task asyncTask1 = Asincrono1();
        Task asyncTask2 = Asincrono2();

        // Esperar a que ambas tareas se completen
        await Task.WhenAll(asyncTask1, asyncTask2);

        Console.WriteLine("Ambas tareas asincrónicas han finalizado.");
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }

    private static async Task Asincrono1()
    {
        Console.WriteLine("Tarea asincrónica 1 empezando...");

        // Espera de forma asincrónica durante 10 ms
        await Task.Delay(10);

        // Realizar otras operaciones asincrónicas...
        Console.WriteLine("Tarea asincrónica 1 finalizada.");
    }

    private static async Task Asincrono2()
    {
        Console.WriteLine("Tarea asincrónica 2 empezando...");

        // Espera de forma asincrónica durante 5 ms
        await Task.Delay(5);

        // Realizar otras operaciones asincrónicas...
        Console.WriteLine("Tarea asincrónica 2 finalizada.");
    }
}
