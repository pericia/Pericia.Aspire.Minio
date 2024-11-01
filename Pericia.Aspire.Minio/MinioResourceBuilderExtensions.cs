using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

public static class MinioResourceBuilderExtensions
{
    /// <summary>
    /// Adds the <see cref="MinioResource"/> to the given
    /// <paramref name="builder"/> instance.
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/>.</param>
    /// <param name="name">The name of the resource.</param>
    /// <param name="apiPort">The S3 API port</param>
    /// <param name="consolePort">The MinIO console port</param>
    /// <returns>
    /// An <see cref="IResourceBuilder{MinioResource}"/> instance that
    /// represents the added MinIO resource.
    /// </returns>
    public static IResourceBuilder<MinioResource> AddMinio(
        this IDistributedApplicationBuilder builder,
        string name,
        int? apiPort = null,
        int? consolePort = null,
        string? accessKey = null, 
        string? secretKey = null)
    {
        var resource = new MinioResource(name, accessKey, secretKey);

        return builder.AddResource(resource)
                      .WithImage("minio/minio")
                      .WithImageTag("latest")
                      .WithEnvironment("MINIO_ROOT_USER", resource.AccessKey)
                      .WithEnvironment("MINIO_ROOT_PASSWORD", resource.SecretKey)
                      .WithHttpEndpoint(
                            targetPort: 9000,
                            port: apiPort,
                            name: MinioResource.ApiEndpointName)
                      .WithHttpEndpoint(
                            targetPort: 9001,
                            port: consolePort,
                            name: MinioResource.ConsoleEndpointName)
                      .WithArgs("server", "/data", "--console-address", ":9001");
    }

}
