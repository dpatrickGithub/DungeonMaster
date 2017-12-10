using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DungeonMaster.Services;
using DungeonMaster.WebApi.ViewModels.Character;

namespace DungeonMaster.WebApi.Controllers.Character
{
    [Produces("application/json")]
    [Route("api/Characters")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _charSvc;

        public CharacterController(ICharacterService charSvc)
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
            return "value";
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
