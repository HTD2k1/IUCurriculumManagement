

using Microsoft.AspNetCore.Identity;

namespace CurriculumService.Interfaces
{
    public interface CourseService
    {
        public IEnumerable<Course> GetAllCourses();
        public Course GetCourseById(string id);
        public Course GetCourseByName(string courseName);
        public bool AddCourses(IEnumerable<Course> course);
        public Course UpdateCourse(Course course);
        public bool DeleteCourse(string courseId);

    }
}
