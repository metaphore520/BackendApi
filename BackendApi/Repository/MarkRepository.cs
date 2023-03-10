using BackendApi.ApiModels;
using BackendApi.Contracts;
using BackendApi.DbContextFile;
using BackendApi.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Repository
{
    public class MarkRepository : RepositoryBase<Mark>, IMarkRepository
    {
        private readonly AssesmentDbContext _context;
        public MarkRepository(AssesmentDbContext context) : base(context)
        {
            this._context = context;

        }

        public async Task<List<Mark>> GetAllMark()
        {

            return await this._context.Marks.Include(x => x.Student).Include(y => y.Course).ToListAsync();
        }

        public async Task<List<MarkSheetApiModel>> GetMarkSheet()
        {
            this._context.ChangeTracker.LazyLoadingEnabled = false;
            
            var response = await this._context
                .Marks
                .Include(x => x.Course)
                .Include(x => x.Student).ToListAsync();

            Console.WriteLine("");
            var marksheet =
                response
                .GroupBy(
                x => x.StudentId,
                (key, group) => new MarkSheetApiModel
                {
                    StudentName = group.FirstOrDefault().Student.Name.ToString(),
                    Courses = group.Select(x => x.Course.Name).ToList(),
                    AverageMark = Convert.ToInt32(group.Average(x => x.Mark1)),
                    MaxMark = group.Max(x => x.Mark1)
                }
                ).ToList();

            return   marksheet;
        }




    }
}
