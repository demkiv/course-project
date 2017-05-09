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
        }

        public override List<Stream> GetData()
        {
            var faculty = unitOfWork.FacultyRepository.Get().First(x => x.Id == 12);
            var streams = new List<Stream>
            {
                new Stream()
                {
                    Id = 1,
                    Name = "Інформатика",
                    StreamAbbreviation = "ПМІ",
                    Faculty = faculty
                }
            };
            return streams;
        }
    }
}
