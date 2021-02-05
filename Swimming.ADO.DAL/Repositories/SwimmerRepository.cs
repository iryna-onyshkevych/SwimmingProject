using Swimming.Abstractions.Interfaces;
using Swimming.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Swimming.ADO.DAL.Repositories
{
    public class SwimmerRepository : ISwimmerManager<Swimmer>
    {
        private readonly SqlConnection _context;

        public SwimmerRepository(SqlConnection context)
        {
            _context = context;
        }
        public void Delete(int id)
        {

            string sqlExpression3 = String.Format("DELETE FROM Swimmers WHERE Id = {id}");

            SqlCommand command = new SqlCommand(sqlExpression3, _context);
            int number = command.ExecuteNonQuery();


        }
        public Swimmer Add(Swimmer swimmer)
        {

            string sqlExpression1 = ($"INSERT INTO Swimmers (FirstName,LastName, Age,CoachId) VALUES ('{swimmer.FirstName}','{swimmer.LastName}',{swimmer.Age},{swimmer.CoachId})");
            SqlCommand command = new SqlCommand(sqlExpression1, _context);
            int number = command.ExecuteNonQuery();

            return swimmer;
        }

        public IEnumerable<Swimmer> GetList()
        {


            string sqlExpression4 = "SELECT * FROM Swimmers";

            SqlCommand command = new SqlCommand(sqlExpression4, _context);
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

                    };
                    swimmers.Add(swimmer);
                }

                reader.Close();



            }
            IEnumerable<Swimmer> listOfSwimmers = swimmers;
            return listOfSwimmers;
        }
        public IEnumerable<Swimmer> GetListByAge(int mimimalAge)
        {
            SqlParameter param1 = new SqlParameter("@age", mimimalAge);

            string sqlExpression = "GetSwimmersByAge";
            List<Swimmer> swimmers = new List<Swimmer>();

            SqlCommand command = new SqlCommand(sqlExpression, _context);
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
            IEnumerable<Swimmer> listOfSwimmers = swimmers;
            return listOfSwimmers;
        }

        public Swimmer Update(int id, Swimmer swimmer)
        {

            string sqlExpression2 = ($"UPDATE Swimmers SET FirstName ='{swimmer.FirstName}',LastName ='{swimmer.LastName}'," +
                $"Age ={swimmer.Age}, CoachId = {swimmer.CoachId}   WHERE Id={id}");


            SqlCommand command = new SqlCommand(sqlExpression2, _context);
            int number = command.ExecuteNonQuery();

            return swimmer;
        }
    }
}
