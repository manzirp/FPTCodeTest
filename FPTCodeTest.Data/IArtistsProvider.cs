using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCodeTest.Data
{
    public interface IArtistsProvider
    {
        IEnumerable<Artists> Get();
    }
}
