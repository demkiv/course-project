using DeanerySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeanerySystem.UI.Providers
{
    public static class UniversityProvider
    {
        public static IEnumerable<Stream> GetStreams(University university)
        {
            return university.Faculties
                .SelectMany(f => f.Streams);
        }

        public static IEnumerable<Department> GetDepartments(University university)
        {
            return university.Faculties
                .SelectMany(f => f.Streams)
                .SelectMany(s => s.Departments);
        }

        public static IEnumerable<Group> GetGroups(University university)
        {
            return university.Faculties
                .SelectMany(f => f.Streams)
                .SelectMany(s => s.Departments)
                .SelectMany(d => d.Groups);
        }

        public static IEnumerable<Professor> GetProfessors(University university) {
            return university.Faculties
                .SelectMany(f => f.Streams)
                .SelectMany(s => s.Departments)
                .SelectMany(d => d.Professors);
        }

        public static IEnumerable<Student> GetStudents(University university)
        {
            return university.Faculties
                .SelectMany(f => f.Streams)
                .SelectMany(s => s.Departments)
                .SelectMany(d => d.Groups)
                .SelectMany(d => d.Students);
        }
    }
}
