using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using BigAcc.Configuration;
using IPA.Loader;
using Zenject;
using SiraUtil.Zenject;
using HMUI;


namespace BigAcc.UI
{
    //This file implements the UI values, and assigns properties to the config file (BigAcc/Configuration/PluginConfig.cs)

    [HotReload(RelativePathToLayout = @"Main.bsml")]
    [ViewDefinition("BigAcc.UI.Main.bsml")]
    internal class MainView : BSMLAutomaticViewController
    {
        PluginConfig config = PluginConfig.Instance;

        [UIComponent("version-text")]
        private readonly CurvedTextMeshPro _versionText = null!;

        [UIValue("version-text-value")]
        private string VersionText => "BigAcc v0.0.3 by Raz0rBeam";

        [UIValue("enable")]
        public bool Enable
        {
            get => config.EnableMod;
            set
            {
                config.EnableMod = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("move-to-platform")]
        public bool MoveToPlatform
        {
            get => config.MoveToPlatform;
            set
            {
                config.MoveToPlatform = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("scale")]
        public float Scale
        {
            get => config.AccSize;
            set
            {
                config.AccSize = value;
                NotifyPropertyChanged();
            }
        }

        [UIValue("offset")]
        public float Offset
        {
            get => config.AccOffset;
            set
            {
                config.AccOffset = value;
                NotifyPropertyChanged();
            }
        }

        [UIAction("#post-parse")]
        internal void PostParse()
        {
            // Code to run after BSML finishes
        }
    }
}
