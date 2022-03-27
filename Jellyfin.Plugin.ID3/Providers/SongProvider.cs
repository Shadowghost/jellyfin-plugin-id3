using System;
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
                Artists = track.Artist.Split(Settings.DisplayValueSeparator),
                Album = track.Album,
                AlbumArtists = track.AlbumArtist.Split(Settings.DisplayValueSeparator),
                IndexNumber = track.TrackNumber,
                ParentIndexNumber = track.DiscNumber,
                Overview = track.Description,
                Genres = track.Genre.Split(Settings.DisplayValueSeparator),
                ProductionYear = track.Year,
                PremiereDate = track.PublishingDate
            }
        };

        return Task.FromResult(metadataResult);
    }
}
