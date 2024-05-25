var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DotnetLearning_Api>("dotnetlearning-api");

builder.AddNpmApp("react", "../DotnetLearning.Front")
    .WithEnvironment("BROWSER", "none")
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();
