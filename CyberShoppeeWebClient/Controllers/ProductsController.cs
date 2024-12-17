using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CyberShoppeeDataAccessLayer.Entity;
using CyberShoppeeWebClient.Models;
using Newtonsoft.Json;


namespace CyberShoppeeWebClient.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                // Asynchronous GET requests
                var top10Response = await client.GetAsync("http://localhost:49987/api/products/TopProducts");
                var mix10Response = await client.GetAsync("http://localhost:49987/api/products/LatestProduct");
                var allProductsResponse = await client.GetAsync("http://localhost:49987/api/products");

                // Ensure responses are successful
                if (!top10Response.IsSuccessStatusCode || !mix10Response.IsSuccessStatusCode || !allProductsResponse.IsSuccessStatusCode)
                {
                    // Handle error (e.g., return an error page or a fallback view)
                    return View("Error");
                }

                // Asynchronously read content
                var readData1 = await top10Response.Content.ReadAsStringAsync();
                var readData2 = await mix10Response.Content.ReadAsStringAsync();
                var readData3 = await allProductsResponse.Content.ReadAsStringAsync();

                // Deserialize JSON responses
                var topProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(readData1);
                var mixProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(readData2);
                var allProducts = JsonConvert.DeserializeObject<IEnumerable<Product>>(readData3);

                // Create the model and pass data to the view
                var model = new ProductModel
                {
                    Top10Products = (List<Product>)topProducts,
                    Mix10Products = (List<Product>)mixProducts,
                    AllProducts = (List<Product>)allProducts
                };

                return View(model);
            }
        }

    }
}
