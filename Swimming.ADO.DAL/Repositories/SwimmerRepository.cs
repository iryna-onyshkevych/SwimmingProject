using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories.Connection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class SwimmerRepository : ISwimmerManager<Swimmer>
    {
        private readonly IConnection _context;
        public SwimmerRepository(IConnection context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression3 = ($"DELETE FROM Swimmers WHERE Id = {id}");
            SqlCommand command = new SqlCommand(sqlExpression3, sql);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public Swimmer Add(Swimmer swimmer)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression1 = ($"INSERT INTO Swimmers (FirstName,LastName, Age,CoachId) VALUES ('{swimmer.FirstName}','{swimmer.LastName}',{swimmer.Age},{swimmer.CoachId})");
            SqlCommand command = new SqlCommand(sqlExpression1, sql);
            command.ExecuteNonQuery();
            return swimmer;
            sql.Close();
        }

        public IEnumerable<Swimmer> GetList()
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression4 = "SELECT * FROM Swimmers";
            SqlCommand command = new SqlCommand(sqlExpression4, sql);
            SqlDataReader reader = command.ExecuteReader();
            List<Swimmer> swimmers = new List<Swimmer>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Swimmer swimmer = new Swimmer()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Age = reader.GetInt32(3),
                        CoachId = reader.GetInt32(4)

                    };

                    swimmers.Add(swimmer);
                }

                reader.Close();
            }
            sql.Close();
            IEnumerable<Swimmer> listOfSwimmers = swimmers;
            return listOfSwimmers;
        }

        public IEnumerable<Swimmer> GetListByAge(int mimimalAge)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            SqlParameter param1 = new SqlParameter("@age", mimimalAge);
            string sqlExpression = "GetSwimmersByAge";
            List<Swimmer> swimmers = new List<Swimmer>();
            SqlCommand command = new SqlCommand(sqlExpression, sql);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter
            {
                ParameterName = "@age",
                Value = mimimalAge
            };

            command.Parameters.Add(nameParam);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Swimmer swimmer = new Swimmer()
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Age = reader.GetInt32(3),

                    };
                    swimmers.Add(swimmer);
                }
                reader.Close();
            }

            sql.Close();
            IEnumerable<Swimmer> listOfSwimmers = swimmers;
            return listOfSwimmers;
        }

        public Swimmer Update(int id, Swimmer swimmer)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression2 = ($"UPDATE Swimmers SET FirstName ='{swimmer.FirstName}',LastName ='{swimmer.LastName}'," +
                $"Age ={swimmer.Age}, CoachId = {swimmer.CoachId}   WHERE Id={id}");
            SqlCommand command = new SqlCommand(sqlExpression2, sql);
            command.ExecuteNonQuery();
            sql.Close();
            return swimmer;
        }
    }
}
