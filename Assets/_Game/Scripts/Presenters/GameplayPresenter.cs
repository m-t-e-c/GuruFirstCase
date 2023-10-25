using GuruFirstCase.Model;
using GuruFirstCase.UIElements;
using TMPro;
using UnityEngine;

namespace GuruFirstCase.Presenters
{
    public class GameplayPresenter : BasePresenter<GameplayPresenter>
    {
        [SerializeField] UIButton returnToMenuButton;
        [SerializeField] UIButton createGridButton;

        [Header("Grid Properties")] 
        [SerializeField] GameObject cellPrefab;
        [SerializeField] TMP_InputField gridSizeInputField;

        GameplayModel _model;
        
        new void Start()
        {
            _model = new GameplayModel();
            
            base.Start();
            createGridButton.onClick?.AddListener(() =>
            {
                _model.CreateGrid(cellPrefab, int.Parse(gridSizeInputField.text));
            });
            
            returnToMenuButton.onClick?.AddListener(() =>
            {
                _model.ReturnToMainMenu();
                Close();
            });
        }

        void OnDestroy()
        {
            createGridButton?.onClick.RemoveAllListeners();
        }
    }
}