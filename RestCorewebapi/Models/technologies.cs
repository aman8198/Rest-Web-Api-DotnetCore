using System.ComponentModel.DataAnnotations;

namespace RestCorewebapi.Models
{
    public class technologies
    {
        [Key]
        public int Id{get; set;}
         

        [Required]
        [MaxLength(250)]
        public string FrontEndTechConcepts{get; set;}
        
        [Required]
        [MaxLength(250)]
        public string BackEndTechConcepts{get; set;}

    }
}