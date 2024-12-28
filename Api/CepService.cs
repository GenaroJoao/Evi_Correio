using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evi_Correio.Api
{
    internal class CepService
    {
        private readonly HttpClient _httpClient;

        public CepService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        // Método para consultar o CEP
        public async Task<CepResponse> ConsultarCepAsync(string cep)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{cep}/json/");

                // Verifica se a resposta foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    // Log do JSON retornado para depuração
                    Console.WriteLine($"JSON retornado: {json}");

                    // Desserializa o JSON
                    CepResponse result = System.Text.Json.JsonSerializer.Deserialize<CepResponse>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Torna a desserialização insensível a maiúsculas e minúsculas
                    });

                    // Verifica se o resultado é válido
                    if (result == null || string.IsNullOrEmpty(result.Cep))
                    {
                        // Retorna null ou lança uma exceção se o CEP não for encontrado
                        throw new Exception("CEP não encontrado ou dados inválidos.");
                    }

                    return result;
                }
                else
                {
                    // Lança uma exceção se a resposta não for bem-sucedida
                    throw new HttpRequestException($"Erro na consulta do CEP: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Lida com exceções de forma adequada
                throw new Exception($"Erro ao consultar CEP: {ex.Message}");
            }
        }
        public class CepResponse
        {
            public string Cep { get; set; }
            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string Estado { get; set; }
            public string Uf { get; set; }
            public string Ibge { get; set; }
            public string Gia { get; set; }
            public string Ddd { get; set; }
            public string Siafi { get; set; }
        }
    }
}
