using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeanerySystem.Domain.DataFeeders;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.Domain.Utilities
{
    public static class DataBaseUtilities
    {
        public static void FeedDataBase()
        {
            try
            {
                using (var uow = new UnitOfWork())
                {
                    var university = new University() { Name = "ЛНУ імені Івана Франка" };
                    uow.UniversityRepository.Insert(university);
                    uow.Save();

                    var fDataFeeder = new FacultyDataFeeder(uow);
                    fDataFeeder.Data.ForEach(f =>
                    {
                        f.University = university;
                        uow.FacultyRepository.Insert(f);
                    });
                    uow.Save();

                    var sDataFeeder = new StreamDataFeeder(uow);
                    sDataFeeder.Data.ForEach(s =>
                    {
                        uow.StreamRepository.Insert(s);
                    });
                    uow.Save();

                    var dDataFeeder = new DepartmentDataFeeder(uow);
                    dDataFeeder.Data.ForEach(d =>
                    {
                        uow.DepartmentRepository.Insert(d);
                    });
                    var semDataFeeder = new SemesterDataFeeder(uow);
                    semDataFeeder.Data.ForEach(s =>
                    {
                        uow.SemesterRepository.Insert(s);
                    });
                    uow.Save();

                    var pDataFeeder = new ProfessorDataFeeder(uow);
                    uow.Save();

                    var gDataFeeder = new GroupDataFeeder(uow);
                    gDataFeeder.Data.ForEach(g =>
                    {
                        uow.GroupRepository.Insert(g);
                    });
                    uow.Save();

                    var stDataFeeder = new StudentDataFeeder(uow);
                    uow.Save();

                    var subjDataFeeder = new SubjectDataFeeder(uow);
                    subjDataFeeder.Data.ForEach(s =>
                    {
                        uow.SubjectRepository.Insert(s);

                    });
                    uow.Save();

                    var classDataFeeder = new ClassDataFeeder(uow);
                    classDataFeeder.Data.ForEach(c =>
                    {
                        uow.ClassRepository.Insert(c);

                    });
                    uow.Save();

                    var timeTableDataFeeder = new TimeTableDataFeeder(uow);
                    timeTableDataFeeder.Data.ForEach(t =>
                    {
                        uow.TimeTableRepository.Insert(t);

                    });
                    uow.Save();

                    var classNumberTimes = new ClassNumberTimeDataFeeder(uow);
                    classNumberTimes.Data.ForEach(c =>
                    {
                        uow.ClassNumberTimeRepository.Insert(c);

                    });
                    uow.Save();

                    var jDataFeeder = new JournalDataFeeder(uow);
                    jDataFeeder.Data.ForEach(j =>
                    {
                        uow.JournalRepository.Insert(j);

                    });
                    uow.Save();

                    var cDataFeeder = new CellulesDataFeeder(uow);
                    cDataFeeder.Data.ForEach(c =>
                    {
                        uow.CelluleRepository.Insert(c);
                    });
                    uow.Save();

                    var eDataFeeder = new EducationalPlanDataFeeder(uow);
                    eDataFeeder.Data.ForEach(e =>
                    {
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
