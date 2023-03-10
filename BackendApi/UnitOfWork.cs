using BackendApi.Contracts;

namespace BackendApi
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IStudentRepository _StudentRepository;

        private readonly ICourseRepository _CourseRepository;

        private readonly IMarkRepository _MarkRepository;

        public UnitOfWork(IStudentRepository StudentRepository, ICourseRepository CourseRepository, IMarkRepository MarkRepository)
        {

            this._StudentRepository = StudentRepository;
            this._CourseRepository = CourseRepository;
            this._MarkRepository = MarkRepository;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                return _StudentRepository;
            }

        }
        public ICourseRepository CourseRepository
        {
            get
            {
                return _CourseRepository;
            }

        }
        public IMarkRepository MarkRepository
        {
            get
            {
                return _MarkRepository;
            }

        }
    }
}
