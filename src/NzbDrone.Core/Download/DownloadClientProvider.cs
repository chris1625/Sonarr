using System.Linq;
using System.Collections.Generic;
using NzbDrone.Core.Indexers;

namespace NzbDrone.Core.Download
{
    public interface IProvideDownloadClient
    {
        IDownloadClient GetDownloadClient(string clientName);
        IEnumerable<IDownloadClient> GetDownloadClients();
        IDownloadClient Get(int id);
    }

    public class DownloadClientProvider : IProvideDownloadClient
    {
        private readonly IDownloadClientFactory _downloadClientFactory;

        public DownloadClientProvider(IDownloadClientFactory downloadClientFactory)
        {
            _downloadClientFactory = downloadClientFactory;
        }

        public IDownloadClient GetDownloadClient(string clientName)
        {
            return _downloadClientFactory.DownloadHandlingEnabled(false).Find(v => v.Definition.Name.Equals(clientName));
            //return _downloadClientFactory.GetAvailableProviders().Find(v => v.Name == clientName);
        }

        public IEnumerable<IDownloadClient> GetDownloadClients()
        {
            return _downloadClientFactory.GetAvailableProviders();
        }

        public IDownloadClient Get(int id)
        {
            return _downloadClientFactory.GetAvailableProviders().Single(d => d.Definition.Id == id);
        }
    }
}
