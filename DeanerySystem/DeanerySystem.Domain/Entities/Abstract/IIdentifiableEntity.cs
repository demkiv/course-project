using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities.Abstract
{
    /// <summary>
    /// Represente the entity with ID.
    /// </summary>
    /// <typeparam name="T">Type of Id of the entity.</typeparam>
    public interface IIdentifiableEntity<T>
    {
        T Id { get; set; }
    }
}
