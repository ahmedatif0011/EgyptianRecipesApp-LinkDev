using EgyptianRecipes.Models;
using EgyptianRecipes.Models.Request;
using EgyptianRecipes.Models.shared;
using EgyptianRecipes.Services;
using EgyptianRecipes.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EgyptianRecipes.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IRestfulAPIService _restfulAPIService;
        private static List<BranchesModel> Branches = new List<BranchesModel>();
        public BranchesController(IRestfulAPIService restfulAPIService)
        {
            _restfulAPIService = restfulAPIService;
        }

        public async Task<IActionResult> ListBranches([FromQuery] int pageNumber = 1)
        {
            var pageSize = 3;
            (string key, string value)[] queryParams = new[] { ("pageNumber", pageNumber.ToString()) };
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
            return View(data);
        }
        public async Task<IActionResult> DeleteBranch([FromRoute] int Id)
        {
            var dta = await _restfulAPIService.Call(new RestfulAPICallingDTO
            {
                APIPath = DefualtData.deleteBranch,
                Method = HttpMethod.Delete,
                Body = JsonConvert.SerializeObject(new DeleteBranch { Id = Id})
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
            if(branch == null)
                return RedirectToAction(nameof(ListBranches));

            ViewData["IsAdd"] = false;
            return View("BranchModify", branch);

        }
    }
}