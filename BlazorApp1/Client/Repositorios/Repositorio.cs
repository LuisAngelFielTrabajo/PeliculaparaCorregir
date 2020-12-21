using BlazorApp1.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private readonly HttpClient httpClient;
        public Repositorio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar)
        {
            var enviarJSON = JsonSerializer.Serialize(enviar);
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json");
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);

        }
        public List<Pelicula> ObtenerPeliculas()
        {
            return new List<Pelicula>()
    {


                    new Pelicula() {Titulo = "Chapter 1: The Mandalorian", Lanzamiento = new DateTime(2019, 11, 12),
                    Poster="https://m.media-amazon.com/images/M/MV5BNTViYzhmZTAtY2MzYi00ZTk1LTg5OGItYzc4MjBlYzlkNzU0XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_UY268_CR110,0,182,268_AL_.jpg"},
                    new Pelicula() {Titulo = "The Expanse ", Lanzamiento = new DateTime(2015, 9, 23),
                    Poster="https://m.media-amazon.com/images/M/MV5BOWUyMjA3YjctODE0My00Y2Y5LWFmMjAtNzZkZTEwNzBmYjY3XkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_UX182_CR0,0,182,268_AL_.jpg"},
                    new Pelicula() {Titulo = "Trolls World Tour", Lanzamiento = new DateTime(2020, 8, 01),
                    Poster="https://m.media-amazon.com/images/M/MV5BMTI5NmViY2YtNDk5NC00NjY2LWFlNGYtOGEwNzY1MTZmMjFmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_UX182_CR0,0,182,268_AL_.jpg"}

                };
        }
    }
}
