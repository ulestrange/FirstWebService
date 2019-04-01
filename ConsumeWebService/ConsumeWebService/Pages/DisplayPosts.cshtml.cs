using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http; // Note new
using Newtonsoft.Json; // Note new
using ConsumeWebService.Models;

namespace ConsumeWebService.Pages
{
    public class DisplayPostsModel : PageModel
    {

        private readonly IHttpClientFactory _clientFactory;

        public DisplayPostsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
 


        public int? Id { get; set; }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {

            var client = _clientFactory.CreateClient();

            try
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                HttpResponseMessage response = await client.GetAsync($"/posts/{id}");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                Post = JsonConvert.DeserializeObject<Post>(stringResult);
                return Page();
            }
            catch (HttpRequestException httpRequestException)
            {
                return BadRequest($"Error getting data from jsonplaceholder {httpRequestException.Message}");
            }


        }
    }
}