using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FPTCodeTest.Data;
using Microsoft.AspNetCore.Cors;

namespace FPTCodeTest.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistsProvider artistsProvider;

        public ArtistsController(IArtistsProvider artistsProvider)
        {
            this.artistsProvider = artistsProvider;
        }

        [HttpGet]
        public IEnumerable<Artists> Get()
        {
            return artistsProvider.Get();
        }

        [HttpGet("id")]
        public Artists Get(int id)
        {
            return artistsProvider.Get(id);
        }

        [HttpPost]
        public int Post(Artists data)
        {
            return artistsProvider.Add(data);
        }

        [HttpPut]
        public int Put(Artists data)
        {
            return artistsProvider.Update(data);
        }

        [HttpDelete]
        public int Delete(int id)
        {
            return artistsProvider.Delete(id);
        }
    }
}