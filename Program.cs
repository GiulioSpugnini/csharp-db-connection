using System.Data.SqlClient;

namespace csharp_db_connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";
            using (SqlConnection conn = new SqlConnection(stringaDiConnessione))
            {
                conn.Open();
                using (SqlCommand insert = new SqlCommand(@"insert into clienti (Id, nome, cognome, codice_cliente)
                values(1,'il nome della persona','il cognome della persona',82131)", conn))
                {
                    var numRows = insert.ExecuteNonQuery();
                    Console.WriteLine(numRows);
                }
                using (SqlCommand query = new SqlCommand("select * from clienti"))
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        Console.WriteLine(reader.FieldCount);
                        while (reader.Read())
                        {
                            for(int i=0; i<reader.FieldCount; ++i)
                                Console.WriteLine("{ 0}", reader[i]);
                            Console.WriteLine(reader[0]);
                        }

                    }
                }

            }

        }
    }
}