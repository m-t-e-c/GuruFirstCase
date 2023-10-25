using GuruFirstCase.Model;
using GuruFirstCase.UIElements;
using UnityEngine;

namespace GuruFirstCase.Presenters
{
    public class MainMenuPresenter : BasePresenter<MainMenuPresenter>
    {
        [SerializeField] UIButton startGameButton;
        [SerializeField] UIButton quitGameButton;

        MainMenuModel _model;
        
        new void Start()
        {
            base.Start();
            _model = new MainMenuModel();
            
            startGameButton.onClick?.AddListener(()=>
            {
                _model.StartGame();
                Close();
            });
            quitGameButton.onClick?.AddListener(_model.QuitGame);
        }

        void OnDestroy()
        {
            startGameButton.onClick?.RemoveAllListeners();
            quitGameButton.onClick?.RemoveAllListeners();
        }
    }
}