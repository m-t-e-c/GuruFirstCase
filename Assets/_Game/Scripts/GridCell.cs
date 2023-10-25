using System;
using UnityEngine;

namespace GuruFirstCase
{
    public class GridCell : MonoBehaviour
    {
        [SerializeField] GameObject fillSprite;
        public bool IsFilled { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        Action<GridCell> _onClicked;

        void OnMouseDown()
        {
            if (IsFilled)
            {
                return;
            }

            fillSprite.SetActive(true);
            IsFilled = true;
            _onClicked?.Invoke(this);
        }

        public void Init(int x, int y, Action<GridCell> onClicked)
        {
            X = x;
            Y = y;
            _onClicked = onClicked;
        }


        public void ResetCell()
        {
            IsFilled = false;
            fillSprite.SetActive(false);
        }
    }
}