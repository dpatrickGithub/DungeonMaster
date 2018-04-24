namespace DungeonMaster.WebApi.Controllers.Character
{
    using DungeonMaster.Data.Models;
    using DungeonMaster.Services;
    using DungeonMaster.WebApi.ViewModels.Character;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Produces("application/json")]
    [Route("api/Characters")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterSvc;

        public CharacterController(ICharacterService charSvc)
        {
            _characterSvc = charSvc;
        }

        // GET: api/Characters
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET: api/Characters/5
        [HttpGet("{id}", Name = "Get")]
        public CharacterVM Get(int id)
        {
            var characterEntity = _characterSvc.GetById(id);
            return new CharacterVM()
            {
                CharacterName = characterEntity.CharacterName,
                PlayerName = characterEntity.PlayerName,
                Id = characterEntity.Id
            };
        }
        
        // POST: api/Characters
        [HttpPost]
        public void Post([FromBody]CreateCharacterVM charStats)
        {
            var character = new Data.Models.Character()
            {
                CharacterName = charStats.CharacterName,
                RaceId = charStats.RaceId,
                Classes = new List<Data.Models.Dndclass>()
                {
                    new Data.Models.Dndclass
                    {
                        Id = charStats.ClassId
                    }
                },
                AbilityScores = SetAbilityScores(charStats.StrScore, charStats.DexScore, charStats.ConScore, charStats.IntScore, charStats.WisScore, charStats.ChaScore)
            };
            _characterSvc.Create(character);
        }
        
        // PUT: api/Characters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private ICollection<CharacterAbilityScore> SetAbilityScores(int strScore, int dexScore, int conScore, int intScore, int wisScore, int chaScore)
        {
            //TODO: Fill in the rest of these
            var strength = new CharacterAbilityScore()
            {
                Score = strScore,
                AbilityTypeId = 0 // TODO: Create enum for ability type ids.
            };

            return new List<CharacterAbilityScore>()
            {
                strength
            };
        }
    }
}
