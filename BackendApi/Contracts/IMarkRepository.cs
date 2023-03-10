using BackendApi.ApiModels;
using BackendApi.DbModels;

namespace BackendApi.Contracts
{
    public interface IMarkRepository : IRepositoryBase<Mark>
    {

        Task<List<Mark>> GetAllMark();
        Task<List<MarkSheetApiModel>> GetMarkSheet();

    }
}
