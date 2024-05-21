using Figuras;

class Program
{
    static void Main(string[] args)
    {
        /*
        // Crear instancias de las figuras
        Point punto = new Point(5, 5);
        Line linea = new Line(10, 10, 5);
        Rectangle rectangulo = new Rectangle(20, 15, 4, 7);
        Cuadrado cuadrado = new Cuadrado(30, 20, 4);

        Drawer.Point(punto);
        Drawer.Line(linea);
        Drawer.Rectangle(rectangulo);
        Drawer.Rectangle(cuadrado);
        */

        Drawer.Point(new Point(5, 5));
        Drawer.Line(new Line(10, 10, 5));
        Drawer.Rectangle(new Rectangle(20, 15, 4, 7));
        Drawer.Rectangle(new Cuadrado(30, 20, 4));

        Console.ReadKey();
    }
}
