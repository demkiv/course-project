using System.Collections.Generic;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public class JournalDataFeeder: DataAccess.DataFeeders.AbstractDataFeeder<Journal>
    {
        public JournalDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Journal>
            {
                new Journal
                {
                    Id = 1,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(1)
                },
                new Journal
                {
                    Id = 2,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(1)
                },
                new Journal
                {
                    Id = 3,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(2)
                },
                new Journal
                {
                    Id = 4,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(3)
                },
                new Journal
                {
                    Id = 5,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(4)
                },
                new Journal
                {
                    Id = 6,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(1)
                },
                new Journal
                {
                    Id = 7,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(1)
                },
                new Journal
                {
                    Id = 8,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(1)
                },
                new Journal
                {
                    Id = 9,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(5)
                },
                new Journal
                {
                    Id = 10,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(5)
                },
                new Journal
                {
                    Id = 11,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(6)
                },
                new Journal
                {
                    Id = 12,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(6)
                },
                new Journal
                {
                    Id = 13,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(7)
                },
                new Journal
                {
                    Id = 14,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(7)
                },
                new Journal
                {
                    Id = 15,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(8)
                },
                new Journal
                {
                    Id = 16,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(8)
                },
                new Journal
                {
                    Id = 17,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(9)
                },
                new Journal
                {
                    Id = 18,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(9)
                },
                new Journal
                {
                    Id = 19,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(10)
                },
                new Journal
                {
                    Id = 20,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>(),
                    Class = unitOfWork.ClassRepository.GetById(10)
                }
            };
            this.Data.ForEach(j => j.Class.Journals.Add(j));
        }
    }
}
