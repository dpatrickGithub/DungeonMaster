namespace DungeonMaster.Services
{
    using DungeonMaster.Data.Models;
    using DungeonMaster.Repositories;

    public class CharacterService : ModelService<Character>, ICharacterService
    {
        IUnitOfWork _unitOfWork;
        ICharacterRepository _characterRepository;

        public CharacterService(IUnitOfWork unitOfWork, ICharacterRepository characterRepository)
            :base(unitOfWork, characterRepository)
        {
            _unitOfWork = unitOfWork;
            _characterRepository = characterRepository;
        }

        public Character GetById(int id) => _characterRepository.GetById(id);
    }
}
