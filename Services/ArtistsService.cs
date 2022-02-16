using System;
using System.Collections.Generic;
using Artists_API.Models;
using Artists_API.Repositories;

namespace Artists_API.Services
{
  public class ArtistsService
  {
    private readonly ArtistsRepository _repo;

    public ArtistsService(ArtistsRepository repo)
    {
      _repo = repo;
    }

    internal List<Artist> Get()
    {
      List<Artist> artists = _repo.Get();
      return artists;
    }

    internal Artist Get(int id)
    {
      Artist artist = _repo.Get(id);
      if (artist == null)
      {
        throw new Exception("Invalid Id");
      }

      return artist;
    }

    internal Artist Create(Artist newArtist)
    {
      Artist artist = _repo.Create(newArtist);
      return artist;
    }

    internal Artist Update(Artist updates)
    {
      Artist original = Get(updates.Id);

      original.Name = updates.Name;
      original.YearOfBirth = updates.YearOfBirth != 0 ? updates.YearOfBirth : original.YearOfBirth;
      original.YearOfDeath = updates.YearOfDeath != null ? updates.YearOfDeath : original.YearOfDeath;
      // NOTE only for bools we can create a 'null' instead of the default false by adding ? to the bool in the model
      // this now checks if the value is null (it was not provided by the user) then it does not change the original value
      original.IsDead = updates.IsDead != null ? updates.IsDead : original.IsDead;

      _repo.Update(original);
      return original;

    }
    internal void Delete(int id)
    {
      Get(id);
      _repo.Delete(id);
    }


  }
}