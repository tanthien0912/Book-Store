using System.Data.SqlClient;

public class TransactionsRepository
{
    private string connectionString = "your_connection_string_here";

    public void SomeMethod()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            // Thực hiện các thao tác với cơ sở dữ liệu
        }
    }
} 