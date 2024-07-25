using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.Models
{
    public class BranchesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ManagerName { get; set; }
        public TimeSpan OpenningHour { get; set; }
        public TimeSpan ClosingHour { get; set; }
        public TimeSpan WorkingHours { get; set; }
    }
    public class BranchDTO
    {
        public List<BranchesModel> data { get; set; }
        public int totalPages { get; set; }
    }
}
