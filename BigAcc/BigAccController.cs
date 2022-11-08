using System.IO;
using System.Linq;
using System.Reflection;
using Zenject;
using UnityEngine;
using IPA.Loader;
using IPA.Logging;

namespace BigAcc
{

    public class BigAccController : IInitializable
    {
        private readonly IDifficultyBeatmap difficultyBeatmap;
        public GameObject bigAcc = GameObject.Find("RelativeScoreText");
        public GameObject RankText = GameObject.Find("ImmediateRankText");

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

        public void Initialize()
        {
           if (IsNoodleMap(difficultyBeatmap) == false)
            { 
                bigAcc.transform.name = "Big Acc";
                bigAcc.transform.position = new Vector3(0f, 0.32f, 10f);
                bigAcc.transform.localScale = new Vector3(8f, 8f, 8f);
                bigAcc.transform.Rotate(85.71f, 0f, 0f);

                var RankText = GameObject.Find("ImmediateRankText");
                RankText.transform.localPosition = new Vector3(RankText.transform.localPosition.x, 11f, RankText.transform.localPosition.z);
             }   
        }
    }
}
