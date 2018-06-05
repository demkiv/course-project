using System.Collections.Generic;
using System.Linq;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Enums;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public class ClassDataFeeder: AbstractDataFeeder<Class>
    {
        public ClassDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Class>
            {
                new Class
                {
                    Id = 1,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "mykhailo.scherbatyy@edeanery.com").First(),
                    Subject = unitOfWork.SubjectRepository.GetById(1)
                },
                new Class
                {
                    Id = 2,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "vitalii.chornenkiy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(2)
                },
				new Class
                {
                    Id = 3,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "mykhailo.scherbatyy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(1)
                },
                new Class
                {
                    Id = 4,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "mykhailo.scherbatyy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(1)
                },
                new Class
                {
                    Id = 5,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "vitalii.chornenkiy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(2)
                },
                new Class
                {
                    Id = 6,
                    ClassType = ClassTypes.Lecture,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "vitalii.chornenkiy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(2)
                },
                new Class
                {
                    Id = 7,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "vitalii.chornenkiy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(2)
                },
                new Class
                {
                    Id = 8,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "vitalii.chornenkiy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(5)
                },
                new Class
                {
                    Id = 9,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "vitalii.chornenkiy@edeanery.com").First(),
					Subject = unitOfWork.SubjectRepository.GetById(6)
                },
                new Class
                {
                    Id = 10,
                    ClassType = ClassTypes.PracticalClass,
                    Professor = unitOfWork.ProfessorRepository.Get(filter: p => p.Email == "vitalii.chornenkiy@edeanery.com").First(),
                    Subject = unitOfWork.SubjectRepository.GetById(7)
                }
            };

            this.Data.ForEach(c =>
            {
                c.Subject.Classes.Add(c);
                c.Professor.Classes.Add(c);
            });
        }
    }
}
