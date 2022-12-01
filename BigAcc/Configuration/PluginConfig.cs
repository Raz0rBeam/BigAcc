using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BigAcc.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual bool EnableMod { get; set; } = true;
        public virtual bool MoveToPlatform { get; set; } = true;
        public virtual float AccSize { get; set; } = 5;
        public virtual float AccOffset { get; set; } = 1;
    }
}