using BackendApi.ApiModels;
using BackendApi.Contracts;
using BackendApi.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkSheetController : ControllerBase
    {
        private readonly IServiceWrapper _service;
        public MarkSheetController(IServiceWrapper service)
        {
            this._service = service;
        }

        #region Student
        [HttpPost(Name = "AddStudent")]
        [Route("addStudent")]
        public async Task<List<StudentApiModel>> AddStudent(StudentApiModel student)
        {
            return await this._service.StudentService.AddStudent(student);
        }
        [HttpPost(Name = "EditStudent")]
        [Route("editStudent")]
        public async Task<List<StudentApiModel>> EditStudent(StudentApiModel student)
        {
            Console.Write("");
            return await this._service.StudentService.EditStudent(student);
        }

        [HttpPost(Name = "GetAllStudent")]
        [Route("getAllStudent")]
        public async Task<List<StudentApiModel>> GetAllStudent()
        {
            return await this._service.StudentService.GetAllStudent();
        }
        #endregion


        #region Course
        [HttpPost(Name = "AddCourse")]
        [Route("addCourse")]
        public async Task<List<CourseApiModel>> AddCourse(CourseApiModel course)
        {
            return await this._service.CourseService.AddCourse(course);
        }
        [HttpPost(Name = "EditCourse")]
        [Route("editCourse")]
        public async Task<List<CourseApiModel>> EditCourse(CourseApiModel course)
        {
            return await this._service.CourseService.EditCourse(course);
        }

        [HttpPost(Name = "GetAllCourse")]
        [Route("getAllCourse")]
        public async Task<List<CourseApiModel>> GetAllCourse()
        {
            return await this._service.CourseService.GetAllCourse();
        }
        #endregion


        #region Mark
        [HttpPost(Name = "AddMark")]
        [Route("addMark")]
        public async Task AddMark(MarkApi mark)
        {
            MarkApiModel apiModel = new  MarkApiModel();
            apiModel.Mark1 = mark.Mark1;
            apiModel.Course = new Course { Id = mark.CourseId };
            apiModel.Student = new Student { Id = mark.StudentId };
            Console.WriteLine("");
            
             await this._service.MarkService.AddMark(apiModel);
        }
        

        [HttpPost(Name = "GetAllMark")]
        [Route("getAllMark")]
        public async Task<MarkApiModelPage> GetAllMark()
        {

            MarkApiModelPage pageMark = new MarkApiModelPage();
            pageMark.AllMark = await this._service.MarkService.GetAllMark();
            pageMark.AllCourse = await this._service.CourseService.GetAllCourse();
            pageMark.AllStudent = await this._service.StudentService.GetAllStudent();
            return pageMark;
        }


        [HttpGet(Name = "GetMarkSheet")]
        [Route("getMarkSheet")]
        public async Task<List<MarkSheetApiModel>> GetMarkSheet()
        {
            return await _service.MarkService.GetMarkSheet();
        }



        #endregion



    }










}
