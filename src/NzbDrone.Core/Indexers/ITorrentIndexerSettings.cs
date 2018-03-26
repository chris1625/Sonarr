namespace NzbDrone.Core.Indexers
{
    public interface ITorrentIndexerSettings : IIndexerSettings
    {
        int MinimumSeeders { get; set; }
        string DownloadClient { get; set; }
    }
}
