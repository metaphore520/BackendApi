using BackendApi.Contracts;
using BackendApi.DbContextFile;
using BackendApi.DbModels;

namespace BackendApi.Repository
{
    public class StudentRepository : RepositoryBase<Student>,IStudentRepository
    {
        private readonly AssesmentDbContext _context;
        public StudentRepository(AssesmentDbContext context): base(context)
        {
            this._context = context;

        }


    }
}
