﻿namespace ado.net
{
    public static class Commands
    {
        public const string GetVillainsNames = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)";
        public const string GetVillainName = "SELECT Name FROM Villains WHERE Id = @Id";
        public const string GetVillainMinions = "SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum, m.Name, m.Age FROM MinionsVillains AS mv JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = @Id ORDER BY m.Name";
        public const string UpdateTowns = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
        public const string GetUpdatedTownNames = " SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";
    }
}
