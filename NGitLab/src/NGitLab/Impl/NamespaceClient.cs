using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class NamespaceClient : INamespaceClient
    {
        private readonly HttpRequestor _httpRequestor;

        public NamespaceClient(HttpRequestor httpRequestor)
        {
            _httpRequestor = httpRequestor;
        }

        public async Task<IEnumerable<Namespace>> Accessible() => await _httpRequestor.GetAll<Namespace>(Namespace.Url);

        public Namespace this[int id] => _httpRequestor.Get<Namespace>(Namespace.Url + "/" + id).Result;

        public async Task<Namespace> CreateAsync(NamespaceCreate group) => await _httpRequestor.With(group).Post<Namespace>(Namespace.Url);

        public async Task DeleteAsync(int id) => await _httpRequestor.Delete(Namespace.Url + "/" + id);
    }
}