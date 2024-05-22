using System;

namespace Figuras {

    // Clase para dibujar las figuras
    public static class Drawer
    {
        public static void Point(IPoint punto)
        {
             try
            {
                if (punto.X < 0 || punto.X > Console.WindowWidth - 1 || punto.Y < 0 || punto.Y > Console.WindowHeight - 1)
                {
                    throw new ArgumentOutOfRangeException("No esta permitido dibujar fuera de las dimensiones de la consola.");
                }
        
                Console.SetCursorPosition(punto.X, punto.Y);
                Console.Write("*");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }            
        }

        public static void Line(ILine linea)
        {
            for (int i = 0; i < linea.Longitud; i++)
            {
                Console.SetCursorPosition(linea.X + i, linea.Y);
                Console.Write("*");
            }
        }

        public static void Rectangle(IRectangle rectan)
        {
            // Dibujar líneas horizontales
            for (int i = 0; i < rectan.Ancho; i++)
            {
                Console.SetCursorPosition(rectan.X + i, rectan.Y);
                Console.Write("*");
                Console.SetCursorPosition(rectan.X + i, rectan.Y + rectan.Alto - 1);
                Console.Write("*");
            }

            // Dibujar líneas verticales
            for (int i = 1; i < rectan.Alto - 1; i++)
            {
                Console.SetCursorPosition(rectan.X, rectan.Y + i);
                Console.Write("*");
                Console.SetCursorPosition(rectan.X + rectan.Ancho - 1, rectan.Y + i);
                Console.Write("*");
            }
        }
    }

}
