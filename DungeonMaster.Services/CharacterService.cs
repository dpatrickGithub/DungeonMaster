namespace DungeonMaster.Services
{
    using System.Collections.Generic;
    using DungeonMaster.Data.Models;
    using DungeonMaster.Models.DNDClass;
    using DungeonMaster.Repositories;

    public class CharacterService : ICharacterService
    {
        private readonly IClassRepository _classRepo;

        public CharacterService(IClassRepository classRepo)
        {
            _classRepo = classRepo;
        }

        public Character CreateCharacter(Character scaffoldedCharacter)
        {

            var dndClass = new DNDClass();
            return scaffoldedCharacter;
        }
    }

    public interface ICharacterServiceNew : IModelService<Character>
    {
        Character GetById(int id);
    }

    public class CharacterServiceNew : ModelService<Character>, ICharacterServiceNew
    {
        IUnitOfWork _unitOfWork;
        ICharacterRepository _characterRepository;

        public CharacterServiceNew(IUnitOfWork unitOfWork, ICharacterRepository characterRepository)
            :base(unitOfWork, characterRepository)
        {
            _unitOfWork = unitOfWork;
            _characterRepository = characterRepository;
        }

        public Character GetById(int id) => _characterRepository.GetById(id);
    }
}
