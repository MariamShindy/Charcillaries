using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;

AppDomain.CurrentDomain.UnhandledException += (_, _) => Environment.Exit(1);

var upOption = new Option<bool>("--up", description: "Migrate Up", getDefaultValue: () => false);
var downOption = new Option<long>("--down", description: "Rollback database to a version", getDefaultValue: () => -1);
var snapOption = new Option<short>("--snap", description: "Set Snapshot", getDefaultValue: () => -1);
var envOption = new Option<string>("--env", description: "Set Environment", getDefaultValue: () => "Default");

var rootCommand = new RootCommand("Charcillaries Fluent Migrator Runner")
{
    upOption,
    downOption,
    snapOption,
    envOption
};

rootCommand.SetHandler((up, down, snap, env) =>
{
    var serviceProvider = CreateServices(env);

    using var scope = serviceProvider.CreateScope();
    if (up)
        UpdateDatabase(scope.ServiceProvider);

    if (down > -1)
        RollbackDatabase(scope.ServiceProvider, down);

    if (snap > -1)
        SwitchSnap(scope.ServiceProvider, snap);
}, upOption, downOption, snapOption, envOption);

await rootCommand.InvokeAsync(args);
return;

/// <summary>
/// Configure the dependency injection services
/// </sumamry>
static IServiceProvider CreateServices(string env)
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appSettings.json", true, true)
        .Build();

    var conn = config[$"connectionString:{env}"];

    return new ServiceCollection()
        // Add common FluentMigrator services
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            // Add Postgres support to FluentMigrator
            .AddPostgres()
            // Set the connection string
            .WithGlobalConnectionString(conn)
            // Define the assembly containing the migrations
            .ScanIn(typeof(Tables).Assembly).For.Migrations())
        // Enable logging to console in the FluentMigrator way
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        // Build the service provider
        .BuildServiceProvider(false);
}

static void UpdateDatabase(IServiceProvider serviceProvider)
{
    Console.WriteLine("Going up...");
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

static void RollbackDatabase(IServiceProvider serviceProvider, long rollbackVersion)
{
    Console.WriteLine("Going down...");
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateDown(rollbackVersion);
}

static void SwitchSnap(IServiceProvider serviceProvider, short snap)
{
    Console.WriteLine("Set Snapshot...");
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    switch (snap)
    {
        case 1:
            runner.Processor.Execute("ALTER DATABASE Bias SET ALLOW_SNAPSHOT_ISOLATION ON;");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfully allowed snapshot !!!");
            break;

        case 0:
            runner.Processor.Execute("ALTER DATABASE Bias SET ALLOW_SNAPSHOT_ISOLATION OFF;");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfully denied snapshot !!!");
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Can't change snapshot. Wrong parameter value !!!");
            break;
    }

    Console.ResetColor();
}