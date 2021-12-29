using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestCorewebapi.Data;
using RestCorewebapi.DTOS;
using RestCorewebapi.Models;

namespace RestCorewebapi.Controllers
{
    [Route("api/Technology")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyRepo _repository;
        private readonly IMapper _mapper;

        public TechnologyController(ITechnologyRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<TechnologyReadDto>> GetAllTechnologies()
        {
            var Techitem = _repository.GetAllTechnologies();
            return Ok(_mapper.Map<IEnumerable<TechnologyReadDto>>(Techitem));
        }

        [HttpGet("{id}", Name="GetTechnologyById")]
         public ActionResult <TechnologyReadDto> GetTechnologyById(int id)
        {
            var TechItem = _repository.GetTechnologyById(id);
            if(TechItem != null)
            {
                return Ok(_mapper.Map<TechnologyReadDto>(TechItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult <TechnologyReadDto> CreateTechnology(TechnologyCreateDto techcreate)
        {
            var techmodel = _mapper.Map<technologies>(techcreate);
            _repository.CreateTechnology(techmodel);
            _repository.SaveChanges();
            var techread = _mapper.Map<TechnologyReadDto>(techmodel);
            return CreatedAtRoute(nameof(GetTechnologyById), new{Id=techread.Id},techread);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTechnology(int id, TechnologyUpdateDto techupdate)
        {
            var techmodel = _repository.GetTechnologyById(id);
            if(techmodel == null)
            {
                return NotFound();
            }
            _mapper.Map(techupdate, techmodel);
            _repository.UpdateTechnology(techmodel);
            _repository.SaveChanges();
            return NoContent();
            
        }
        
        [HttpPatch("{id}")]
        public ActionResult PartialTechnologyUpdate(int id, JsonPatchDocument<TechnologyUpdateDto> patchdoc)
        {
            var techmodel = _repository.GetTechnologyById(id);
            if(techmodel == null)
            {
                return NotFound();
            }

            var techtopatch = _mapper.Map<TechnologyUpdateDto>(techmodel);
            patchdoc.ApplyTo(techtopatch, ModelState);
            if(!TryValidateModel(techtopatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(techtopatch, techmodel);
            _repository.UpdateTechnology(techmodel);
            _repository.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteTechnology(int id)
        {
            var techmodel = _repository.GetTechnologyById(id);
            if(techmodel == null)
            {
                return NotFound();
            }
            _repository.DeleteTechnology(techmodel);
            _repository.SaveChanges();
            return NoContent();
        }   
    }
}