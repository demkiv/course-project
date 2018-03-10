using System;
using System.Linq;
using DeanerySystem.DataAccess.Concrete;
using DeanerySystem.DataAccess.DataFeeders;
using DeanerySystem.DataAccess.Entities;

namespace DeanerySystem.DataAccess.Utilities
{
    public static class DataBaseUtilities
    {
        public static void FeedDataBase(DeaneryDbContext context)
        {
            try
            {
                using (var uow = new UnitOfWork(context))
                {
                    if (uow.UniversityRepository.Get().Any())
                    {
                        return;                       
                    }

                    var university = new University() { Name = "ЛНУ імені Івана Франка" };
                    uow.UniversityRepository.Insert(university);
                    uow.Save();

                    var fDataFeeder = new FacultyDataFeeder(uow);
                    fDataFeeder.Data.ForEach(f =>
                    {
                        f.Id = 0;
                        uow.FacultyRepository.Insert(f);
                    });
                    uow.Save();

                    var sDataFeeder = new StreamDataFeeder(uow);
                    sDataFeeder.Data.ForEach(s =>
                    {
                        s.Id = 0;
                        uow.StreamRepository.Insert(s);
                    });
                    uow.Save();

                    var dDataFeeder = new DepartmentDataFeeder(uow);
                    dDataFeeder.Data.ForEach(d =>
                    {
                        d.Id = 0;
                        uow.DepartmentRepository.Insert(d);
                    });
                    var semDataFeeder = new SemesterDataFeeder(uow);
                    semDataFeeder.Data.ForEach(s =>
                    {
                        s.Id = 0;
                        uow.SemesterRepository.Insert(s);
                    });
                    uow.Save();

                    var pDataFeeder = new ProfessorDataFeeder(uow);
                    uow.Save();

                    var gDataFeeder = new GroupDataFeeder(uow);
                    gDataFeeder.Data.ForEach(g =>
                    {
                        g.Id = 0;
                        uow.GroupRepository.Insert(g);
                    });
                    uow.Save();

                    var stDataFeeder = new StudentDataFeeder(uow);
                    uow.Save();

                    var subjDataFeeder = new SubjectDataFeeder(uow);
                    subjDataFeeder.Data.ForEach(s =>
                    {
                        s.Id = 0;
                        uow.SubjectRepository.Insert(s);

                    });
                    uow.Save();

                    var classDataFeeder = new ClassDataFeeder(uow);
                    classDataFeeder.Data.ForEach(c =>
                    {
                        c.Id = 0;
                        uow.ClassRepository.Insert(c);

                    });
                    uow.Save();

                    var timeTableDataFeeder = new TimeTableDataFeeder(uow);
                    timeTableDataFeeder.Data.ForEach(t =>
                    {
                        t.Id = 0;
                        uow.TimeTableRepository.Insert(t);

                    });
                    uow.Save();

                    var classNumberTimes = new ClassNumberTimeDataFeeder(uow);
                    classNumberTimes.Data.ForEach(c =>
                    {
                        c.Id = 0;
                        uow.ClassNumberTimeRepository.Insert(c);

                    });
                    uow.Save();

                    var jDataFeeder = new JournalDataFeeder(uow);
                    jDataFeeder.Data.ForEach(j =>
                    {
                        j.Id = 0;
                        uow.JournalRepository.Insert(j);

                    });
                    uow.Save();

                    var cDataFeeder = new CellulesDataFeeder(uow);
                    cDataFeeder.Data.ForEach(c =>
                    {
                        c.Id = 0;
                        uow.CelluleRepository.Insert(c);
                    });
                    uow.Save();

                    var eDataFeeder = new EducationalPlanDataFeeder(uow);
                    eDataFeeder.Data.ForEach(e =>
                    {
                        e.Id = 0;
                        uow.EducationalPlanRepository.Insert(e);
                    });
                    uow.Save();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
