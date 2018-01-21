using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.DataFeeders
{
    public class StreamDataFeeder: AbstractDataFeeder<Stream>
    {
        public StreamDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var faculty = unitOfWork.FacultyRepository.Get().First(x => x.Id == 13);
            this.data = new List<Stream>
            {
                new Stream()
                {
                    Id = 1,
                    Name = "Комп'ютерні науки",
                    StreamAbbreviation = "ПМі",             
                    Faculty = faculty
                },
                new Stream()
                {
                    Id = 2,
                    Name = "Прикладна математика",
                    StreamAbbreviation = "ПМп",
                    Faculty = faculty
                },
                new Stream()
                {
                    Id = 3,
                    Name = "Системний аналіз",
                    StreamAbbreviation = "ПМа",
                    Faculty = faculty
                },
            };
        }
    }
}
