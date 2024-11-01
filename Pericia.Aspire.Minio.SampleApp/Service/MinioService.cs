using Minio;
using Minio.DataModel.Args;
using System.ComponentModel;
using System.Threading;

namespace Pericia.Aspire.Minio.SampleApp.Service
{
    public class MinioService : IS3Service
    {
        private IMinioClient client;
        public MinioService(IConfiguration configuration)
        {
            var storageConfig = configuration.GetSection("Storage");

            client = new MinioClient()
                            .WithEndpoint(storageConfig["Host"])
                            .WithCredentials(storageConfig["AccessKey"], storageConfig["SecretKey"])
                            .Build();
        }

        public async Task CreateContainer(string name)
        {
            var args = new MakeBucketArgs().WithBucket(name);
            await client.MakeBucketAsync(args);
        }
    }
}
