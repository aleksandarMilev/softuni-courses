namespace Cadastre.DataProcessor.ImportDtos
{
    using Cadastre.Data.Enumerations;
    using System.ComponentModel.DataAnnotations;

    public class ImportCitizenDto
    {
        private const int NamesMinLength = 2;
        private const int NamesMaxLength = 30;

        [Required]
        [MinLength(NamesMinLength)]
        [MaxLength(NamesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(NamesMinLength)]
        [MaxLength(NamesMaxLength)]
        public string LastName { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string MaritalStatus { get; set; }

        public int[] Properties { get; set; }
    }
}
