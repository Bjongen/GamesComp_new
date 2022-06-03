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
    class MatchDAL : IMatchDAL
    {
        private const string Connectionstring =
            "Data Source=LAPTOP-39NSUQTM\\SQLEXPRESS;Initial Catalog = GamesComp; Integrated Security = True";
        public MatchDto[] GetALL()
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "SELECT * FROM [Match]";
            using var cmd = new SqlCommand(sql, connection);

            using SqlDataReader rdr = cmd.ExecuteReader();
            List<MatchDto> MatchDtos = new List<MatchDto>();

            while (rdr.Read())
            {
                MatchDto dto = new MatchDto
                {
                    MatchId = Convert.ToInt32(rdr["MatchID"]),
                    MatchName = Convert.ToString(rdr["MatchName"]),
                    FinalScore = Convert.ToInt32(rdr["FinalScore"]),
                    MatchDate = Convert.ToDateTime(rdr["MatchDate"]),
                };
                MatchDtos.Add(dto);
            }
            connection.Close();

            return MatchDtos.ToArray();
        }

        public int CreateMatch(MatchDto matchDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "INSERT INTO [Match] " +
                               "VALUES(@MatchName, @FinalScore, @MatchDate)";


            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@MatchName", matchDto.MatchName);
                cmd.Parameters.AddWithValue("@FinalScore", matchDto.FinalScore);
                cmd.Parameters.AddWithValue("@MatchDate", matchDto.MatchDate);
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

        public int DeleteAccount(MatchDto matchDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Delete from [Match] " +
                "Where MatchId = @MatchId";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@MatchId", matchDto.MatchId);
                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }

        public int UpdateMatch(MatchDto matchDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Update [Match] " +
                "Set [MatchName] = @MatchName" +
                "[FinalScore] = @FinalScore" +
                "[MatchDate] = @MatchDate" +
                "Where MatchId = @MatchId";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("MatchId", matchDto.MatchId);
                cmd.Parameters.AddWithValue("@MatchName", matchDto.MatchName);
                cmd.Parameters.AddWithValue("@FinalScore", matchDto.FinalScore);
                cmd.Parameters.AddWithValue("@MatchDate", matchDto.MatchDate);

                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }
    }
}
