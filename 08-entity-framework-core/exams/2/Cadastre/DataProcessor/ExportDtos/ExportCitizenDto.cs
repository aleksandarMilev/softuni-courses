using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ExportDtos
{
    public class ExportCitizenDto
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string MaritalStatus { get; set; }
    }
}
