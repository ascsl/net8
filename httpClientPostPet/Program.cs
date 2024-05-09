using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        // Define la URL base y el endpoint de la API
        string requestUri = "https://petstore.swagger.io/v2/pet";

        // Crea el objeto que se enviará en la solicitud
        var newPet = new
        {
            id = 0,
            name = "migato"
        };

        // Serializa el objeto a JSON
        var jsonContent = JsonConvert.SerializeObject(newPet);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        // Crea y configura el cliente HttpClient
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            // Realiza la solicitud POST
            var response = await client.PostAsync(requestUri, content);

            // Comprueba el estado de la respuesta
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Mascota creada exitosamente.");
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Respuesta JSON: " + responseContent);
            }
            else
            {
                Console.WriteLine($"Error al crear la mascota: {response.StatusCode}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error en la solicitud HTTP: {e.Message}");
        }
    }
}
