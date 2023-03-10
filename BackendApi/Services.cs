using BackendApi.Contracts;

namespace BackendApi
{
    public class Services : IServiceWrapper
    {
        private readonly IStudentService _StudentService;
        private readonly ICourseService _CourseService;
        private readonly IMarkService _MarkService;

        public Services(IStudentService StudentService, ICourseService _CourseService, IMarkService markService)
        {
            this._StudentService = StudentService;
            this._CourseService = _CourseService;
            this._MarkService = markService;
        }

        public IStudentService StudentService
        {
            get
            {
                return this._StudentService;
            }
        }
        public ICourseService CourseService
        {
            get
            {
                return this._CourseService;
            }
        }

        public IMarkService MarkService
        {
            get
            {
                return this._MarkService;
            }
        }




    }
}
