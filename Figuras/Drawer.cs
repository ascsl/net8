using System;

namespace Figuras {

    // Clase para dibujar las figuras
    public static class Drawer
    {
        public static void Point(IPoint punto)
        {
            Console.SetCursorPosition(punto.X, punto.Y);
            Console.Write("*");
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
