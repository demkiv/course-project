using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeanerySystem.Domain.DataFeeders
{
    public interface IDataFeeder<T> where T: class
    {
        List<T> Data { get; set; }
        List<T> GetData();

    }
}
