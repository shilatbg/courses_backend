using Clean.Core.Entities;
using Clean.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repositories
{
    public class StudentsRepositories : IStudentsRepositories
    {
        private readonly DataContext _context;

        public StudentsRepositories(DataContext context)
        {
            _context = context;
        }

        public List<Students> GetAll()
        {
            return _context.Students
                .Include(s => s.Course)
                .ThenInclude(c => c.Category)
                .Include(s => s.Course)
                .ThenInclude(c => c.Instructor)
                .ToList();
        }

        public Students GetById(int id)
        {
            return _context.Students
                .Include(s => s.Course)
                .ThenInclude(c => c.Category)
                .Include(s => s.Course)
                .ThenInclude(c => c.Instructor)
                .FirstOrDefault(x => x.id == id);
        }

        public Students Add(Students students)
        {
            var course = _context.Courses.FirstOrDefault(x => x.id == students.courseId);

            if (course == null)
                return null;

            _context.Students.Add(students);
            _context.SaveChanges();
            return students;
        }

        public Students Update(int id, Students students)
        {
            var existingStudent = _context.Students.FirstOrDefault(x => x.id == id);

            if (existingStudent == null)
                return null;

            var course = _context.Courses.FirstOrDefault(x => x.id == students.courseId);

            if (course == null)
                return null;

            existingStudent.fullName = students.fullName;
            existingStudent.phone = students.phone;
            existingStudent.email = students.email;
            existingStudent.password = students.password;
            existingStudent.courseId = students.courseId;

            _context.SaveChanges();
            return existingStudent;
        }

        public bool Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.id == id);

            if (student == null)
                return false;

            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }
    }
}
