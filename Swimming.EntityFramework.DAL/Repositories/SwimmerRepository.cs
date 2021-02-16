using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using System.Collections.Generic;
using System.Linq;

namespace Swimming.EntityFramework.DAL.Repositories
{
    public class SwimmerRepository : ISwimmerManager<Swimmer>
    {
        private readonly swimmingContext _context;

        public SwimmerRepository(swimmingContext context)
        {
            _context = context;
        }

        public Swimmer Add(Swimmer swimmer)
        {
            Swimmer newSwimmer = new Swimmer
            {
                FirstName = swimmer.FirstName,
                LastName = swimmer.LastName,
                Age = swimmer.Age,
                CoachId = swimmer.CoachId
            };

            _context.Swimmers.Add(newSwimmer);
            _context.SaveChanges();
            return newSwimmer;
        }

        public void Delete(int id)
        {
            var swimmer = _context.Swimmers.Single(x => x.Id == id);
            _context.Swimmers.Remove(swimmer);
            _context.SaveChanges();
        }

        public IEnumerable<Swimmer> GetList()
        {
            IEnumerable<Swimmer> listOfSwimmers = _context.Swimmers.ToList();
            return listOfSwimmers;
        }

        public IEnumerable<Swimmer> GetListByAge(int mimimalAge)
        {
            SqlParameter param1 = new SqlParameter("@age", mimimalAge);
            var swimmers = _context.Swimmers.FromSqlRaw("GetSwimmersByAge @age ", param1).ToList();
            IEnumerable<Swimmer> listwimmers = swimmers;
            return listwimmers;
        }

        public Swimmer Update(int id, Swimmer swimmer)
        {
            var swimmerToUpdate = _context.Swimmers.Single(x => x.Id == id);
            swimmerToUpdate.FirstName = swimmer.FirstName;
            swimmerToUpdate.LastName = swimmer.LastName;
            swimmerToUpdate.Age = swimmer.Age;
            swimmerToUpdate.CoachId = swimmer.CoachId;
            _context.Swimmers.Update(swimmerToUpdate);
            _context.SaveChanges();
            return swimmerToUpdate;
        }
        public Swimmer GetSwimmer(int id)
        {
            string sqlExpression = $"SELECT * FROM Swimmers WHERE Id = {id}";
            Swimmer swimmer = new Swimmer();
            //SqlConnection sql = _context.CreateSqlConnection();
            //sql.Open();
            //SqlCommand command = new SqlCommand(sqlExpression, sql);
            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        swimmer = new Swimmer
            //        {
            //            Id = reader.GetInt32(0),
            //            FirstName = reader.GetString(1),
            //            LastName = reader.GetString(2),
            //            Age = reader.GetInt32(3),
            //            CoachId = reader.GetInt32(4)
            //        };
            //    }
            //}
            //sql.Close();
            return swimmer;
        }
    }
}
