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

        [HttpGet("GetAllPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            try
            {
                await _tournamentService.GetPlayersAsync();
                return Ok("List of players");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
    }
}
