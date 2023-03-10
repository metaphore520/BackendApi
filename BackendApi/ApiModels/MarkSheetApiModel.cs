namespace BackendApi.ApiModels
{
    public class MarkSheetApiModel
    {
        public string StudentName { get; set; }

        public List<string> Courses { get; set; }
        public int MaxMark { get; set; }

        public int AverageMark { get; set; }

    }
}
