namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ExportDtos;
    using Cadastre.Extensions;
    using Microsoft.EntityFrameworkCore;

    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            ExportPropertyJsonDto[] properties = dbContext.Properties
                .AsNoTracking()
                 .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
                 .OrderByDescending(p => p.DateOfAcquisition)
                 .ThenBy(p => p.PropertyIdentifier)
                 .Select(p => new ExportPropertyJsonDto()
                 {
                     PropertyIdentifier = p.PropertyIdentifier,
                     Area = p.Area,
                     Address = p.Address,
                     DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                     Owners = p.PropertiesCitizens
                         .Select(pc => pc.Citizen)
                         .OrderBy(c => c.LastName)
                         .Select(c => new ExportCitizenDto()
                         {
                             LastName = c.LastName,
                             MaritalStatus = c.MaritalStatus.ToString()
                         })
                         .ToArray()
                 })
                 .ToArray();

            return properties.SerializeToJson();
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            ExportPropertyXmlDto[] properties = dbContext.Properties
                .AsNoTracking()
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyXmlDto()
                {
                    DistrictPostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy")
                })
                .ToArray();

            return properties.SerializeToXml("Properties");
        }
    }
}
