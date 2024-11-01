namespace Pericia.Aspire.Minio.SampleApp.Models
{
    public class IndexViewModel
    {
        public required string ContainerName { get; set; }

        public bool ContainerExists { get; set; }    
        
    }
}
