namespace ado.net
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        static void Main()
        {
            string connectionString = "Server = .\\SQLEXPRESS; Database = MinionsDB; Integrated Security = True; TrustServerCertificate = true";
            using SqlConnection sqlConnection = new(connectionString);
            sqlConnection.Open();

            //1
            //Console.WriteLine(GetVillainNames(sqlConnection));
            //2
            //Console.WriteLine(GetMinionNames(sqlConnection));
            //3
            //Console.WriteLine(ChangeTownNamesCasing(sqlConnection));

        }

        //1
        public static string GetVillainNames(SqlConnection sqlConnection)
        {
            using SqlCommand sqlCommand = new(Commands.GetVillainsNames, sqlConnection);
            using SqlDataReader dataReader = sqlCommand.ExecuteReader();

            if (dataReader.Read())
            {
                return $"{dataReader[0]} - {dataReader[1]}";
            }

            return "Invalid query!";
        }

        //2
        public static string GetMinionNames(SqlConnection sqlConnection)
        {
            using SqlCommand villainNameSqlCommand = new(Commands.GetVillainName, sqlConnection);

            int id = int.Parse(Console.ReadLine());
            villainNameSqlCommand.Parameters.AddWithValue("@Id", id);

            using SqlDataReader villainNameDataReader = villainNameSqlCommand.ExecuteReader();

            StringBuilder builder = new();

            if (villainNameDataReader.Read())
            {
                builder.AppendLine($"Villain: {villainNameDataReader["Name"]}");

                villainNameDataReader.Close();

                using SqlCommand villainMinionsSqlCommand = new(Commands.GetVillainMinions, sqlConnection);
                villainMinionsSqlCommand.Parameters.AddWithValue("@Id", id);

                using SqlDataReader villainMinionsDataReader = villainMinionsSqlCommand.ExecuteReader();

                if (!villainMinionsDataReader.HasRows)
                {
                    builder.AppendLine("(no minions)");
                    return builder.ToString().TrimEnd();
                }

                while (villainMinionsDataReader.Read())
                {
                    builder.AppendLine($"{villainMinionsDataReader[0]}: {villainMinionsDataReader[1]} {villainMinionsDataReader[2]}");
                }
            }
            else
            {
                builder.AppendLine($"No villain with ID {id} exists in the database.");
                return builder.ToString().TrimEnd();
            }

            return builder.ToString().TrimEnd();
        }

        //3
        public static string ChangeTownNamesCasing(SqlConnection sqlConnection)
        {
            string countryName = Console.ReadLine();

            using SqlCommand updateTownsSqlCommand = new(Commands.UpdateTowns, sqlConnection);
            updateTownsSqlCommand.Parameters.AddWithValue("@countryName", countryName);
            int townsUpdated = updateTownsSqlCommand.ExecuteNonQuery();

            StringBuilder builder = new();

            if (townsUpdated > 0)
            {
                builder.AppendLine($"{townsUpdated} town names were affected.");

                using SqlCommand getUpdatedTownNames = new(Commands.GetUpdatedTownNames, sqlConnection);
                getUpdatedTownNames.Parameters.AddWithValue("@countryName", countryName);
                using SqlDataReader dataReader = getUpdatedTownNames.ExecuteReader();

                List<string> townNames = [];

                if (dataReader.HasRows)
                {
                    builder.Append('[');

                    while (dataReader.Read())
                    {
                        townNames.Add($"{dataReader[0]}");
                    }

                    builder.Append(string.Join(", ", townNames));
                    builder.Append(']');
                }
            }
            else
            {
                builder.AppendLine("No town names were affected.");
            }

            return builder.ToString();
        }
    }
}
