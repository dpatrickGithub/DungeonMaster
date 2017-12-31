namespace DungeonMaster.Data.Models
{

    public abstract class Model : BaseModel, IModel
    {
        public virtual int Id { get; set; }
    }
}
