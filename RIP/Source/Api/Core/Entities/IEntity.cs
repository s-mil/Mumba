namespace SamMiller.Mumba.Api.Core.Entities
{
    /// <summary>
    /// The interface for IEntity's
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// The base ID key of any IEntity
        /// </summary>
        /// <value></value>
        TKey Id { get; }

    }
}