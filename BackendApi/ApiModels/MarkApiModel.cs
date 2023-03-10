using BackendApi.DbModels;

namespace BackendApi.ApiModels
{
    public class MarkApiModelPage
    {
        public List<MarkApiModelVm> AllMark { get; set; }
        public List<StudentApiModel> AllStudent { get; set; }
        public List<CourseApiModel> AllCourse { get; set; }
    }
    public class MarkApiModel
    {
        public string Id { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
        public int Mark1 { get; set; }
    }

    public class MarkApiModelVm
    {
        public string Id { get; set; } = null!;
        public string  StudentId { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public int Mark1 { get; set; }
    }

    public class MarkApi
    {
        public string Id { get; set; } = null!;
        public string StudentId { get; set; } = null!;
        public string CourseId { get; set; } = null!;
        public int Mark1 { get; set; }
    }

}
