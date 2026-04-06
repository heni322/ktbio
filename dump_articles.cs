using Microsoft.Data.SqlClient;
using System;

class Program {
    static void Main() {
        string connectionString = "Server=DESKTOP-TK6HO92\\SQLEXPRESS;Database=KTBIO2014;User Id=sa;Password=SQL2025;TrustServerCertificate=True;Encrypt=False;";
        try {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                string query = @"
                    SELECT TOP 20 a.AR_Ref, a.AR_Design, a.AR_Stat01, a.AR_Stat02, a.FA_CodeFamille
                    FROM F_ARTICLE a
                    JOIN F_LOTSERIE s ON a.AR_Ref = s.AR_Ref
                    WHERE s.LS_QteRestant > 0";
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        Console.WriteLine("AR_Ref | AR_Design | AR_Stat01 | AR_Stat02 | FA_CodeFamille");
                        Console.WriteLine("------------------------------------------------------------");
                        while (reader.Read()) {
                            Console.WriteLine($"{reader["AR_Ref"]} | {reader["AR_Design"]} | {reader["AR_Stat01"]} | {reader["AR_Stat02"]} | {reader["FA_CodeFamille"]}");
                        }
                    }
                }
            }
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
