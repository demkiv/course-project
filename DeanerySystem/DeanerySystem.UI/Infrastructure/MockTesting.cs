using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeanerySystem.Domain;
using DeanerySystem.Domain.Entities;

namespace DeanerySystem.UI.Infrastructure
{
    /// <summary>
    /// Development utility class should be used only to smoke test mocks data model.
    /// </summary>
    public static class MockTesting
    {
        public static void Test(IUnitOfWork unitOfWork)
        {
            //for testing mock of UnitOfWork
            try
            {
                var q = unitOfWork.FacultyRepository.Get();
                var q1 = unitOfWork.FacultyRepository.Get(x => x.Name.Contains("ppl"));
                var q3 = unitOfWork.FacultyRepository.GetById(5);
                unitOfWork.FacultyRepository.Insert(new Faculty() {Id = 20});
                var q4 = unitOfWork.FacultyRepository.Get();
                var q5 = unitOfWork.FacultyRepository.GetById(1);
                q5.Name += "123";
                unitOfWork.FacultyRepository.Update(q5);
                var q6 = unitOfWork.FacultyRepository.GetById(1);
                var w = unitOfWork.SemesterRepository.Get();
                var e = unitOfWork.StreamRepository.Get();
                var r = unitOfWork.DepartmentRepository.Get();
                var t = unitOfWork.StudentRepository.Get();
                var y = unitOfWork.ProfessorRepository.Get();
                var u = unitOfWork.GroupRepository.Get();
                var i = unitOfWork.ClassNumberTimeRepository.Get();
                var o = unitOfWork.TimeTableRepository.Get();
                var p = unitOfWork.CelluleRepository.Get();
                var a = unitOfWork.JournalRepository.Get();
                var s = unitOfWork.ClassRepository.Get();
                var d = unitOfWork.SubjectRepository.Get();
                var f = unitOfWork.EducationalPlanRepository.Get();
                unitOfWork.Save();
                unitOfWork.Dispose();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}