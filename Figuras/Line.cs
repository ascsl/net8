using System;

namespace Figuras {

    // Clase para línea
    public class Line : ILine
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Longitud { get; set; }

        public Line(int x, int y, int longitud)
        {
            X = x;
            Y = y;
            Longitud = longitud;
        }
    }

}
