namespace Infrastructure.Commons.Bases
{
    internal class BaseEntityResponse<T>
    {
        public int? TotalRecords { get; set; }
        public List<T>? Items { get; set; }
    }
}
