using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DeanerySystem.Domain;
using DeanerySystem.Domain.Repositories;
using DeanerySystem.Domain.Entities.Abstract;
using Moq;

namespace DeanerySystem.UI.Infrastructure
{
    public class MockFactory
    {
        public static Mock<IGenericRepository<T>> GetMock<T, TId>(IUnitOfWork unitOfWork) where T: class, IIdentifiableEntity<TId>
        {
            var mock = new Mock<IGenericRepository<T>>();
            var dataFeeder = FeederFactory.GetFeeder<T>(unitOfWork);
            mock.Setup(
                    fr =>
                        fr.Get(It.IsAny<Expression<Func<T, bool>>>(),
                            It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(), It.IsAny<string>()))
                .Returns<Expression<Func<T, bool>>, Func<IQueryable<T>, IOrderedQueryable<T>>, string>
                ((filter, orderBy, includeProperties) =>
                {
                    var query = dataFeeder.Data.AsQueryable();
                    if (filter != null)
                    {
                        query = query?.Where(filter);
                    }
                    if (orderBy != null)
                    {
                        return orderBy(query).ToList();
                    }
                    return query.ToList();
                });

            mock.Setup(fr => fr.GetById(It.IsAny<object>())).Returns<object>((id) =>
            {
                return dataFeeder.Data.FirstOrDefault(f => f.Id.Equals(id));
            });
            mock.Setup(fr => fr.Insert(It.IsAny<T>())).Callback<T>((faculty) =>
            {
                dataFeeder.Data.Add(faculty);
            });
            mock.Setup(fr => fr.Delete(It.IsAny<object>())).Callback<object>((id) =>
            {
                var itemToDelete = dataFeeder.Data.FirstOrDefault(x => x.Id.Equals(id));
                dataFeeder.Data.Remove(itemToDelete);
            });
            mock.Setup(fr => fr.Update(It.IsAny<T>())).Callback<T>((faculty) =>
            {
                var itemToUpdate = dataFeeder.Data.FirstOrDefault(x => x.Id.Equals(faculty.Id));
                itemToUpdate = faculty;
            });
            return mock;
        }
    }
}