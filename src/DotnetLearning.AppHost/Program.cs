var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DotnetLearning_Api>("dotnetlearning-api");

builder.AddProject<Projects.DotnetLearning_Front_Server>("dotnetlearning-front-server");

builder.Build().Run();
