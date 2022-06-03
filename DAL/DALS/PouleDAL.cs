using GamesCompDAL.Interface;
using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompDAL.DALS
{
    class PouleDAL : IPouleDAL
    {
        private const string Connectionstring =
            "Data Source=LAPTOP-39NSUQTM\\SQLEXPRESS;Initial Catalog = GamesComp; Integrated Security = True";
        public PouleDto[] GetALL()
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "SELECT * FROM [Poule] " +
                "Where PouleName = @PouleName" +
                "Order By Score, Advantage DESC";
            using var cmd = new SqlCommand(sql, connection);

            using SqlDataReader rdr = cmd.ExecuteReader();
            List<PouleDto> PouleDtos = new List<PouleDto>();

            while (rdr.Read())
            {
                PouleDto dto = new PouleDto
                {
                    PouleId = Convert.ToInt32(rdr["PouleID"]),
                    PouleName = Convert.ToString(rdr["PouleName"]),
                    Score = Convert.ToInt32(rdr["Score"]),
                    Advantage = Convert.ToInt32(rdr["Advantage"]),
                };
                PouleDtos.Add(dto);
            }
            connection.Close();

            return PouleDtos.ToArray();
        }

        public int CreatePoule(PouleDto pouleDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "INSERT INTO [Poule] " +
                               "VALUES(@PouleName, @Score, @Advantage)";


            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@Name", pouleDto.PouleName);
                cmd.Parameters.AddWithValue("@FinalScore", pouleDto.Score);
                cmd.Parameters.AddWithValue("@MatchDate", pouleDto.Advantage);
                try
                {
                    RowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return RowsAffected;
        }

        public int DeletePoule(PouleDto pouleDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Delete from [Poule] " +
                "Where PouleID = @PouleID";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@MatchId", pouleDto.PouleId);
                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }

        public int UpdatePoule(PouleDto pouleDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Update [Poule] " +
                "Set [PouleName] = @PouleName" +
                "[Score] = @Score" +
                "[Advantage] = @Advantage" +
                "Where PouleID = @PouleID";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("PouleId", pouleDto.PouleId);
                cmd.Parameters.AddWithValue("@PouleName", pouleDto.PouleName);
                cmd.Parameters.AddWithValue("@Score", pouleDto.Score);
                cmd.Parameters.AddWithValue("@Advantage", pouleDto.Advantage);

                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }
    }
}
