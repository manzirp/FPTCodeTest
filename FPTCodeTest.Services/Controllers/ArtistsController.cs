using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FPTCodeTest.Data;

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
    }
}