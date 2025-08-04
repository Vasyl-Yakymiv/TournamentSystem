using Microsoft.AspNetCore.Mvc;
using TournamentSystem.API.Dto.News;
using TournamentSystem.API.Interfaces;
using TournamentSystem.API.Models;

namespace TournamentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepo;
        public NewsController(INewsRepository newsRepo)
        {
            _newsRepo = newsRepo; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
           var news =  await _newsRepo.GetAll();
           return Ok(news);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await  _newsRepo.GetNewsByIdAsync(id);
            if (news == null) 
              return NotFound();

            return Ok(news);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] News news)
        {
            if(!ModelState.IsValid) 
                return BadRequest();

            var created = _newsRepo.CreateNewsAsync(news);

            return CreatedAtAction(nameof(CreateNews),new {id = news.NewsId }, created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNews( int id, [FromBody] UpdateNewsDto updateNewsDto)
        {
            if (!ModelState.IsValid) return BadRequest();


            var existing = await _newsRepo.GetNewsByIdAsync(id);

            existing.Title = updateNewsDto.Title;
            existing.Content = updateNewsDto.Content;   
            existing.ImageUrl = updateNewsDto.ImageUrl;
            await _newsRepo.UpdateNewsAsync(existing);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var existing = await _newsRepo.GetNewsByIdAsync(id);
            if (existing == null) return NotFound();

            _newsRepo.DeleteNewsAsync(id);

            return NoContent();
        }
    }
}