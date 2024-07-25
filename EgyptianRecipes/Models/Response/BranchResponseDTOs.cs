namespace EgyptianRecipes.Models.Response
{
    public class BranchResponseDTOs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ManagerName { get; set; }
        public TimeSpan OpenningHour { get; set; }
        public TimeSpan ClosingHour { get; set; }
        public TimeSpan WorkingHours{ get; set; }
    }
}
