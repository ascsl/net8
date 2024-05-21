using System;

namespace Figuras {

    // Interfaz para línea
    public interface ILine : IPoint
    {
        int Longitud { get; set; }
    }

}
