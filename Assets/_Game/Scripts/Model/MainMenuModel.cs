using GuruFirstCase.Interfaces;
using GuruFirstCase.Presenters;
using UnityEngine;

namespace GuruFirstCase.Model
{
    public class MainMenuModel
    {
        readonly IViewManager _viewManager;

        public MainMenuModel()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
        }
        
        public void StartGame()
        {
            _viewManager.LoadView(new LoadViewParams<GameplayPresenter>()
            {
                viewName = "GameplayView"
            });
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}