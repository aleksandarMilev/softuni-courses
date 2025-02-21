namespace Cadastre.DataProcessor
{
    using System.Text;
    using Cadastre.Data;
    using Cadastre.Extensions;
    using Cadastre.Data.Models;
    using System.Globalization;
    using Cadastre.Data.Enumerations;
    using Cadastre.DataProcessor.ImportDtos;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedDistrict = "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen = "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            ImportDistrictsDto[] districtsDtos = xmlDocument
                .DeserializeToXml<ImportDistrictsDto[]>("Districts");

            List<District> districtsToImport = new();

            StringBuilder builder = new();

            foreach (ImportDistrictsDto dDto in districtsDtos)
            {
                if (!IsValid(dDto))
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(d => d.Name == dDto.Name))
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                District district = new()
                {
                    Name = dDto.Name,
                    PostalCode = dDto.PostalCode,
                };

                if (Enum.TryParse(dDto.Region, out Region region))
                {
                    district.Region = region;
                }
                else
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (ImportPropertyDto pDto in dDto.Properties)
                {
                    if (!IsValid(pDto))
                    {
                        builder.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime acquisitionDate = DateTime.ParseExact(
                            pDto.DateOfAcquisition,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None);

                    if (dbContext.Properties.Any(p => p.PropertyIdentifier == pDto.PropertyIdentifier) || 
                        district.Properties.Any(dp => dp.PropertyIdentifier == pDto.PropertyIdentifier))
                    {
                        builder.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (dbContext.Properties.Any(p => p.Address == pDto.Address) || 
                        district.Properties.Any(dp => dp.Address == pDto.Address))
                    {
                         builder.AppendLine(ErrorMessage);
                         continue;
                    }

                    district.Properties.Add(new()
                    {
                        PropertyIdentifier = pDto.PropertyIdentifier,
                        Area = pDto.Area,
                        Details = pDto.Details,
                        Address = pDto.Address,
                        DateOfAcquisition = acquisitionDate,
                    });
                }

                districtsToImport.Add(district);
                builder.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            dbContext.Districts.AddRange(districtsToImport);
            dbContext.SaveChanges();

            return builder.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            ImportCitizenDto[] citizenDtos = jsonDocument
                .DeserializeFromJson<ImportCitizenDto[]>();

            List<Citizen> citizensToImport = new();

            int[] propertiesIds = dbContext.Properties
                .Select(p => p.Id)
                .ToArray();

            StringBuilder builder = new();

            foreach (var cDto in citizenDtos)
            {
                if (!IsValid(cDto))
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dateOfBirth = DateTime.ParseExact(
                    cDto.BirthDate,
                    "dd-MM-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None);

                Citizen citizenToImport = new()
                {
                    FirstName = cDto.FirstName,
                    LastName = cDto.LastName,
                    BirthDate = dateOfBirth,
                };

                if (Enum.TryParse(cDto.MaritalStatus, out MaritalStatus maritalStatus))
                {
                    citizenToImport.MaritalStatus = maritalStatus;
                }
                else
                {
                    builder.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var propId in cDto.Properties)
                {
                    PropertyCitizen propertyCitizen = new()
                    {
                        Citizen = citizenToImport,
                        PropertyId = propId
                    };

                    citizenToImport.PropertiesCitizens.Add(propertyCitizen);
                }

                citizensToImport.Add(citizenToImport);
                builder.AppendLine(string.Format(SuccessfullyImportedCitizen, citizenToImport.FirstName, citizenToImport.LastName, citizenToImport.PropertiesCitizens.Count));
            }

            dbContext.Citizens.AddRange(citizensToImport);
            dbContext.SaveChanges();

            return builder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
