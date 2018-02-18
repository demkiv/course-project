using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using DeanerySystem.Domain;
using DeanerySystem.Domain.DataFeeders;
namespace DeanerySystem.UI.Infrastructure
{
    /// <summary>
    /// Gets instance of the data feeder.
    /// </summary>
    public class FeederFactory
    {
        public static IDataFeeder<T> GetFeeder<T>(IUnitOfWork unitOfWork) where T : class
        {
            var feederType = Assembly.GetAssembly(typeof(AbstractDataFeeder<T>)).GetTypes()
                .FirstOrDefault(
                    ft =>
                        ft.BaseType != null &&
                        ft.IsClass && !ft.IsAbstract && ft.IsSubclassOf(typeof(AbstractDataFeeder<T>)) &&
                        ft.BaseType.GetGenericArguments()[0] == typeof(T));


            if (feederType == null)
            {
                throw new ArgumentException($"Data feeder for entity type {typeof(T)} was not fount in the Assembly.");
            }          
            var feeder = (AbstractDataFeeder<T>) Activator.CreateInstance(feederType, unitOfWork);
            return feeder;
        }
    }
}