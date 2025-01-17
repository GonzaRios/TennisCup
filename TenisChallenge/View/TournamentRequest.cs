using AplicationCore.Entities;

namespace TenisChallenge.WebApi.View
{
    public class TournamentRequest
    {
        public List<MalePlayers> MalePlayers { get; set; }
        public List<FemalePlayers> FemalePlayers { get; set; }
    }
}
