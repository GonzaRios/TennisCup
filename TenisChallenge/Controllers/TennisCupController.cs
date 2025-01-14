using AplicationCore.Context;
using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TenisChallenge.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TennisCupController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TennisCupController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPlayers([FromBody] List<Players> players)
        {
            try
            {
                await _tournamentService.RegisterPlayersAsync(players);
                return Ok("Players registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("simulate")]
        public IActionResult SimulateTournament([FromBody] List<Players> players)
        {
            try
            {
                var winner = _tournamentService.SimulateTournament(players);
                return Ok(winner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // CRUD
        //[HttpGet]
        //public async Task<ActionResult<List<Players>>> GetAll()
        //{
        //    return await _dbContext.Players.ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Players>> GetById(int id)
        //{
        //    return await _dbContext.Players.FirstOrDefaultAsync(x => x.Id == id);

        //}
        //[HttpPut("{id}")]
        //public async Task<ActionResult<Players>> Update(int id, Players player)
        //{
        //    if (id != player.Id)
        //    {
        //        return BadRequest();
        //    }
        //    _dbContext.Players.Update(player);
        //    await _dbContext.SaveChangesAsync();
        //    return Ok();
        //}
        //[HttpPost]
        //public async Task<ActionResult<Players>> Create(Players player)
        //{
        //    _dbContext.Players.Add(player);
        //    await _dbContext.SaveChangesAsync();
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var id2Delete = await _dbContext.Players.FindAsync(id);
        //    if (id2Delete == null)
        //    {
        //        return NotFound();
        //    }
        //    _dbContext.Players.Remove(id2Delete);
        //    await _dbContext.SaveChangesAsync();
        //    return Ok();

        //}
    }
}
