﻿using IPA;
using BigAcc.Installers;
using IPALogger = IPA.Logging.Logger;
using IPA.Config;
using IPA.Config.Stores;
using BigAcc.Configuration;
using SiraUtil.Zenject;

namespace BigAcc
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        public void Init(IPALogger logger, Zenjector zenject, Config conf)
        {
            Instance = this;
            Log = logger;
            Log.Info("BigAcc initialized.");
            PluginConfig.Instance = conf.Generated<PluginConfig>();

            zenject.Install<BAInstaller>(Location.StandardPlayer);
            zenject.Install<BAUIInstaller>(Location.Menu);

            #region Yippee!
            Log.Info("Yippee!");
            Log.Info("Yippee!");
            Log.Info("Yippee!");
            Log.Info("Yippee!");
            int numberRaw = new System.Random().Next(1, 5);
            string number = numberRaw.ToString();
            if (numberRaw == 2)
            {
                Log.Info("WAHHHHH");
            }
            else
            {
                Log.Info("Yippee!");
            }
            #endregion
        }
    }
}
