var builder = DistributedApplication.CreateBuilder(args);

var minio = builder 
                .AddMinio("MinIO", accessKey:"test", secretKey:"test1234")
                .WithLifetime(ContainerLifetime.Persistent);

builder.AddProject<Projects.Pericia_Aspire_Minio_SampleApp>("SampleApp")
        .WithReference(minio)
        .WithEnvironment(ctx =>
        {
            ctx.EnvironmentVariables.Add("Storage__Host",  $"{minio.Resource.ApiEndpoint.Host}:{minio.Resource.ApiEndpoint.Port}");
            ctx.EnvironmentVariables.Add("Storage__AccessKey", minio.Resource.AccessKey);
            ctx.EnvironmentVariables.Add("Storage__SecretKey", minio.Resource.SecretKey);
        });

builder.Build().Run();
