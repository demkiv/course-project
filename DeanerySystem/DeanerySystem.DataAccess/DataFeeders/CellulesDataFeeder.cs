﻿using System;
using System.Collections.Generic;
using System.Linq;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;

namespace DeanerySystem.DataAccess.DataFeeders
{
    public class CellulesDataFeeder: AbstractDataFeeder<Cellule>
    {
        public CellulesDataFeeder(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.data = new List<Cellule>
            {
                new Cellule
                {
                    Id = 1,
                    Date = new DateTime(2017, 9, 18, 10, 10, 0),
                    Mark = "7",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(1),
                    Journal = unitOfWork.JournalRepository.GetById(1)
                },
                new Cellule
                {
                    Id = 2,
                    Date = new DateTime(2017, 10, 30, 16, 40, 0),
                    Mark = "15",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(2),
                   Journal = unitOfWork.JournalRepository.GetById(1)
                },
                new Cellule
                {
                    Id = 3,
                    Date = new DateTime(2017, 10, 2, 10, 10, 0),
                    Mark = "22",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(4),
                   Journal = unitOfWork.JournalRepository.GetById(1)
                },
                new Cellule
                {
                    Id = 4,
                    Date = new DateTime(2017, 10, 16, 16, 40, 0),
                    Mark = "21",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(8),
                   Journal = unitOfWork.JournalRepository.GetById(1)
                },
                new Cellule
                {
                    Id = 5,
                    Date = new DateTime(2017, 9, 18, 10, 10, 0),
                    Mark = "17",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(10),
                   Journal = unitOfWork.JournalRepository.GetById(1)
                },
                new Cellule
                {
                    Id = 6,
                    Date = new DateTime(2017, 9, 18, 10, 10, 0),
                    Mark = "19",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(14),
                   Journal = unitOfWork.JournalRepository.GetById(1)
                },
                new Cellule
                {
                    Id = 7,
                    Date = new DateTime(2017, 10, 30, 10, 10, 0),
                    Mark = "22",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(11),
                   Journal = unitOfWork.JournalRepository.GetById(1)
                },
                new Cellule
                {
                    Id = 8,
                    Date = new DateTime(2017, 11, 27, 16, 40, 0),
                    Mark = "н",
                    Student = unitOfWork.StudentRepository.Get().ToList().ElementAt(4),
                   Journal = unitOfWork.JournalRepository.GetById(1)
                }
            };

            this.Data.ForEach(c =>
            {
                c.Journal.Cellules.Add(c);
                c.Student.Cellules.Add(c);
            });
        }
    }
}
