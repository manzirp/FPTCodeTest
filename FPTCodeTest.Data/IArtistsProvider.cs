using System;
using System.Collections.Generic;
using System.Text;

namespace FPTCodeTest.Data
{
    public interface IArtistsProvider
    {
        IEnumerable<Artists> Get();
        Artists Get(int id);
        int Add(Artists data);
        int Update(Artists data);
        int Delete(int id);
    }
}
