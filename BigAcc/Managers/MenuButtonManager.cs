using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using BigAcc.UI;
using Zenject;

namespace BigAcc.Managers
{
    internal class MenuButtonManager : IInitializable, IDisposable
    {
        private readonly MenuButton menuButton;
        private readonly MainFlowCoordinator mainFlowCoordinator;
        private readonly BAFlowCoordinator bAFlowCoordinator;

        public MenuButtonManager(MainFlowCoordinator _mainFlowCoordinator, BAFlowCoordinator _bAFC)
        {
            menuButton = new MenuButton(nameof(BigAcc), "you can like... make the acc big", MenuButtonClicked);
            mainFlowCoordinator = _mainFlowCoordinator;
            bAFlowCoordinator = _bAFC;
        }

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(menuButton);
        }

        public void Dispose()
        {
            if (MenuButtons.IsSingletonAvailable)
                MenuButtons.instance.UnregisterButton(menuButton);
        }

        private void MenuButtonClicked()
        {
            mainFlowCoordinator.PresentFlowCoordinator(bAFlowCoordinator);
        }
    }
}
