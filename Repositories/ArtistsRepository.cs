using System.Collections.Generic;
using System.Data;
using System.Linq;
using Artists_API.Models;
using Dapper;

namespace Artists_API.Repositories
{
  public class ArtistsRepository
  {
    private readonly IDbConnection _db;

    public ArtistsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Artist> Get()
    {
      string sql = "SELECT * FROM artists;";
      // NOTE Query : Find
      List<Artist> artists = _db.Query<Artist>(sql).ToList();
      return artists;
    }

    internal Artist Get(int id)
    {
      string sql = "SELECT * FROM artists WHERE id = @id";
      // DAPPER requires the second argument to be an object, therefore when using a primative type, create a new empty object and add the properties to it
      Artist artist = _db.QueryFirstOrDefault<Artist>(sql, new { id });
      return artist;
    }


    internal Artist Create(Artist newArtist)
    {
      // inside the string the '@' signifies to use the object provided to dapper
      string sql = @"
        INSERT INTO artists
        (name, yearOfBirth, yearOfDeath, isDead)
        VALUES
        (@Name, @YearOfBirth, @YearOfDeath, @IsDead);
        SELECT LAST_INSERT_ID();
      ";
      // Dapper uses the second object to inject the data for the sql string
      int id = _db.ExecuteScalar<int>(sql, newArtist);
      newArtist.Id = id;
      return newArtist;
    }

    internal void Update(Artist original)
    {
      string sql = @"
      UPDATE artists
      SET
        name = @Name,
        yearOfBirth = @YearOfBirth,
        yearOfDeath = @YearOfDeath,
        isDead = @IsDead
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM artists WHERE id = @id LIMIT 1";
      int modified = _db.Execute(sql, new { id });
      if (modified == 0)
      {
        throw new System.Exception("SOMETHING WENT WRONG");
      }
    }
  }
}