namespace SamMiller.Mumba.Api.Core.Entities
{
    public interface IEntity<TKey>
    {
        TKey ID { get; }

    }
}