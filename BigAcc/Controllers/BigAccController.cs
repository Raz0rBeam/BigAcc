using System.IO;
using System.Linq;
using System.Reflection;
using Zenject;
using UnityEngine;
using IPA.Loader;
using BigAcc.Configuration;
using BigAcc.Installers;

namespace BigAcc
{

    public class BigAccController : IInitializable
    {
        private readonly IDifficultyBeatmap difficultyBeatmap;
        public GameObject bigAcc = GameObject.Find("RelativeScoreText");
        public GameObject RankText = GameObject.Find("ImmediateRankText");
        private PluginConfig config = PluginConfig.Instance;
        
        // Moving the accuracy UI component to the specified area according to the config.
        public void Initialize()
        {
            float scale = config.AccSize * 2;
            float negativeScale = (scale - (scale * 2)) * 10;
            float offset = config.AccOffset * 2.5f;

             if (config.EnableMod == true && BAInstaller.isAdvancedHUD == true)
             {
                if (IsNoodleMap(difficultyBeatmap) == false)
                {
                    bigAcc.transform.name = "Big Acc";
                    if (scale != 0)
                    {
                        bigAcc.transform.localScale = new Vector3(scale, scale, scale);
                    }

                    if (config.MoveToPlatform == true)
                    {
                        bigAcc.transform.position = new Vector3(0f, 0.1f, offset);
                        bigAcc.transform.Rotate(86.7f, 0f, 0f);
                        var RankText = GameObject.Find("ImmediateRankText");
                        RankText.transform.localPosition = new Vector3(RankText.transform.localPosition.x, 11f, RankText.transform.localPosition.z);
                    }
                    else
                    {
                        var RankText = GameObject.Find("ImmediateRankText");
                        RankText.transform.localPosition = new Vector3(RankText.transform.localPosition.x, negativeScale - 1, RankText.transform.localPosition.z);
                    }
                }
             }

        }

        internal BigAccController(IDifficultyBeatmap _difficultyBeatmap)
        {
            difficultyBeatmap = _difficultyBeatmap;
        }

        public bool IsNoodleMap(IDifficultyBeatmap level)
        {
            // thanks to bobbie's custom notes mod for this section
            if (PluginManager.EnabledPlugins.Any(x => x.Name == "SongCore") && PluginManager.EnabledPlugins.Any(x => x.Name == "NoodleExtensions"))
            {
                bool isIsNoodleMap = SongCore.Collections.RetrieveDifficultyData(level)?
                    .additionalDifficultyData?
                    ._requirements?.Any(x => x == "Noodle Extensions") == true;
                return isIsNoodleMap;
            }
            else return false;
        }
    }
}
