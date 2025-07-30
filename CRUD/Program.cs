using CRUD.Data;

namespace CRUD;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        var crud = new Crud();
        crud.Database.EnsureCreated();
        
        ApplicationConfiguration.Initialize();
        Application.Run(new View.Form1());

        crud.Database.EnsureDeleted();
    }
}