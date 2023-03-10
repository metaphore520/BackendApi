using BackendApi.ApiModels;

namespace BackendApi.Contracts
{
    public interface IMarkService
    {

        Task<List<MarkSheetApiModel>> GetMarkSheet();
        Task AddMark(MarkApiModel MarkApi);
        Task<List<MarkApiModelVm>> GetAllMark();
        Task<List<MarkApiModelVm>> EditMark(MarkApiModel MarkApi);
    }

}
