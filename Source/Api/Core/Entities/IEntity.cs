namespace SamMiller.Mumba.Api.Core.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }

    }
}