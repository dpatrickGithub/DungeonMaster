namespace DungeonMaster.Services
{
    using DungeonMaster.Data.Models;
    using DungeonMaster.Models;
    using DungeonMaster.Repositories;
    using System.Linq;

    public class CharacterService : ModelService<Character>, ICharacterService
    {
        IUnitOfWork _unitOfWork;
        ICharacterRepository _characterRepository;

        public CharacterService(IUnitOfWork unitOfWork, ICharacterRepository characterRepository)
            : base(unitOfWork, characterRepository)
        {
            _unitOfWork = unitOfWork;
            _characterRepository = characterRepository;
        }

        public Models.Character.Character GetById(int id)
        {
            var characterEntity = _characterRepository.GetById(id);

            var strScore = characterEntity.AbilityScores.Single(score => score.AbilityType.Name == "Strength").Score;
            var dexScore = characterEntity.AbilityScores.Single(score => score.AbilityType.Name == "Dexterity").Score;
            var conScore = characterEntity.AbilityScores.Single(score => score.AbilityType.Name == "Constitution").Score;
            var intScore = characterEntity.AbilityScores.Single(score => score.AbilityType.Name == "Intelligence").Score;
            var wisScore = characterEntity.AbilityScores.Single(score => score.AbilityType.Name == "Wisdom").Score;
            var chaScore = characterEntity.AbilityScores.Single(score => score.AbilityType.Name == "Charisma").Score;

            Models.Character.Character character = new Models.Character.Character(strScore, dexScore, conScore, intScore, wisScore, chaScore);

            return character;
        }

        public Character CreateCharacter(Character character) => _characterRepository.Add(character);

        public Character UpdateCharacteer(Character character)
        {
            _characterRepository.Edit(character);
            return character;
        }

        public void DeleteCharacter(Character character) => _characterRepository.Delete(character);
        public void DeleteCharacter(int characterId)
        {
            var character = _characterRepository.GetById(characterId);
            _characterRepository.Delete(character);
        }
    }
}
