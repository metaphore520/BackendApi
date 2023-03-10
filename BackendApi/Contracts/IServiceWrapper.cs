namespace BackendApi.Contracts
{
    public interface IServiceWrapper
    {

        IStudentService StudentService { get; }
        ICourseService CourseService { get; }

        IMarkService MarkService { get; }

    }
}
