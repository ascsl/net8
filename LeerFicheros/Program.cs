using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "guapo.txt";

        try
        {
            // Verifica si el archivo existe
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("El archivo no se encontró.");
            }


            // Registrar el proveedor de codificación
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

//            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8) )
            using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("ISO-8859-8")) )
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine("Contenido del archivo:");
                Console.WriteLine(fileContent);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Error: No tienes permisos para acceder al archivo. " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error: Ha ocurrido un error de E/S. " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: Ha ocurrido un error inesperado. " + ex.Message);
        }
    }
}
