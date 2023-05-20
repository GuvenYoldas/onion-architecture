using AutoMapper;
using GUVENYOLDAS.API.ExampleProject.Models.Base;
using GUVENYOLDAS.API.ExampleProject.Models;
using GUVENYOLDAS.Infrastructure.DBName.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Net;
using System.ServiceModel;
using System.Xml.Serialization;
using System.Collections.Specialized;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using GUVENYOLDAS.Core.DBName.Entities.Tables;
using Microsoft.EntityFrameworkCore;


namespace GUVENYOLDAS.API.ExampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : Controller
    {
        private readonly ProcService _procService;
        private readonly QueryService _queryService;
        private readonly TableService _tableService;
        private readonly IMapper _mapper;
        public ExampleController(ProcService procService
                             , QueryService queryService
                             , TableService tableService
                             , IMapper mapper)
        {
            _procService = procService;
            _queryService = queryService;
            _tableService = tableService;
            _mapper = mapper;
        }


        [HttpPost("ExamplePost")]
        public IActionResult ExamplePost(string fullName, int age)
        {
            ResultModel<TableModel> oModel = new ResultModel<TableModel>
            {
                Data = null,
                Message = "System got an error!",
                Success = 99
            };

            try
            {
                var entity = _tableService.GetFirst(g => g.FullName == fullName);
                entity.Age = age;
                _tableService.Update(entity);

                oModel.Message = "Everything is fine!";
                oModel.Success = 0;
            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                oModel.Success = 98;
            }

            return new JsonResult(oModel);
        }

        [HttpGet("ExampleGet")]
        public IActionResult ExampleGet()
        {
            ResultModel<List<TableModel>> oModel = new ResultModel<List<TableModel>>
            {
                Data = null,
                Message = "System got an error!",
                Success = 99
            };

            try
            {
                var selectedData = _tableService.GetAll()
                                   //.Get(g => g.FullName == "GUVENYOLDAS")
                                   //.GetById(1)
                                   //.Select(s => )
                                   //.DistinctBy(d => new { d.FullName, d.Age })
                                   .OrderBy(o => o.FullName)
                                   .ToList();
                oModel.Data = _mapper.Map<List<TableModel>>(selectedData);

                oModel.Message = "";
                oModel.Success = 0;

            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                oModel.Success = 98;
            }

            return new JsonResult(oModel);
        }

    }
}
