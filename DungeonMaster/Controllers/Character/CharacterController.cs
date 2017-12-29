namespace DungeonMaster.WebApi.Controllers.Character
{
    using DungeonMaster.Services;
    using DungeonMaster.WebApi.ViewModels.Character;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Produces("application/json")]
    [Route("api/Characters")]
    public class CharacterController : Controller
    {
        private readonly ICharacterServiceNew _charSvc;

        public CharacterController(ICharacterServiceNew charSvc)
        {
            _charSvc = charSvc;
        }

        // GET: api/Characters
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET: api/Characters/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return _charSvc.GetById(id)?.CharacterName;
        }
        
        // POST: api/Characters
        [HttpPost]
        public void Post([FromBody]CreateCharacterVM charStats)
        {
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
    }
}
