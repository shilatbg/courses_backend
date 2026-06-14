using Clean.Core.Entities;
using Clean.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clean.Data.Repositories
{
    public class InstructorsRepositories : IInstructorsRepositories
    {
        private readonly DataContext _context;

        public InstructorsRepositories(DataContext context)
        {
            _context = context;
        }

        public List<Instructors> GetAll()
        {
            return _context.Instructors
                .Include(i => i.Courses)
                .ToList();
        }

        public Instructors GetById(int id)
        {
            return _context.Instructors
                .Include(i => i.Courses)
                .FirstOrDefault(x => x.id == id);
        }

        public Instructors Add(Instructors instructors)
        {
            _context.Instructors.Add(instructors);
            _context.SaveChanges();
            return instructors;
        }

        public Instructors Update(int id, Instructors instructors)
        {
            var existingInstructor = _context.Instructors.FirstOrDefault(x => x.id == id);

            if (existingInstructor == null)
                return null;

            existingInstructor.fullname = instructors.fullname;
            existingInstructor.phone = instructors.phone;
            existingInstructor.email = instructors.email;
            existingInstructor.description = instructors.description;

            _context.SaveChanges();
            return existingInstructor;
        }

        public bool Delete(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(x => x.id == id);

            if (instructor == null)
                return false;

            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return true;
        }
    }
}
