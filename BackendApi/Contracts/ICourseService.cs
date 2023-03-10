using BackendApi.ApiModels;

namespace BackendApi.Contracts
{
    public interface ICourseService
    {
        Task<List<CourseApiModel>> AddCourse(CourseApiModel CourseApi);
        Task<List<CourseApiModel>> GetAllCourse();
        Task<List<CourseApiModel>> EditCourse(CourseApiModel CourseApi);

    }
}
