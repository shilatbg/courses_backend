using Clean.Core.Entities;
using Clean.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repositories
{
    public class CoursesRepositories : ICoursesRepositories
    {
        private readonly DataContext _context;

        public CoursesRepositories(DataContext context)
        {
            _context = context;
        }

        public List<Courses> GetAll()
        {
            return _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .ToList();
        }

        public Courses GetById(int id)
        {
            return _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Instructor)
                .Include(c => c.Students)
                .FirstOrDefault(x => x.id == id);
        }

        public Courses Add(Courses courses)
        {
            var category = _context.Categories.FirstOrDefault(x => x.id == courses.categoryId);
            var instructor = _context.Instructors.FirstOrDefault(x => x.id == courses.instructorId);

            if (category == null || instructor == null)
                return null;

            _context.Courses.Add(courses);
            _context.SaveChanges();
            return courses;
        }

        public Courses Update(int id, Courses courses)
        {
            var existingCourse = _context.Courses.FirstOrDefault(x => x.id == id);

            if (existingCourse == null)
                return null;

            var category = _context.Categories.FirstOrDefault(x => x.id == courses.categoryId);
            var instructor = _context.Instructors.FirstOrDefault(x => x.id == courses.instructorId);

            if (category == null || instructor == null)
                return null;

            existingCourse.title = courses.title;
            existingCourse.description = courses.description;
            existingCourse.hours = courses.hours;
            existingCourse.price = courses.price;
            existingCourse.location = courses.location;
            existingCourse.startDate = courses.startDate;
            existingCourse.endDate = courses.endDate;
            existingCourse.categoryId = courses.categoryId;
            existingCourse.instructorId = courses.instructorId;

            _context.SaveChanges();
            return existingCourse;
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.id == id);

            if (course == null)
                return false;

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return true;
        }
    }
}
