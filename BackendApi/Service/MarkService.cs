using BackendApi.ApiModels;
using BackendApi.Contracts;
using BackendApi.DbModels;

namespace BackendApi.Service
{
    public class MarkService : IMarkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MarkService(IUnitOfWork unitofWork)
        {

            this._unitOfWork = unitofWork;
        }
        public async Task AddMark(MarkApiModel MarkApi)
        {
            Mark newMark = new Mark();
            MapMark(newMark, MarkApi);
            this._unitOfWork.MarkRepository.Add(newMark);
            await this._unitOfWork.MarkRepository.SaveChangesAsync();
            //var listMark = await _unitOfWork.MarkRepository.GetAll();
            //return MapMarkResponse(listMark.ToList());
        }
        public async Task<List<MarkApiModelVm>> EditMark(MarkApiModel MarkApi)
        {
            Mark newMark = new Mark();
            MapMarkEdit(newMark, MarkApi);
            this._unitOfWork.MarkRepository.Edit(newMark);
            await this._unitOfWork.MarkRepository.SaveChangesAsync();
            var listMark = await _unitOfWork.MarkRepository.GetAll();
            return MapMarkResponse(listMark.ToList());
        }
        public async Task<List<MarkApiModelVm>> GetAllMark()
        {
            var listMark = await _unitOfWork.MarkRepository.GetAllMark();
            return MapMarkResponse(listMark.ToList());
        }

        public async Task<List<MarkSheetApiModel>> GetMarkSheet()
        {
            return await _unitOfWork.MarkRepository.GetMarkSheet(); 
        }







        void MapMark(Mark newMark, MarkApiModel MarkApi)
        {
            newMark.Mark1 = MarkApi.Mark1;
            newMark.StudentId = MarkApi.Student.Id;
            newMark.CourseId = MarkApi.Course.Id;
            newMark.Id = Guid.NewGuid().ToString();
        }
        void MapMarkEdit(Mark newMark, MarkApiModel MarkApi)
        {
            newMark.Mark1 = MarkApi.Mark1;
            newMark.StudentId = MarkApi.Student.Id;
            newMark.CourseId = MarkApi.Course.Id;
            newMark.Id = MarkApi.Id;
        }
        List<MarkApiModelVm> MapMarkResponse(List<Mark> Marks)
        {
            List<MarkApiModelVm> newList = new List<MarkApiModelVm>();
            for (int i = 0; i < Marks.Count(); i++)
            {
                MarkApiModelVm temp = new MarkApiModelVm();
                temp.Mark1 = Marks[i].Mark1;
                temp.Id = Marks[i].Id;
                temp.CourseId = Marks[i].Course.Id;
                temp.CourseName = Marks[i].Course.Name;
                temp.StudentName = Marks[i].Student.Name;
                temp.StudentId = Marks[i].Student.Id;
                newList.Add(temp);
            }
            return newList;

        }

    }
}
