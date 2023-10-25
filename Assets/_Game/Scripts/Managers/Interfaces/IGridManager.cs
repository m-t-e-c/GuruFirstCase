using UnityEngine;

namespace GuruFirstCase.Interfaces
{
    public interface IGridManager
    {
        public void CreateGrid(GameObject cellPrefab, int gridSize, float cellSize = 1.0f);
        public void ResetGrid();
    }
}