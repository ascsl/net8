using System;
using System.Reflection;

// Definición del atributo personalizado
[AttributeUsage(AttributeTargets.Method)]
public class AuthorAttribute : Attribute
{
    public string Name { get; set; }

    public AuthorAttribute(string name)
    {
        Name = name;
    }
}

// Clase de demostración que utiliza el atributo personalizado
public class AuthorAttributeUsageDemo
{
    [Author("John Doe")]
    public void MyMethod()
    {
        Console.WriteLine("Método implementado por " + ((AuthorAttribute)Attribute.GetCustomAttribute(MethodBase.GetCurrentMethod(), typeof(AuthorAttribute))).Name);
    }
}

// Clase principal que demuestra cómo obtener el atributo personalizado
public class MainProgram
{
    public static void Main()
    {
        // Crear una instancia de la clase de demostración
        var demo = new AuthorAttributeUsageDemo();

        // Llamar al método y mostrar el autor
        demo.MyMethod();

        // Obtener el método mediante reflection
        MethodInfo method = typeof(AuthorAttributeUsageDemo).GetMethod("MyMethod");

        // Verificar si el método tiene el atributo AuthorAttribute
        if (method != null)
        {
            var authorAttribute = (AuthorAttribute)Attribute.GetCustomAttribute(method, typeof(AuthorAttribute));
            if (authorAttribute != null)
            {
                Console.WriteLine("El autor del método MyMethod es: " + authorAttribute.Name);
            }
        }
    }
}
