using System;

namespace Homan.DAL.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}