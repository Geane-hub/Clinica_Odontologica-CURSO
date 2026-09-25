using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json; 

namespace ClinicaOdontologicaConsumer
{
    public class CRUD<T>
    {
        public static string Endpoint { get; set; }

        // 1. OBTENER TODOS LOS REGISTROS (GET)
        public static List<T> GetAll()
        {
            using (var cliente = new HttpClient())
            {
                // Hace la petición GET al Endpoint
                var response = cliente.GetAsync(Endpoint).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Lee el JSON que mandó la API como string
                    var json = response.Content.ReadAsStringAsync().Result;

                    // Convierte el texto JSON en una Lista de objetos tipo T
                    return JsonSerializer.Deserialize<List<T>>(json);
                }
                else
                {
                    // Si la API falla, arroja un error con el código de estado (ej. 404, 500)
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        // 2. OBTENER UN REGISTRO POR ID (GET con ID)
        public static T GetById(int id)
        {
            using (var cliente = new HttpClient())
            {
                // Añade el ID a la URL (ej. "api/pacientes/5")
                var response = cliente.GetAsync($"{Endpoint}/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    // Convierte el JSON en un solo objeto tipo T
                    return JsonSerializer.Deserialize<T>(json);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        // 3. CREAR UN NUEVO REGISTRO (POST)
        public static T Create(T item)
        {
            using (var cliente = new HttpClient())
            {
                // Convierte el objeto de C# a un texto plano JSON
                string jsonEnviar = JsonSerializer.Serialize(item);

                // Empaca el JSON especificando que es texto UTF8 y tipo "application/json"
                var contenido = new StringContent(jsonEnviar, Encoding.UTF8, "application/json");

                // Hace la petición POST enviando el contenido
                var response = cliente.PostAsync(Endpoint, contenido).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonRespuesta = response.Content.ReadAsStringAsync().Result;
                    // La API usualmente devuelve el objeto creado con su nuevo ID asignado
                    return JsonSerializer.Deserialize<T>(jsonRespuesta);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        // 4. ACTUALIZAR UN REGISTRO EXISTENTE (PUT)
        public static bool Update(int id, T item)
        {
            using (var cliente = new HttpClient())
            {
                string jsonEnviar = JsonSerializer.Serialize(item);
                var contenido = new StringContent(jsonEnviar, Encoding.UTF8, "application/json");

                // Hace la petición PUT apuntando al ID específico
                var response = cliente.PutAsync($"{Endpoint}/{id}", contenido).Result;

                // Devuelve true si se actualizó correctamente, false si falló
                return response.IsSuccessStatusCode;
            }
        }

        // 5. ELIMINAR UN REGISTRO (DELETE)
        public static bool Delete(int id)
        {
            using (var cliente = new HttpClient())
            {
                // Hace la petición DELETE apuntando al ID
                var response = cliente.DeleteAsync($"{Endpoint}/{id}").Result;

                // Devuelve true si se eliminó con éxito
                return response.IsSuccessStatusCode;
            }
        }
    }
}
