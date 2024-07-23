using System.ComponentModel.DataAnnotations;

namespace EgyptianRecipes.Models
{
    public class BranchesModel
    {
        public int Id { get; set; }
        [MaxLength(200,ErrorMessage ="The Title Filed can not be more than 200 Char")]
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "The Manager Name Filed can not be more than 250 Char")]
        public string ManagerName { get; set; }
        public TimeSpan OpenningHour { get; set; }
        public TimeSpan ClosingHour { get; set; }
        public TimeSpan WorkingHours
        { 
            get 
                {
                    return ClosingHour.Subtract(OpenningHour);
                } 
            set 
                {
                } 
        }
    }
    public class BranchDTO
    {
        public List<BranchesModel> data { get; set; }
        public int totalPages { get; set; }
    }
}
