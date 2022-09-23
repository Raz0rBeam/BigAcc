using System;
using Zenject;
using UnityEngine;

namespace BigAcc
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class BigAccController : IInitializable
    {
        public void Initialize()
        {
            var bigAcc = GameObject.Find("RelativeScoreText");
            bigAcc.transform.name = "Big Acc";
            bigAcc.transform.position = new Vector3(0f, 0.32f, 10f);
            bigAcc.transform.localScale = new Vector3(8f, 8f, 8f);
            bigAcc.transform.Rotate(85.71f, 0f, 0f);

            var rank = GameObject.Find("ImmediateRankText");
            rank.transform.position = new Vector3(-3.20f, 1.1f, 7f);
        }
    }
}
