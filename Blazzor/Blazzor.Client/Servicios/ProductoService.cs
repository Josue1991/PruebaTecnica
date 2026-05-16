using Blazzor.Client.Modelos;
using System.Net.Http.Json;
using System.Text.Json;

namespace Blazzor.Client.Servicios
{
    public class ProductoService
    {
        private readonly HttpClient _http;

        public ProductoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductoDTO>> GetProductsAsync()
        {
            return await _http.GetFromJsonAsync<List<ProductoDTO>>(
                "api/products") ?? new();
        }

        public async Task<DetalleProductoDTO?> GetProductAsync(int id)
        {
            return await _http.GetFromJsonAsync<DetalleProductoDTO>(
                $"api/products/{id}");
        }

        public async Task CrearProductoAsync(CrearProductoDTO dto)
        {
            var response = await _http.PostAsJsonAsync("api/products", dto);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await ExtractErrorMessage(response);
                throw new HttpRequestException(errorMessage);
            }
        }

        public async Task CrearMovimientoAsync(int productId, CrearMovimientoStock dto)
        {
            var response = await _http.PostAsJsonAsync(
                $"api/products/{productId}/movements",
                dto);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await ExtractErrorMessage(response);
                throw new HttpRequestException(errorMessage);
            }
        }

        private async Task<string> ExtractErrorMessage(HttpResponseMessage response)
        {
            try
            {
                var content = await response.Content.ReadAsStringAsync();
                
                // Intentar parsear como JSON para extraer el mensaje
                if (!string.IsNullOrWhiteSpace(content))
                {
                    try
                    {
                        var jsonDoc = JsonDocument.Parse(content);
                        
                        // Buscar el mensaje en diferentes formatos comunes
                        if (jsonDoc.RootElement.TryGetProperty("message", out var messageElement))
                        {
                            return messageElement.GetString() ?? content;
                        }
                        
                        if (jsonDoc.RootElement.TryGetProperty("title", out var titleElement))
                        {
                            return titleElement.GetString() ?? content;
                        }

                        // Si es un objeto de error de validación
                        if (jsonDoc.RootElement.TryGetProperty("errors", out var errorsElement))
                        {
                            return $"Error de validación: {content}";
                        }
                    }
                    catch
                    {
                        // Si no se puede parsear como JSON, devolver el contenido tal cual
                        return content;
                    }
                }
                
                return $"Error {(int)response.StatusCode}: {response.ReasonPhrase}";
            }
            catch
            {
                return $"Error {(int)response.StatusCode}: {response.ReasonPhrase}";
            }
        }
    }
}
