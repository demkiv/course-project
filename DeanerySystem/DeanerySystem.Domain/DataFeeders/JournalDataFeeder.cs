using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;
using DeanerySystem.Domain.Entities.Enums;

namespace DeanerySystem.Domain.DataFeeders
{
    public class JournalDataFeeder: AbstractDataFeeder<Journal>
    {
        public JournalDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override List<Journal> GetData()
        {
            var journals = new List<Journal>
            {
                new Journal
                {
                    Id = 1,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                        //entitiesMock.Object.Cellules.ElementAt(0),
                        //entitiesMock.Object.Cellules.ElementAt(1),
                        //entitiesMock.Object.Cellules.ElementAt(2),
                        //entitiesMock.Object.Cellules.ElementAt(3),
                        //entitiesMock.Object.Cellules.ElementAt(4),
                        //entitiesMock.Object.Cellules.ElementAt(5),
                        //entitiesMock.Object.Cellules.ElementAt(6)
                    }
                },
                new Journal
                {
                    Id = 2,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 3,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 4,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 5,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 6,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 7,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 8,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 9,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 10,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 11,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 12,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 13,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 14,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 15,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 16,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 17,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 18,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 19,
                    JournalType = JournalTypes.Assessment,
                    Cellules = new List<Cellule>()
                    {
                    },
                },
                new Journal
                {
                    Id = 20,
                    JournalType = JournalTypes.Visiting,
                    Cellules = new List<Cellule>()
                    {
                    },
                }
            };
            return journals;
        }
    }
}
