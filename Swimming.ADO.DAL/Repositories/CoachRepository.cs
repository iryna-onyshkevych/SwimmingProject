using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class CoachRepository:ICoachManager<Coach>
    {
        private readonly SqlConnection _context;

        public CoachRepository(SqlConnection context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            string sqlExpression3 = ($"DELETE FROM Coaches WHERE Id = {id}");
            SqlCommand command = new SqlCommand(sqlExpression3, _context);
            command.ExecuteNonQuery();
        }

        public Coach Add(Coach coach)
        {
            string sqlExpression1 = ($"INSERT INTO Coaches (FirstName,LastName, WorkExperience) VALUES ('{coach.FirstName}','{coach.LastName}',{coach.WorkExperience})");
            SqlCommand command = new SqlCommand(sqlExpression1, _context);
            command.ExecuteNonQuery();
            return coach;
        }

        public IEnumerable<Coach> GetList()
        {

            string sqlExpression4 = "SELECT * FROM Coaches";
            SqlCommand command = new SqlCommand(sqlExpression4, _context);
            SqlDataReader reader = command.ExecuteReader();
            List<Coach> coaches = new List<Coach>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Coach coach = new Coach()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        WorkExperience = reader.GetInt32(3)
                    };
                    coaches.Add(coach);
                }
                reader.Close();
            }

            IEnumerable<Coach> listOfCustomers = coaches;
            return listOfCustomers;
        }

        public Coach Update(int id, Coach coach)
        {
            string sqlExpression2 = ($"UPDATE Coaches SET FirstName ='{coach.FirstName}',LastName ='{coach.LastName}'," +
                $"WorkExperience ={coach.WorkExperience}  WHERE Id={id}");
            SqlCommand command = new SqlCommand(sqlExpression2, _context);
            command.ExecuteNonQuery();
            return coach;
        }
    }
}
