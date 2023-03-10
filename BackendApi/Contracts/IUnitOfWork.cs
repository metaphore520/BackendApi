namespace BackendApi.Contracts
{
    public interface IUnitOfWork
    {

        IStudentRepository StudentRepository { get; }

        ICourseRepository CourseRepository { get; }

        IMarkRepository MarkRepository { get; }

    }
}
