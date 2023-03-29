using Microsoft.AspNetCore.Identity;

namespace CurriculumService.Services.Interfaces
{
    public interface ICourseService
    {
        public IEnumerable<Course> GetAllCourses();
        public Course GetCourseById(string id);
        public Course GetCourseByName(string courseName);
        public bool AddCourses(IEnumerable<Course> course);
        public Course UpdateCourse(Course course);
        public bool DeleteCourse(string courseId);

    }
}
