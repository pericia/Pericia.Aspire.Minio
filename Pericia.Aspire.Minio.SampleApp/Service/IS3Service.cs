
namespace Pericia.Aspire.Minio.SampleApp.Service
{
    public interface IS3Service
    {
        Task CreateContainer(string name);
    }
}