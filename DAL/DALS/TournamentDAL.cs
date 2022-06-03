using GamesCompDAL.IDAL;
using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TournamentDAL : ITournamentDAL
    {
        private const string Connectionstring =
            "Data Source=LAPTOP-39NSUQTM\\SQLEXPRESS;Initial Catalog = GamesComp; Integrated Security = True";
        public TournamentDto[] GetALL()
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "SELECT * FROM [Tournament]";
            using var cmd = new SqlCommand(sql, connection);

            using SqlDataReader rdr = cmd.ExecuteReader();
            List<TournamentDto> TournamentDtos = new List<TournamentDto>();

            while (rdr.Read())
            {
                TournamentDto dto = new TournamentDto
                {
                    TournamentId = Convert.ToInt32(rdr["TournamentID"]),
                    Winner = Convert.ToString(rdr["Winner"]),
                    Game = Convert.ToString(rdr["Game"]),
                    Region = Convert.ToString(rdr["Region"]),
                };
                TournamentDtos.Add(dto);
            }
            connection.Close();

            return TournamentDtos.ToArray();
        }
        public TournamentDto GetInfo(int id)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();
            TournamentDto dto = new();

            const string sql = "Select * FROM [Tournament] " +
                               "Where TournamentID = @TournamentID";

            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@TournamentID", id);
                using SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read()) 
            {
                dto = new()
                {

                    Winner = Convert.ToString(rdr["Winner"]),
                    Game = Convert.ToString(rdr["Game"]),
                    Region = Convert.ToString(rdr["Region"])
                };
            }
            }

            connection.Close();

            return dto;
        }
        public int CreateTournament(TournamentDto tournamentDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "INSERT INTO [Tournament] " +
                               "VALUES(@Winner, @Game, @Region)";


            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@Winnner", tournamentDto.Winner);
                cmd.Parameters.AddWithValue("@Game", tournamentDto.Game);
                cmd.Parameters.AddWithValue("@Region", tournamentDto.Region);
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

        public int DeleteTournament(TournamentDto tournamentDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Delete from [Tournament] " +
                "Where TournamentID = @TournamentID";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@TournamentID", tournamentDto.TournamentId);
                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }

        public int UpdateTournament(TournamentDto tournamentDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Update [Tournament] " +
                "Set [Winner] = @Winner" +
                "[Game] = @Game" +
                "[Region] = @Region" +
                "Where TournamentID = @TournamentID";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@TournamentID", tournamentDto.TournamentId);
                cmd.Parameters.AddWithValue("@Winner", tournamentDto.Winner);
                cmd.Parameters.AddWithValue("@Game", tournamentDto.Game);
                cmd.Parameters.AddWithValue("@Region", tournamentDto.Region);

                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }
    }
}
