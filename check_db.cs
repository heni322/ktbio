using Microsoft.Data.SqlClient;
using System;

string connectionString = "Server=DESKTOP-TK6HO92\\SQLEXPRESS;Database=KTBIO2014;User Id=sa;Password=SQL2025;TrustServerCertificate=True;Encrypt=False;";

try {
    using (SqlConnection connection = new SqlConnection(connectionString)) {
        connection.Open();
        Console.WriteLine("Connection successful!");

        string[] tables = { "F_ARTICLE", "F_LOTSERIE", "F_DEPOT" };
        foreach (var table in tables) {
            using (SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {table}", connection)) {
                int count = (int)command.ExecuteScalar();
                Console.WriteLine($"Table {table}: {count} records");
            }
        }

        // Test the join
        string joinQuery = @"
                        SELECT COUNT(*)
                        FROM F_LOTSERIE s
                        INNER JOIN F_ARTICLE a ON RTRIM(s.AR_Ref) = RTRIM(a.AR_Ref)
                        WHERE s.LS_QteRestant > 0";
        using (SqlCommand command = new SqlCommand(joinQuery, connection)) {
            int count = (int)command.ExecuteScalar();
            Console.WriteLine($"Join Result: {count} records");
        }
    }
} catch (Exception ex) {
    Console.WriteLine("Error: " + ex.Message);
}
