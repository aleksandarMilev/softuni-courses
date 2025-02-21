namespace CollectionHierarchy.Models.Interfaces
{
    public interface IMyListCollection : IAddRemoveCollection
    {
        public int Used { get; }
    }
}
