using System.ComponentModel.DataAnnotations;

namespace RestCorewebapi.DTOS
{
    public class TechnologyCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string FrontEndTechConcepts{get; set;}
        
        [Required]
        [MaxLength(250)]
        public string BackEndTechConcepts{get; set;}
    }
}