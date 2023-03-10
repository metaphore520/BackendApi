using BackendApi.ApiModels;
using BackendApi.Contracts;
using BackendApi.DbModels;

namespace BackendApi.Service
{
    public class StudentService : IStudentService
    {

        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitofWork)
        {

            this._unitOfWork = unitofWork;
        }


        public async Task<List<StudentApiModel>> AddStudent(StudentApiModel studentApi)
        {
            Student newStudent = new Student();
            MapStudent(newStudent, studentApi);
            this._unitOfWork.StudentRepository.Add(newStudent);
            await this._unitOfWork.StudentRepository.SaveChangesAsync();
            var listStudent = await _unitOfWork.StudentRepository.GetAll();
            return MapStudentResponse(listStudent.ToList());
        }
        public async Task<List<StudentApiModel>> EditStudent(StudentApiModel studentApi)
        {
            Student newStudent = new Student();
            MapStudentEdit(newStudent, studentApi);
            this._unitOfWork.StudentRepository.Edit(newStudent);
            await this._unitOfWork.StudentRepository.SaveChangesAsync();
            var listStudent = await _unitOfWork.StudentRepository.GetAll();
            return MapStudentResponse(listStudent.ToList());
        }
        public async Task<List<StudentApiModel>> GetAllStudent()
        {
            var listStudent = await _unitOfWork.StudentRepository.GetAll();
            return MapStudentResponse(listStudent.ToList());
        }
        void MapStudent(Student newStudent, StudentApiModel studentApi)
        {
            newStudent.Name = studentApi.Name;
            newStudent.Id = Guid.NewGuid().ToString();
        }
        void MapStudentEdit(Student newStudent, StudentApiModel studentApi)
        {
            newStudent.Name = studentApi.Name;
            newStudent.Id = studentApi.Id;
        }
        List<StudentApiModel> MapStudentResponse(List<Student> students)
        {
            List<StudentApiModel> newList = new List<StudentApiModel>();
            for (int i = 0; i < students.Count(); i++)
            {
                StudentApiModel temp = new StudentApiModel();
                temp.Name = students[i].Name;
                temp.Id = students[i].Id;
                newList.Add(temp);
            }
            return newList;

        }



    }
}
