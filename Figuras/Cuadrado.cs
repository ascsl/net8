using System;

namespace Figuras {

    // Clase para cuadrado
    public class Cuadrado : IRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Alto { get; set; }
        public int Ancho { get; set; }

        public Cuadrado(int x, int y, int lado)
        {
            X = x;
            Y = y;
            Alto = lado;
            Ancho = lado;
        }
    }

}
