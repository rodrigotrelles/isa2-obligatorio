using ArenaGestor.API.Filters;
using ArenaGestor.APIContracts;
using ArenaGestor.APIContracts.Snacks;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaGestor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class SnacksController : Controller, ISnacksAppService
    {
        private readonly IMapper mapper;
        private readonly ISnacksService snacksService;

        public SnacksController(ISnacksService snacksService, IMapper mapper)
        {
            this.snacksService = snacksService;
            this.mapper = mapper;
        }

        [AuthorizationFilter(RoleCode.Administrador)]
        [HttpPost]
        public IActionResult AddSnack([FromBody] SnackInsertDto insertSnack)
        {
            try
            {
                var snack = mapper.Map<Snack>(insertSnack);
                var result = snacksService.AddSnack(snack);
                var resultDto = mapper.Map<SnackResultDto>(result);
                return Ok(resultDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [AuthorizationFilter(RoleCode.Administrador)]
        [HttpDelete("{snackId}")]
        public IActionResult RemoveSnack([FromRoute] int snackId)
        {
            try
            {
                snacksService.DeleteSnack(snackId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Snacks()
        {
            var result = snacksService.Snacks();
            var resultDto = mapper.Map<IEnumerable<SnackResultDto>>(result);
            return Ok(resultDto);
        }
        [HttpGet("{snackId}")]
        public IActionResult SnacksById(int snackId)
        {
            try
            {
                var result = snacksService.SnackById(snackId);
                var resultDto = mapper.Map<SnackResultDto>(result);
                return Ok(resultDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
