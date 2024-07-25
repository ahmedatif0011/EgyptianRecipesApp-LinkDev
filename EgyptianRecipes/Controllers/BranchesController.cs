using EgyptianRecipes.Models;
using EgyptianRecipes.Models.Request;
using EgyptianRecipes.Models.shared;
using EgyptianRecipes.Services;
using EgyptianRecipes.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static EgyptianRecipes.Models.shared.enums;

namespace EgyptianRecipes.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IRestfulAPIService _restfulAPIService;
        private static List<BranchesModel> Branches = new List<BranchesModel>();
        private static string _searchCriteria = string.Empty;
        private static bool _isBooking = false;
        private static List<BookingBranch> BookedBranches = new List<BookingBranch>();
        public BranchesController(IRestfulAPIService restfulAPIService)
        {
            _restfulAPIService = restfulAPIService;
        }


        public async Task<IActionResult> ListBranches([FromQuery] BranchPageType type, [FromQuery] int pageNumber = 1, [FromQuery] string searchCriteria = "")
        {
            var data = await GetList(pageNumber, searchCriteria);
            if (type == BranchPageType.Admin)
                _isBooking = false;
            else if (type == BranchPageType.Buyer)
            {
                data.data.ForEach(c => c.isBooked = BookedBranches.Any(x => x.branchId == c.Id));
                _isBooking = true;
            }
            data.isBooking = _isBooking;
            return View(data);
        }
        public async Task<IActionResult> TablePartial([FromQuery] int pageNumber = 1, [FromQuery] string searchCriteria = "")
        {
            var data = await GetList(pageNumber, searchCriteria);
            data.isBooking = _isBooking;
            return PartialView("_BranchResults", data);
        }
        private async Task<BranchDTO> GetList([FromQuery] int pageNumber = 1, [FromQuery] string searchCriteria = "")
        {

            var pageSize = 3;
            _searchCriteria = searchCriteria;
            (string key, string value)[] queryParams = new[]
            {
                ("pageNumber", pageNumber.ToString()) ,
                ("searchCriteria",searchCriteria)
            };
            var dta = await _restfulAPIService.Call(new RestfulAPICallingDTO
            {
                APIPath = DefualtData.getBranchesList,
                Method = HttpMethod.Get,
                queryParams = queryParams
            });
            var res = JsonConvert.DeserializeObject<ResponseResult>(dta);
            Branches = JsonConvert.DeserializeObject<List<BranchesModel>>(res.data.ToString());
            var totalPages = Math.Ceiling((double)res.totalData / (double)pageSize);
            BranchDTO data = new BranchDTO
            {
                data = Branches,
                totalPages = (int)totalPages
            };
            return data;
        }
        public async Task<IActionResult> DeleteBranch([FromRoute] int Id)
        {
            var dta = await _restfulAPIService.Call(new RestfulAPICallingDTO
            {
                APIPath = DefualtData.deleteBranch,
                Method = HttpMethod.Delete,
                Body = JsonConvert.SerializeObject(new DeleteBranch { Id = Id })
            });
            return RedirectToAction(nameof(ListBranches));
        }
        public async Task<IActionResult> ModifyBranch(BranchesModel request)
        {
            if (!ModelState.IsValid)
            {
                // If the model is not valid, redisplay the form with validation errors
                return View("BranchModify", new BranchesModel());
            }
            var dta = await _restfulAPIService.Call(new RestfulAPICallingDTO
            {
                APIPath = DefualtData.addBranch,
                Method = HttpMethod.Post,
                Body = JsonConvert.SerializeObject(request)
            });

            return RedirectToAction(nameof(ListBranches));
        }
        public async Task<IActionResult> AddBranch()
        {
            ViewData["IsAdd"] = true;
            return View("BranchModify", new BranchesModel());
        }
        public async Task<IActionResult> EditBranch([FromRoute] int Id)
        {
            var branch = Branches.Find(c => c.Id == Id);
            if (branch == null)
                return RedirectToAction(nameof(ListBranches));

            ViewData["IsAdd"] = false;
            return View("BranchModify", branch);

        }
        [HttpPost]
        public async Task<IActionResult> BookBranch(BookingBranch branches)
        {
            branches.sessionId = HttpContext.TraceIdentifier;
            if(!ModelState.IsValid)
            {
                return PartialView("Modals/_BookingBranchModal", branches);
            }
            BookedBranches.Add(branches);
            return Json(new { success = true, redirectUrl = Url.Action("ListBranches", new { type = 2 }) });
        }
    }
}