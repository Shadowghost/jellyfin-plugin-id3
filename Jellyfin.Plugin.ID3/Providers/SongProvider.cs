using System.Threading;
using System.Threading.Tasks;
using ATL;
using MediaBrowser.Controller.Entities.Audio;
using MediaBrowser.Controller.Providers;

namespace Jellyfin.Plugin.ID3.Providers;

/// <summary>
/// ID3 song provider.
/// </summary>
public class SongProvider : ILocalMetadataProvider<Audio>
{
    /// <inheritdoc />
    public string Name => ID3Plugin.Instance!.Name;

    /// <inheritdoc />
    public Task<MetadataResult<Audio>> GetMetadata(ItemInfo info, IDirectoryService directoryService, CancellationToken cancellationToken)
    {
        var track = new Track(info.Path);
        var metadataResult = new MetadataResult<Audio>
        {
            Provider = Name,
            Item = new Audio
            {
                Name = track.Title,
                Artists = new[] { track.Artist },
                Album = track.Album,
                AlbumArtists = new[] { track.AlbumArtist },
                IndexNumber = track.TrackNumber,
                ParentIndexNumber = track.DiscNumber,
                Overview = track.Description,
                Genres = new[] { track.Genre },
                ProductionYear = track.Year
            }
        };

        return Task.FromResult(metadataResult);
    }
}
