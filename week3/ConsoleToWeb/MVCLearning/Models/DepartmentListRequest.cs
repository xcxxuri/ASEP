using ApplicationCore.Entities;


namespace MVCLearning.Models
{
    public class DepartmentListRequest
    {
        public IEnumerable<Departments> Depts { get; set; }
    }

}
