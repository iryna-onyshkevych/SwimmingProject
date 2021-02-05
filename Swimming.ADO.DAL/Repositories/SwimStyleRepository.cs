using Swimming.Abstractions.Interfaces;
using Swimming.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Swimming.ADO.DAL.Repositories
{
    public class SwimStyleRepository : ISwimStyleManager<SwimStyle>
    {
        private readonly SqlConnection _context;

        public SwimStyleRepository(SqlConnection context)
        {
            _context = context;
        }
        public void Delete(int id)
        {

            string sqlExpression3 = ($"DELETE FROM SwimStyles WHERE Id = {id}");

            SqlCommand command = new SqlCommand(sqlExpression3, _context);
            command.ExecuteNonQuery();


        }
        public SwimStyle Add(SwimStyle swimStyle)
        {

            string sqlExpression1 = ($"INSERT INTO SwimStyles (StyleName) VALUES ('{ swimStyle.StyleName}')");
            SqlCommand command = new SqlCommand(sqlExpression1, _context);
            command.ExecuteNonQuery();

            return swimStyle;
        }

        public IEnumerable<SwimStyle> GetList()
        {

            string sqlExpression4 = "SELECT * FROM SwimStyles";

            SqlCommand command = new SqlCommand(sqlExpression4, _context);
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
            IEnumerable<SwimStyle> listOfSwimStyles = swimStyles;
            return listOfSwimStyles;
        }

        public SwimStyle Update(int id, SwimStyle swimStyle)
        {
            string sqlExpression2 = ($"UPDATE Coaches SET StyleName = {swimStyle.StyleName} WHERE Id={id}");

            SqlCommand command = new SqlCommand(sqlExpression2, _context);
            command.ExecuteNonQuery();

            return swimStyle;
        }
    }
}
