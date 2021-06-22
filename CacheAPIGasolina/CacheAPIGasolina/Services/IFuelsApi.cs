using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CacheAPIGasolina.Services
{
    public interface IFuelsApi
    {
        [Get("/api/v1/products.json?product_tags=Vegan&product_type=blush")]
        Task<HttpResponseMessage> GetFuels();
    }
}
