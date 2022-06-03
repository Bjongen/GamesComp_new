using GamesCompDAL.Interface;
using GamesCompInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TeamDAL : ITeamDAL
    {
        private const string Connectionstring =
            "Data Source=LAPTOP-39NSUQTM\\SQLEXPRESS;Initial Catalog = GamesComp; Integrated Security = True";

        public TeamDto[] GetAll()
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Select * from [Team]";
            using var cmd = new SqlCommand(sql, connection);

            using SqlDataReader rdr = cmd.ExecuteReader();
            List<TeamDto> teamDtos = new List<TeamDto>();

            while (rdr.Read())
            {
                TeamDto dto = new TeamDto
                {
                    TeamId = Convert.ToInt32(rdr["TeamID"]),
                    TeamName = Convert.ToString(rdr["TeamName"]),
                    Wins = Convert.ToInt32(rdr["Wins"]),
                    SkillRating = Convert.ToInt32(rdr["Wins"])
                };
                teamDtos.Add(dto);
            }
            connection.Close();
            return teamDtos.ToArray();
        }

        public int AddTeam(TeamDto teamDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Insert Into [Team] " +
                "Values(@TeamName, @Wins, @SkillRating)";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@TeamName", teamDto.TeamName);
                cmd.Parameters.AddWithValue("@Wins", teamDto.Wins);
                cmd.Parameters.AddWithValue("SkillRating", teamDto.SkillRating);
                RowsAffected = cmd.ExecuteNonQuery();
            }
            connection.Close();
            return RowsAffected;
        }

        public TeamDto GetById(int id)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Select * From [Team]" +
                "Where TeamID = @TeamID";
            TeamDto dto = new();
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@TeamID", id);
                using SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    dto = new()
                    {
                        TeamName = Convert.ToString(rdr["TeamName"]),
                        Wins = Convert.ToInt32(rdr["Wins"]),
                        SkillRating = Convert.ToInt32(rdr["SkillRating"])
                    };
                }

            }
            connection.Close();

            return dto;
        }
            public List<int> GetId()
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Select TeamID From [Team]";
            using var cmd = new SqlCommand(sql, connection);

            using SqlDataReader rdr = cmd.ExecuteReader();
            List<int> ids = new List<int>();
            while (rdr.Read())
            {
                TeamDto Dto = new TeamDto
                {
                    TeamId = Convert.ToInt32(rdr["TeamID"])
                };
                ids.Add(Dto.TeamId);
            }
            connection.Close();
            return ids;
        }

        public int DeleteTeam(TeamDto teamDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Delete From [Team] " +
                "Where TeamName = @TeamName";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@TeamName", teamDto.TeamName);
                RowsAffected = cmd.ExecuteNonQuery();
            }
            connection.Close();
            return RowsAffected;
        }

        public int EditTeam(TeamDto teamDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Update [Team] " +
                "Set [TeamName] = @TeamName " +
                "Where TeamId = @TeamID";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@TeamID", teamDto.TeamId);
                cmd.Parameters.AddWithValue("@TeamName", teamDto.TeamName);
                RowsAffected = cmd.ExecuteNonQuery();
            }
            connection.Close();
            return RowsAffected;
        }
    }
}
