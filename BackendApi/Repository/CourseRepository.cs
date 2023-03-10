using BackendApi.Contracts;
using BackendApi.DbContextFile;
using BackendApi.DbModels;

namespace BackendApi.Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        private readonly AssesmentDbContext _context;
        public CourseRepository(AssesmentDbContext context) : base(context)
        {
            this._context = context;

        }


    }
}
