using DistributedCacheRedis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace DistributedCacheRedis.Controllers
{
    public class ProductController : Controller
    {
        private IDistributedCache _distributedCache;

        public ProductController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


        /// 
        /// "First, go to the image cache action and perform the caching process. Then, proceed to the index action
        /// 
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult ImageCache()
        {

            /// Get image path 
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ayan.jpg");
            // we should convert to byte for save to cache
            byte[] imageByte = System.IO.File.ReadAllBytes(path);

            // This options is time to life for our cache 
            var cacheEntryOptions = new DistributedCacheEntryOptions();
            cacheEntryOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(20);

            /// saving byte to our cache 
            _distributedCache.Set("img", imageByte,cacheEntryOptions);


            return View();
        }

        public IActionResult ImageUrl()
        {
            /// we save our image as a byte thats why we are taking back as a byte 
            byte[] imageByte = _distributedCache.Get("img");
            return File(imageByte, "img/jpg");
        }

    }
}
