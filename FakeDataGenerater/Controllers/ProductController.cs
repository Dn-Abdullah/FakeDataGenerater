using FakeDataGenerater.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;

namespace FakeDataGenerater.Controllers
{
    public class ProductController : Controller
    {
        private readonly DatabaseContaxt _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDataGenerator<ProductModel> _contactsGeneratorService;

        public ProductController(IDataGenerator<ProductModel> dataGeneratorService, IWebHostEnvironment webHostEnvironment, DatabaseContaxt context)
        {
            _contactsGeneratorService = dataGeneratorService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<List<ProductModel>> Get()
        {
         //   var List<ProductModel> databundle = new List<ProductModel>();
            var data = _contactsGeneratorService.Collection(10);
            foreach (var contact in data)
            {
                contact.ProfilePicture = "4c65120a-7a72-4e60-9e4c-e9d4d2cd8bbc.png";
                _context.ProductModels.AddAsync(contact);
            }

            
           await _context.SaveChangesAsync();
            return data;
        }
       
    }
}