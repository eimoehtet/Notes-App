using Dapper;
using Microsoft.Data.SqlClient;
using NotesAPI.Models;

namespace NotesAPI.Repositories
{
    public class NotesRepository
    {
        private readonly string _connectionString;

        public NotesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> CreateNote(Note note)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Notes (Title, Content, CreatedAt, UpdatedAt) VALUES (@Title, @Content, GETDATE(), GETDATE()); SELECT SCOPE_IDENTITY();";
            return await connection.ExecuteScalarAsync<int>(sql, note);
        }

        
        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Notes ORDER BY CreatedAt DESC";
            return await connection.QueryAsync<Note>(sql);
        }

        public async Task<Note?> GetNoteById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "SELECT * FROM Notes WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Note>(sql, new { Id = id });
        }

        public async Task<bool> UpdateNote(Note note)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Notes SET Title = @Title, Content = @Content, UpdatedAt = GETDATE() WHERE Id = @Id";
            var result = await connection.ExecuteAsync(sql, note);
            return result > 0;
        }
        public async Task<bool> DeleteNote(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Notes WHERE Id = @Id";
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
