namespace Cadastre.DataProcessor.ExportDtos
{
    using System.ComponentModel.DataAnnotations;

    public class ExportPropertyJsonDto
    {
        [Required]
        public string PropertyIdentifier { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Area { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string DateOfAcquisition { get; set; }

        public ExportCitizenDto[] Owners { get; set; }
    }
}
