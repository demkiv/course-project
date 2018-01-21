using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.Entities.Abstract
{
    public interface IIdentifiableEntity<T>
    {
        T Id { get; set; }
    }
}
