using Dapper;
using Microsoft.Extensions.Options;
using SEDC.WebApi.Workshop.Notes.Common.Models;
using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.WebApi.Workshop.Notes.DataAccess.Repositories
{
    public class NoteDapperRepository : IRepository<Note>
    {
        private readonly string _connectionString;

        public NoteDapperRepository(IOptions<AppSettings> options)
        {
            _connectionString = options.Value.ConnectionString; 
        }

        public int Delete(Note entity)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            var sqlQuery = @"DELETE FROM dbo.Note WHERE Id = @id";
            conn.Open();
            conn.Query(sqlQuery, new { id = entity.Id });
            return entity.Id;
        }

        public IEnumerable<Note> FilterBy(Func<Note, bool> filter)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            var query = @"SELECT * FROM dbo.Note";
            conn.Open();
            var ids = new int[] { 1, 2, 3, 4 };

            var notes = conn.Query<Note>(query).Where(filter);
            return notes;
        }

        public IEnumerable<Note> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlQuery = @"SELECT * FROM dbo.Note";
                conn.Open();
                var notes = conn.Query<Note>(sqlQuery);
                return notes;
            }
        }

        public Note GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlQuery = @"SELECT * FROM dbo.Note n
                    WHERE Id = @id";
                conn.Open();
                return conn.Query<Note>(sqlQuery, new {id}).FirstOrDefault();
                
            }
        }

        public int Insert(Note entity)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            var sqlQuery = @"INSERT INTO dbo.Note ([Text], [Color], [Tag], [UserId]) 
                    VALUES(@text, @color, @tag, @userId)";
            conn.Open();
            conn.Query(sqlQuery, new
            {
                text = entity.Text,
                color = entity.Color,
                tag = entity.Tag,
                userId = entity.UserId
            });
            return entity.Id;
        }

        public int Update(Note entity)
        {
            using SqlConnection conn = new SqlConnection (_connectionString);
            var sqlQuery = @"UPDATE dbo.Note 
                    SET Text = @noteText,
                        Color = @noteColor
                        Tag = @noteTag
                        UserId = @noteUserId
                        WHERE Id = @id";
            conn.Open();

            conn.Query(sqlQuery, new
            {
                id = entity.Id,
                text = entity.Text,
                color = entity.Color,
                tag = entity.Tag,
                userId = entity.UserId
            });
            return entity.Id;
        }
    }
}
