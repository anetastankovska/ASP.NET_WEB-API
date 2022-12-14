using SEDC.WebApi.Class08.aAdonet.Models;
using System.Data.SqlClient;

namespace SEDC.WebApi.Class08.aAdonet.Services
{
    public class NoteService
    {
        private readonly string _connectionString = "Server=DESKTOP-U613IMF;Database=NotesDb;Trusted_Connection=True";

        public IEnumerable<Note> GetAllNotes()
        {
            SqlConnection connection = new SqlConnection(_connectionString);


            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM dbo.Note";

            SqlDataReader reader = cmd.ExecuteReader();

            List<Note> notes = new List<Note>();

            while (reader.Read())
            {
                var note = new Note
                {
                    Id = (int)reader["Id"],
                    Color = reader["Color"].ToString(),
                    Text = reader["Text"].ToString(),
                    Tag = (int)reader["Tag"],
                    UserId = (int)reader["UserId"]
                };
                notes.Add(note);
            }
            connection.Close();
            return notes;
        }

        public Note GetNoteByUserIdAndNoteId(int userId, int noteId)
        {
            string sqlInjection = $@"0;INSERT INTO dbo.Note (Text, Color, Tag, UserId)
                                        VALUES('Test inj', 'RED', 4, 1)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                //cmd.CommandText = $"SELECT * FROM db.Note WHERE Id = {sqlInjection}"; -- NOT VALID
                cmd.CommandText = "SELECT * FROM dbo.Note WHERE Id = @id and UserId = @userId";
                cmd.Parameters.AddWithValue("@id", noteId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                Note note = null;

                while (reader.Read())
                {
                    note = new Note
                    {
                        Id = (int)reader["Id"],
                        Color = reader["Color"].ToString(),
                        Text = reader["Text"].ToString(),
                        Tag = (int)reader["Tag"],
                        UserId = (int)reader["UserId"]
                    };
                }
                return note;
            }
        }

        public void Add(string text, string color, int tag, int userId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;

                    sqlCommand.CommandText = "INSERT INTO dbo.Note (Text, Color, Tag, UserId) " +
                        "VALUES(@noteText, @noteColor, @noteTag, @noteUserId)";
                    sqlCommand.Parameters.AddWithValue("@noteText", text);
                    sqlCommand.Parameters.AddWithValue("@noteColor", color);
                    sqlCommand.Parameters.AddWithValue("@noteTag", tag);
                    sqlCommand.Parameters.AddWithValue("@noteUserId", userId);

                    // BAD EXAMPLE - potential sql injection attack
                    /*
                    sqlCommand.CommandText = $@"INSERT INTO Notes (Text, Color, Tag, UserId) 
        VALUES('{entity.Text}', '{entity.Color}', {entity.Tag}, {entity.UserId});";
                    */

                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    throw new Exception();
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
