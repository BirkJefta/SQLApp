using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLApp {
    public class Wildcard {

        public Wildcard() { }

        //giver adgang til at søge men kun i et view. 
        public void WildcardTitle(string connectionstring, string searchterm)
        {
            using (var sqlConn = new SqlConnection(connectionstring))
            {
                sqlConn.Open();
                string sql = "SELECT * FROM dbo.WildCardTitle WHERE PrimaryTitle LIKE @searchterm ORDER BY PrimaryTitle ASC";
                using (var sqlCmd = new SqlCommand(sql, sqlConn))
                {
                    sqlCmd.Parameters.AddWithValue("@searchterm", "%" + searchterm + "%");
                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        int lines = 0;
                        while (reader.Read())
                        {
                           
                            Console.WriteLine(
                                            $"line {++lines}: " +
                                            $"Id: {reader["Id"]}, " +
                                            $"TypeId: {reader["TypeId"]}, " +
                                            $"PrimaryTitle: {reader["PrimaryTitle"]}, " +
                                            $"OriginalTitle: {reader["OriginalTitle"]}, " +
                                            $"IsAdult: {reader["IsAdult"]}, " +
                                            $"StartYear: {reader["StartYear"]}, " +
                                            $"EndYear: {reader["EndYear"]}, " +
                                            $"RuntimeMinutes: {reader["RuntimeMinutes"]}"
                                           
                            );
                        }
                    }
                }
            }
        }
        //samme bare i name view
        public void WildcardName(string connectionstring, string searchterm)
        {
            using (var sqlConn = new SqlConnection(connectionstring))
            {
                sqlConn.Open();
                string sql = "SELECT Id,PrimaryName, BirthYear, DeathYear FROM dbo.WildCardName WHERE PrimaryName LIKE @searchterm ORDER BY PrimaryName ASC";
                using (var sqlCmd = new SqlCommand(sql, sqlConn))
                {
                    sqlCmd.Parameters.AddWithValue("@searchterm", "%" + searchterm + "%");
                    using (var reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["PrimaryName"].ToString());
                        }
                    }
                }
            }
        }
        //kan opdaterer via stored procedure
        public void UpdateMovie(string adminstring,Title updatedTitle, int id) //Lav en bruger der har et id der findes i Title tabellen, tilføj derefter titlen så den kan opdaterer
        {
            using (var sqlConn = new SqlConnection(adminstring))
            {
                
                using (var sqlCmd = new SqlCommand("UpdateTitle", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@id", id);
                    sqlCmd.Parameters.AddWithValue("@TypeId", updatedTitle.TypeId);
                    sqlCmd.Parameters.AddWithValue("@primaryTitle", updatedTitle.PrimaryTitle);
                    sqlCmd.Parameters.AddWithValue("@OriginalTitle", updatedTitle.OriginalTitle ?? (object)DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@IsAdult", updatedTitle.IsAdult);
                    sqlCmd.Parameters.AddWithValue("@StartYear", updatedTitle.StartYear ?? (object)DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@EndYear", updatedTitle.EndYear ?? (object)DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@RuntimeMinutes", updatedTitle.RuntimeMinutes ?? (object)DBNull.Value);

                    sqlConn.Open();
                    int rowsAffected = sqlCmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated.");

                }
            }
        }
        //kan tilføje via stored procedure i title tabellen
        public void AddMovie(string adminstring, Title newMovie) //Lav en bruger der har et id der findes i Title tabellen, tilføj derefter titlen så den kan opdaterer
        {
            using (var sqlConn = new SqlConnection(adminstring))
            {

                using (var sqlCmd = new SqlCommand("AddMovie", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@TitleType", newMovie.TypeId);
                    sqlCmd.Parameters.AddWithValue("@primaryTitle", newMovie.PrimaryTitle);
                    sqlCmd.Parameters.AddWithValue("@originalTitle", newMovie.OriginalTitle ?? (object)DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@isAdult", newMovie.IsAdult);
                    sqlCmd.Parameters.AddWithValue("@startYear", newMovie.StartYear ?? (object)DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@endYear", newMovie.EndYear ?? (object)DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@runtimeMinutes", newMovie.RuntimeMinutes ?? (object)DBNull.Value);

                    sqlConn.Open();
                    int rowsAffected = sqlCmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated.");

                }
            }
        }
        //kan tilføje via stored procedure i name tabellen
        public void AddName(string adminstring, Name name ) //Lav en bruger der har et id der findes i Title tabellen, tilføj derefter titlen så den kan opdaterer
        {
            using (var sqlConn = new SqlConnection(adminstring))
            {

                using (var sqlCmd = new SqlCommand("AddName", sqlConn))
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@primaryName", name.PrimaryName);
                    sqlCmd.Parameters.AddWithValue("@birthYear", name.BirthYear ?? (object)DBNull.Value);
                    sqlCmd.Parameters.AddWithValue("@deathYear", name.DeathYear ?? (object)DBNull.Value);
                  

                    sqlConn.Open();
                    int rowsAffected = sqlCmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) updated.");

                }
            }
        }


    }
}
