using System;
using Jellyfin.Plugin.ID3.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.ID3;

/// <summary>
/// ID3 plugin entrypoint.
/// </summary>
public class ID3Plugin : BasePlugin<PluginConfiguration>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ID3Plugin"/> class.
    /// </summary>
    /// <param name="applicationPaths">Instance of the <see cref="IApplicationPaths"/> interface.</param>
    /// <param name="xmlSerializer">Instance of the <see cref="IXmlSerializer"/> interface.</param>
    public ID3Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    /// <summary>
    /// Gets current plugin instance.
    /// </summary>
    public static ID3Plugin? Instance { get; private set; }

    /// <inheritdoc />
    public override string Name => "ID3";

    /// <inheritdoc />
    public override Guid Id => new("4DA2BAC0-D167-44B1-970B-4BF75912BC06");
}
