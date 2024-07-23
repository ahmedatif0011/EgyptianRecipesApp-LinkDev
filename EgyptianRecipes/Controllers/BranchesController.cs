using EgyptianRecipes.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace EgyptianRecipes.Controllers
{
    public class BranchesController : Controller
    {
        public static List<BranchesModel> branches = new List<BranchesModel>
        {
            new BranchesModel
            {
                Id = 1,
                Title = "Downtown Branch",
                ManagerName = "John Doe",
                OpenningHour = new TimeSpan(9, 0, 0),
                ClosingHour = new TimeSpan(17, 0, 0)
            },
            new BranchesModel
            {
                Id = 2,
                Title = "Uptown Branch",
                ManagerName = "Jane Smith",
                OpenningHour = new TimeSpan(8, 30, 0),
                ClosingHour = new TimeSpan(16, 30, 0)
            },
            new BranchesModel
            {
                Id = 3,
                Title = "Midtown Branch",
                ManagerName = "Robert Brown",
                OpenningHour = new TimeSpan(10, 0, 0),
                ClosingHour = new TimeSpan(18, 0, 0)
            },
            new BranchesModel
            {
                Id = 4,
                Title = "Eastside Branch",
                ManagerName = "Emily White",
                OpenningHour = new TimeSpan(7, 0, 0),
                ClosingHour = new TimeSpan(15, 0, 0)
            },
            new BranchesModel
            {
                Id = 5,
                Title = "Westside Branch",
                ManagerName = "Michael Green",
                OpenningHour = new TimeSpan(11, 0, 0),
                ClosingHour = new TimeSpan(19, 0, 0)
            },
            new BranchesModel
            {
                Id = 1,
                Title = "Downtown Branch",
                ManagerName = "John Doe",
                OpenningHour = new TimeSpan(9, 0, 0),
                ClosingHour = new TimeSpan(17, 0, 0)
            },
            new BranchesModel
            {
                Id = 2,
                Title = "Uptown Branch",
                ManagerName = "Jane Smith",
                OpenningHour = new TimeSpan(8, 30, 0),
                ClosingHour = new TimeSpan(16, 30, 0)
            },
            new BranchesModel
            {
                Id = 3,
                Title = "Midtown Branch",
                ManagerName = "Robert Brown",
                OpenningHour = new TimeSpan(10, 0, 0),
                ClosingHour = new TimeSpan(18, 0, 0)
            },
            new BranchesModel
            {
                Id = 4,
                Title = "Eastside Branch",
                ManagerName = "Emily White",
                OpenningHour = new TimeSpan(7, 0, 0),
                ClosingHour = new TimeSpan(15, 0, 0)
            },
            new BranchesModel
            {
                Id = 5,
                Title = "Westside Branch",
                ManagerName = "Michael Green",
                OpenningHour = new TimeSpan(11, 0, 0),
                ClosingHour = new TimeSpan(19, 0, 0)
            },
            new BranchesModel
            {
                Id = 1,
                Title = "Downtown Branch",
                ManagerName = "John Doe",
                OpenningHour = new TimeSpan(9, 0, 0),
                ClosingHour = new TimeSpan(17, 0, 0)
            },
            new BranchesModel
            {
                Id = 2,
                Title = "Uptown Branch",
                ManagerName = "Jane Smith",
                OpenningHour = new TimeSpan(8, 30, 0),
                ClosingHour = new TimeSpan(16, 30, 0)
            },
            new BranchesModel
            {
                Id = 3,
                Title = "Midtown Branch",
                ManagerName = "Robert Brown",
                OpenningHour = new TimeSpan(10, 0, 0),
                ClosingHour = new TimeSpan(18, 0, 0)
            },
            new BranchesModel
            {
                Id = 4,
                Title = "Eastside Branch",
                ManagerName = "Emily White",
                OpenningHour = new TimeSpan(7, 0, 0),
                ClosingHour = new TimeSpan(15, 0, 0)
            },
            new BranchesModel
            {
                Id = 5,
                Title = "Westside Branch",
                ManagerName = "Michael Green",
                OpenningHour = new TimeSpan(11, 0, 0),
                ClosingHour = new TimeSpan(19, 0, 0)
            },
            new BranchesModel
            {
                Id = 1,
                Title = "Downtown Branch",
                ManagerName = "John Doe",
                OpenningHour = new TimeSpan(9, 0, 0),
                ClosingHour = new TimeSpan(17, 0, 0)
            },
            new BranchesModel
            {
                Id = 2,
                Title = "Uptown Branch",
                ManagerName = "Jane Smith",
                OpenningHour = new TimeSpan(8, 30, 0),
                ClosingHour = new TimeSpan(16, 30, 0)
            },
            new BranchesModel
            {
                Id = 3,
                Title = "Midtown Branch",
                ManagerName = "Robert Brown",
                OpenningHour = new TimeSpan(10, 0, 0),
                ClosingHour = new TimeSpan(18, 0, 0)
            },
            new BranchesModel
            {
                Id = 4,
                Title = "Eastside Branch",
                ManagerName = "Emily White",
                OpenningHour = new TimeSpan(7, 0, 0),
                ClosingHour = new TimeSpan(15, 0, 0)
            },
            new BranchesModel
            {
                Id = 5,
                Title = "Westside Branch",
                ManagerName = "Michael Green",
                OpenningHour = new TimeSpan(11, 0, 0),
                ClosingHour = new TimeSpan(19, 0, 0)
            },
            new BranchesModel
            {
                Id = 1,
                Title = "Downtown Branch",
                ManagerName = "John Doe",
                OpenningHour = new TimeSpan(9, 0, 0),
                ClosingHour = new TimeSpan(17, 0, 0)
            },
            new BranchesModel
            {
                Id = 2,
                Title = "Uptown Branch",
                ManagerName = "Jane Smith",
                OpenningHour = new TimeSpan(8, 30, 0),
                ClosingHour = new TimeSpan(16, 30, 0)
            },
            new BranchesModel
            {
                Id = 3,
                Title = "Midtown Branch",
                ManagerName = "Robert Brown",
                OpenningHour = new TimeSpan(10, 0, 0),
                ClosingHour = new TimeSpan(18, 0, 0)
            },
            new BranchesModel
            {
                Id = 4,
                Title = "Eastside Branch",
                ManagerName = "Emily White",
                OpenningHour = new TimeSpan(7, 0, 0),
                ClosingHour = new TimeSpan(15, 0, 0)
            },
            new BranchesModel
            {
                Id = 5,
                Title = "Westside Branch",
                ManagerName = "Michael Green",
                OpenningHour = new TimeSpan(11, 0, 0),
                ClosingHour = new TimeSpan(19, 0, 0)
            }
        };
        [HttpGet(nameof(ListBranches))]
        public IActionResult ListBranches([FromQuery]int pageNumber = 1 )
        {
            int pageSize = 3;
            var data = branches;
            var totalPages = (data.Count + pageSize - 1) / pageSize;
            var dto = new BranchDTO
            {
                data = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                totalPages = totalPages
            };
            return View(dto);
            
        }
        [HttpDelete(nameof(DeleteBranch))]
        public IActionResult DeleteBranch([FromQuery]int Id)
        {
            branches.Remove(branches.FirstOrDefault(c => c.Id == Id));
            return View();
        }
    }
}