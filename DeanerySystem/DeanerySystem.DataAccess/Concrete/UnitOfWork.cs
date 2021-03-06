﻿using System;
using DeanerySystem.DataAccess.Abstract;
using DeanerySystem.DataAccess.Entities;
using DeanerySystem.DataAccess.Entities.Identity;
using DeanerySystem.DataAccess.Repositories;

namespace DeanerySystem.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeaneryDbContext context;
        private bool disposed = false;

        public UnitOfWork(DeaneryDbContext context)
        {
            this.context = context;
        }

        private GenericRepository<Cellule> celluleRepository;
        private GenericRepository<Class> classRepository;
        private GenericRepository<ClassNumberTime> classNumberTimeRepository;
        private GenericRepository<DeaneryUser> deaneryUserRepository;
        private GenericRepository<Department> departmentRepository;
        private EducationalPlanRepository educationalPlanRepository;
        private GenericRepository<Faculty> facultyRepository;
        private GenericRepository<FailureTicket> failureTicketRepository;
        private GenericRepository<Group> groupRepository;
        private GenericRepository<Journal> journalRepository;
        private GenericRepository<Professor> professorRepository;
        private GenericRepository<ProgressRecord> progressRecordRepository;
        private GenericRepository<Semester> semesterRepository;
        private GenericRepository<Stream> streamRepository;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Subject> subjectRepository;
        private GenericRepository<TimeTable> timeTableRepository;
        private GenericRepository<University> universityRepository;

        public DeaneryDbContext Context => this.context;
        public IGenericRepository<Cellule> CelluleRepository
        {
            get
            {
                if (this.celluleRepository == null)
                {
                    this.celluleRepository = new GenericRepository<Cellule>(this.context);
                }
                return this.celluleRepository;
            }
        }

        public IGenericRepository<Class> ClassRepository
        {
            get
            {
                if (this.classRepository == null)
                {
                    this.classRepository = new GenericRepository<Class>(this.context);
                }
                return this.classRepository;
            }
        }

        public IGenericRepository<ClassNumberTime> ClassNumberTimeRepository
        {
            get
            {
                if (this.classNumberTimeRepository == null)
                {
                    this.classNumberTimeRepository = new GenericRepository<ClassNumberTime>(this.context);
                }
                return this.classNumberTimeRepository;
            }
        }

        public IGenericRepository<DeaneryUser> DeaneryUserRepository
        {
            get
            {
                if (this.deaneryUserRepository == null)
                {
                    this.deaneryUserRepository = new GenericRepository<DeaneryUser>(this.context);
                }
                return this.deaneryUserRepository;
            }
        }

        public IGenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(this.context);
                }
                return this.departmentRepository;
            }
        }

        public EducationalPlanRepository EducationalPlanRepository
        {
            get
            {
                if (this.educationalPlanRepository == null)
                {
                    this.educationalPlanRepository = new EducationalPlanRepository(this.context);
                }
                return this.educationalPlanRepository;
            }
        }

        public IGenericRepository<Faculty> FacultyRepository
        {
            get
            {
                if (this.facultyRepository == null)
                {
                    this.facultyRepository = new GenericRepository<Faculty>(this.context);
                }
                return this.facultyRepository;
            }
        }

        public IGenericRepository<FailureTicket> FailureTicketRepository
        {
            get
            {
                if (this.failureTicketRepository == null)
                {
                    this.failureTicketRepository = new GenericRepository<FailureTicket>(this.context);
                }
                return this.failureTicketRepository;
            }
        }

        public IGenericRepository<Group> GroupRepository
        {
            get
            {
                if (this.groupRepository == null)
                {
                    this.groupRepository = new GenericRepository<Group>(this.context);
                }
                return this.groupRepository;
            }
        }

        public IGenericRepository<Journal> JournalRepository
        {
            get
            {
                if (this.journalRepository == null)
                {
                    this.journalRepository = new GenericRepository<Journal>(this.context);
                }
                return this.journalRepository;
            }
        }

        public IGenericRepository<Professor> ProfessorRepository
        {
            get
            {
                if (this.professorRepository == null)
                {
                    this.professorRepository = new GenericRepository<Professor>(this.context);
                }
                return this.professorRepository;
            }
        }

        public IGenericRepository<ProgressRecord> ProgressRecordRepository
        {
            get
            {
                if (this.progressRecordRepository == null)
                {
                    this.progressRecordRepository = new GenericRepository<ProgressRecord>(this.context);
                }
                return this.progressRecordRepository;
            }
        }

        public IGenericRepository<Semester> SemesterRepository
        {
            get
            {
                if (this.semesterRepository == null)
                {
                    this.semesterRepository = new GenericRepository<Semester>(this.context);
                }
                return this.semesterRepository;
            }
        }

        public IGenericRepository<Stream> StreamRepository
        {
            get
            {
                if (this.streamRepository == null)
                {
                    this.streamRepository = new GenericRepository<Stream>(this.context);
                }
                return this.streamRepository;
            }
        }

        public IGenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new StudentRepository(this.context);
                }
                return this.studentRepository;
            }
        }

        public IGenericRepository<Subject> SubjectRepository
        {
            get
            {
                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new GenericRepository<Subject>(this.context);
                }
                return this.subjectRepository;
            }
        }

        public IGenericRepository<TimeTable> TimeTableRepository
        {
            get
            {
                if (this.timeTableRepository == null)
                {
                    this.timeTableRepository = new GenericRepository<TimeTable>(this.context);
                }
                return this.timeTableRepository;
            }
        }

        public IGenericRepository<University> UniversityRepository
        {
            get
            {
                if (this.universityRepository == null)
                {
                    this.universityRepository = new GenericRepository<University>(this.context);
                }
                return this.universityRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
