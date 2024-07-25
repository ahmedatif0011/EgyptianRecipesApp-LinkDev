namespace EgyptianRecipes.Models.Request
{
    public class BookingBranch
    {
        public string clientName { get; set; }
        public string clientPhone { get; set; }
        public string clientEmail { get; set; }
        public string? note { get; set; }
        public int branchId { get; set; }
        public string? sessionId { get; set; }
    }
}
