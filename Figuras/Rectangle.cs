using System;

namespace Figuras {

    // Clase para rectángulo
    public class Rectangle : IRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Alto { get; set; }
        public int Ancho { get; set; }

        public Rectangle(int x, int y, int alto, int ancho)
        {
            X = x;
            Y = y;
            Alto = alto;
            Ancho = ancho;
        }
    }

}
