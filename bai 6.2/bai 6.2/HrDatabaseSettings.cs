namespace bai_6._2;

internal static class HrDatabaseSettings
{
    public static string DefaultConnectionString { get; } =
        Environment.GetEnvironmentVariable("HRMDB_CONNECTION_STRING")
        ?? @"Server=(localdb)\MSSQLLocalDB;Database=HRMDB;Trusted_Connection=True;TrustServerCertificate=True;";
}
