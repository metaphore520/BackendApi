using BackendApi.ApiModels;
using BackendApi.Contracts;
using BackendApi.DbModels;

namespace BackendApi.Service
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitofWork) { 
            this._unitOfWork = unitofWork;
        }
        public async Task<List<CourseApiModel>> AddCourse(CourseApiModel CourseApi)
        {
            Course newCourse = new Course();
            MapCourse(newCourse, CourseApi);
            this._unitOfWork.CourseRepository.Add(newCourse);
            await this._unitOfWork.CourseRepository.SaveChangesAsync();
            var listCourse = await _unitOfWork.CourseRepository.GetAll();
            return MapCourseResponse(listCourse.ToList());
        }

        public async Task<List<CourseApiModel>> EditCourse(CourseApiModel CourseApi)
        {
            Course newCourse = new Course();
            MapCourseEdit(newCourse, CourseApi);
            this._unitOfWork.CourseRepository.Edit(newCourse);
            await this._unitOfWork.CourseRepository.SaveChangesAsync();
            var listCourse = await _unitOfWork.CourseRepository.GetAll();
            return MapCourseResponse(listCourse.ToList());
        }


        public async Task<List<CourseApiModel>> GetAllCourse()
        {
            var listCourse = await _unitOfWork.CourseRepository.GetAll();
            return MapCourseResponse(listCourse.ToList());
        }


        void MapCourse(Course newCourse, CourseApiModel CourseApi)
        {
            newCourse.Name = CourseApi.Name;
            newCourse.Id = Guid.NewGuid().ToString();
        }
        void MapCourseEdit(Course newCourse, CourseApiModel CourseApi)
        {
            newCourse.Name = CourseApi.Name;
            newCourse.Id = CourseApi.Id;
        }
        List<CourseApiModel> MapCourseResponse(List<Course> Courses)
        {
            List<CourseApiModel> newList = new List<CourseApiModel>();
            for (int i = 0; i < Courses.Count(); i++)
            {
                CourseApiModel temp = new CourseApiModel();
                temp.Name = Courses[i].Name;
                temp.Id = Courses[i].Id;
                newList.Add(temp);
            }
            return newList;

        }







    }
}
