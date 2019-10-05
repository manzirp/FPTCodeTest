using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace FPTCodeTest.Data
{
    public class ArtistsProvider : IArtistsProvider
    {
        private readonly string conn_str;
        public ArtistsProvider(string conn_string)
        {
            this.conn_str = conn_string;
        }
        public IEnumerable<Artists> Get()
        {
            IEnumerable<Artists> artists = null;
            using (var conn = new SqlConnection(conn_str))
            {
                artists = conn.Query<Artists>("Select * from Artists");
            }
            return artists;
        }
    }
}
