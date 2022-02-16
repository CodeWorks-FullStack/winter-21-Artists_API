using System;
using System.Collections.Generic;
using Artists_API.Models;
using Artists_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Artists_API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _arts;

    public ArtistsController(ArtistsService arts)
    {
      _arts = arts;
    }

    [HttpGet]
    public ActionResult<List<Artist>> Get()
    {
      try
      {
        List<Artist> artists = _arts.Get();
        return Ok(artists);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Artist> Get(int id)
    {
      try
      {
        Artist artist = _arts.Get(id);
        return Ok(artist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Artist> Create([FromBody] Artist newArtist)
    {
      try
      {
        Artist artist = _arts.Create(newArtist);
        return Ok(artist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<Artist> Update([FromBody] Artist updates, int id)
    {
      try
      {
        // set the ID based on parameters
        updates.Id = id;
        Artist artist = _arts.Update(updates);
        return Ok(artist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _arts.Delete(id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}