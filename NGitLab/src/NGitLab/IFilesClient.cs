using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab
{
    public interface IFilesClient
    {
        Task<FileResponse> CreateAsync(FileUpsert file);
        Task<FileResponse> UpdateAsync(FileUpsert file);
        Task DeleteAsync(FileDelete file);
    }
}