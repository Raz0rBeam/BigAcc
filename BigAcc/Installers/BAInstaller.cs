using System;
using Zenject;
using UnityEngine;
using BigAcc;

namespace BigAcc.Installers
{
    class BAInstaller : Installer
    {
        [Inject]
        private readonly PlayerDataModel dataModel;
        public static bool isAdvancedHUD;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BigAccController>().AsSingle();

            isAdvancedHUD = dataModel.playerData.playerSpecificSettings.advancedHud;
        }
    }
}
