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
        private string qry_insert = "INSERT INTO Artists (ArtistName, AlbumName, ImageUrl, ReleaseDate, Price, SampleUrl) " +
                                    "values (@ArtistName, @AlbumName, @ImageUrl, @ReleaseDate, @Price, @SampleUrl)";
        private string qry_update = "UPDATE Artists set ArtistName=@ArtistName, AlbumName=@AlbumName, ImageUrl=@ImageUrl, ReleaseDate=@ReleaseDate, Price=@Price, SampleUrl=@SampleUrl " +
                                    "WHERE ArtistID = @ArtistID";
        private string qry_delete = "DELETE Artists WHERE ArtistID = @ID";

        public ArtistsProvider(string conn_string)
        {
            this.conn_str = conn_string;
        }

        public int Add(Artists data)
        {
            using (var conn = new SqlConnection(conn_str))
            {
                int row = conn.Execute(qry_insert, data);
                return row;
            }
        }

        public int Delete(int id)
        {
            using (var conn = new SqlConnection(conn_str))
            {
                int row = conn.Execute(qry_delete, new { ID = id});
                return row;
            }
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

        public Artists Get(int id)
        {
            using (var conn = new SqlConnection(conn_str))
            {
                Artists artists = conn.QueryFirstOrDefault<Artists>("Select * from Artists where ArtistID = @ID", new { ID = id });
                return artists;
            }
        }

        public int Update(Artists data)
        {

            using (var conn = new SqlConnection(conn_str))
            {
                int row = conn.Execute(qry_update, data);
                return row;
            }
        }
    }
}
