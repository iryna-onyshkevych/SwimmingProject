using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories.Connection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class CoachRepository:ICoachManager<Coach>
    {
        private readonly IConnection _context;

        public CoachRepository(IConnection context)
        {
            _context = context;
        }
        
        public void Delete(int id)
        {
            string sqlExpression3 = ($"DELETE FROM Coaches WHERE Id = {id}");
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            SqlCommand command = new SqlCommand(sqlExpression3, sql);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public Coach Add(Coach coach)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression1 = ($"INSERT INTO Coaches (FirstName,LastName, WorkExperience) VALUES ('{coach.FirstName}','{coach.LastName}',{coach.WorkExperience})");
            SqlCommand command = new SqlCommand(sqlExpression1, sql);
            command.ExecuteNonQuery();
            sql.Close();
            return coach;
        }

        public IEnumerable<Coach> GetList()
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression4 = "SELECT * FROM Coaches";
            SqlCommand command = new SqlCommand(sqlExpression4, sql);
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
            sql.Close();

            IEnumerable<Coach> listOfCustomers = coaches;
            return listOfCustomers;
        }

        public Coach Update(int id, Coach coach)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression2 = ($"UPDATE Coaches SET FirstName ='{coach.FirstName}',LastName ='{coach.LastName}'," +
                $"WorkExperience ={coach.WorkExperience}  WHERE Id={id}");
            SqlCommand command = new SqlCommand(sqlExpression2, sql);
            command.ExecuteNonQuery();
            sql.Close();
            return coach;
        }

        public Coach GetCoach(int id)
        {
            string sqlExpression = $"SELECT * FROM Coaches WHERE Id = {id}";
            Coach coach = new Coach();
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            SqlCommand command = new SqlCommand(sqlExpression, sql);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    coach = new Coach
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        WorkExperience = reader.GetInt32(3)
                    };
                }
            }
            sql.Close();
            return coach;
        }
    }
}
