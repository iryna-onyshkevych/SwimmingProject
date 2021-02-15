using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories.Connection;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class SwimStyleRepository : ISwimStyleManager<SwimStyle>
    {
        private readonly IConnection _context;
        public SwimStyleRepository(IConnection context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression3 = ($"DELETE FROM SwimStyles WHERE Id = {id}");
            SqlCommand command = new SqlCommand(sqlExpression3, sql);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public SwimStyle Add(SwimStyle swimStyle)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression1 = ($"INSERT INTO SwimStyles (StyleName) VALUES ('{ swimStyle.StyleName}')");
            SqlCommand command = new SqlCommand(sqlExpression1, sql);
            command.ExecuteNonQuery();
            sql.Close();
            return swimStyle;
        }

        public IEnumerable<SwimStyle> GetList()
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression4 = "SELECT * FROM SwimStyles";
            SqlCommand command = new SqlCommand(sqlExpression4, sql);
            SqlDataReader reader = command.ExecuteReader();
            List<SwimStyle> swimStyles = new List<SwimStyle>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    SwimStyle swimStyle = new SwimStyle()
                    {
                        Id = reader.GetInt32(0),
                        StyleName = reader.GetString(1)
                    };

                    swimStyles.Add(swimStyle);
                }

                reader.Close();
            }

            sql.Close();
            IEnumerable<SwimStyle> listOfSwimStyles = swimStyles;
            return listOfSwimStyles;
        }

        public SwimStyle Update(int id, SwimStyle swimStyle)
        {
            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();
            string sqlExpression2 = ($"UPDATE SwimStyles SET StyleName = '{swimStyle.StyleName}' WHERE Id={id}");
            SqlCommand command = new SqlCommand(sqlExpression2, sql);
            command.ExecuteNonQuery();
            sql.Close();
            return swimStyle;
        }
        public SwimStyle GetSwimStyle(int id)
        {
            string sqlExpression = $"SELECT * FROM SwimStyles WHERE Id = {id}";

            SwimStyle swimStyle = new SwimStyle();

            SqlConnection sql = _context.CreateSqlConnection();
            sql.Open();

            SqlCommand command = new SqlCommand(sqlExpression, sql);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    swimStyle = new SwimStyle
                    {
                        Id = reader.GetInt32(0),
                        StyleName = reader.GetString(1)
                    };
                }
            }

            sql.Close();
            return swimStyle;
        }
    }
}
