using System.Collections.Generic;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public interface IDataFeeder<T> where T: class
    {
        List<T> Data { get; set; }
        List<T> GetData();

    }
}
