using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public string _booksPath { get; set; }

        public BooksController(IConfiguration configuration)
        {
            _configuration = configuration;

            _booksPath = _configuration["BooksPath"];

        }

        [HttpGet()]
        public async Task<IActionResult> GetBooks()
        {

            try
            {
                var booksService = new BooksService();               

                return await Task.Run(() => Ok(booksService.GetBooks(_booksPath)));

            }
            catch (Exception ex)
            {
                //500 - Internal Server Error
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(string id)
        {

            try
            {
                var fullFileName = _booksPath + id;
                if (!System.IO.File.Exists(fullFileName))
                    return NotFound("id not found.");

                var booksService = new BooksService();

                return await Task.Run(() => Ok(booksService.GetBookById(_booksPath, id)));

            }
            catch (Exception ex)
            {
                //500 - Internal Server Error
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}/{query}")]
        public async Task<IActionResult> SearchWords(string id, string query)
        {

            try
            {
                if (string.IsNullOrEmpty(query))
                    return BadRequest("query is required.");

                if (query.Length < 3)
                    return BadRequest("query min 3 letters.");

                var booksService = new BooksService();

                return await Task.Run(() => Ok(booksService.SearchWords(_booksPath, id, query)));

            }
            catch (Exception ex)
            {
                //500 - Internal Server Error
                return StatusCode(500, ex.Message);
            }

        }
    }
}
