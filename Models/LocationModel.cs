using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace armadieti2.Models
{
    public class LocationModel
    {
       
            [Key]
            public int IdLocation { get; set; }

            [Required]
            public required string Stabile { get; set; }

            [Required]
            public int Piano { get; set; }                 
    }
}
