namespace Aspire.Hosting.ApplicationModel;

public sealed class MinioResource : ContainerResource, IResourceWithConnectionString
{
    public MinioResource(string name, string? accessKey = null, string? secretKey=null)
        : base(name)
    {
        this.accessKey = accessKey;
        this.secretKey = secretKey;
    }

    internal const string ApiEndpointName = "api";
    internal const string ConsoleEndpointName = "console";

    private EndpointReference? apiReference;
    public EndpointReference ApiEndpoint =>
        apiReference ??= new(this, ApiEndpointName);

    private EndpointReference? consoleReference;
    public EndpointReference ConsoleEndpoint =>
        consoleReference ??= new(this, ConsoleEndpointName);

    private string? accessKey;
    public string AccessKey => accessKey ??= Guid.NewGuid().ToString();
    private string? secretKey;
    public string SecretKey => secretKey ??= Guid.NewGuid().ToString();

    public ReferenceExpression ConnectionStringExpression =>
            ReferenceExpression.Create(
                $"minio://{AccessKey}:{SecretKey}@{ApiEndpoint.Property(EndpointProperty.Host)}:{ApiEndpoint.Property(EndpointProperty.Port)}"
            );
}