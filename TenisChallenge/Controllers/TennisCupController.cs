using AplicationCore.Context;
using AplicationCore.Entities;
using AplicationCore.Interfaces;
using AplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TenisChallenge.WebApi.View;

namespace TenisChallenge.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TennisCupController : ControllerBase
    {
        private readonly ITournamentService _service;

        public TennisCupController(ITournamentService service)
        {
            _service = service;
        }

        [HttpGet("GetAllPlayers")]
        public async Task<IActionResult> GetPlayers()
        {
            try
            {
                var result =_service.GetAllPlayers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// En el siguiente controlador, se ingresa una variable de una clase ViewModel
        /// que contempla las clases MalePlayers y FemalePlayers y asi poder ingresarlas
        /// como el cuerpo del request. 
        /// </summary>
        /// <param name="requestPlayers"></param>
        /// <returns></returns>
        [HttpPost("RegisterAndSimulate")]
        public async Task<IActionResult> RegisterAndSimulate(
               [FromBody] TournamentRequest requestPlayers)     //ACLARACIÓN: NO ES NECESARIO INGRESAR LOS ID, DADO A QUE SON AUTO INCREMENTALES.
        {
            var malePlayers = requestPlayers.MalePlayers;
            var femalePlayers = requestPlayers.FemalePlayers;

            try
            {
                var (maleChampion, femaleChampion) = await _service.SimulateTournament(malePlayers, femalePlayers);

                return Ok(new
                {
                    MaleChampion = maleChampion != null ? new { maleChampion.Id, maleChampion.Name } : null,
                    FemaleChampion = femaleChampion != null ? new { femaleChampion.Id, femaleChampion.Name } : null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
