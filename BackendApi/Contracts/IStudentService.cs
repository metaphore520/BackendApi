using BackendApi.ApiModels;

namespace BackendApi.Contracts
{
    public interface IStudentService
    {

        Task<List<StudentApiModel>> AddStudent(StudentApiModel studentApi);
        Task<List<StudentApiModel>> GetAllStudent();
        Task<List<StudentApiModel>> EditStudent(StudentApiModel studentApi);


    }
}
