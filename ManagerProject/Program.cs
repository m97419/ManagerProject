// See https://aka.ms/new-console-template for more information
using ManagerProject;


{
    string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=Manager_214364960;Integrated Security=True";

    DataAccess da = new DataAccess();

    da.insertCategory(connectionString);

    da.readCategory(connectionString);

    da.insertProduct(connectionString);

    da.readProducts(connectionString);
}