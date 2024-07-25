using static EgyptianRecipes.Models.shared.enums;

namespace EgyptianRecipes.Models.shared
{
    public class ResponseResult
    {
        public Result result { get; set; }
        public object data { get; set; }
        public int totalData { get; set; }
        public string note { get; set; }
    }
}
