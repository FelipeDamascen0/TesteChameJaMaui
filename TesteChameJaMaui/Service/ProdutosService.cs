using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TesteChameJaMaui.Models;

namespace TesteChameJaMaui.Services
{
    public class ProdutosService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7047/Produtos/";

        public ProdutosService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            try
            {
                var produtos = await _httpClient.GetFromJsonAsync<List<Produto>>($"{BaseUrl}GetProdutos");
                return produtos ?? new List<Produto>();
            }
            catch
            {
                return new List<Produto>();
            }
        }

        public async Task<bool> CriarProdutoAsync(Produto produto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}CriarProduto", produto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AtualizarProdutoAsync(Produto produto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}AtualizarProduto", produto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletarProdutoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BaseUrl}DeletarProduto/{id}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}