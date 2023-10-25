using System.Collections.Generic;
using GuruFirstCase.Interfaces;
using UnityEngine;

namespace GuruFirstCase
{
    public class GridManager : IGridManager
    {
        List<GameObject> gridCells = new();

        public void CreateGrid(GameObject cellPrefab, int gridSize, float cellSize)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Vector3 cellPosition = new Vector3(i * cellSize, 0, j * cellSize);
                    GameObject cell = Object.Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                    gridCells.Add(cell);
                }
            }
            
            Camera.main.transform.position = new Vector3(gridSize * cellSize * 0.5f, gridSize * cellSize * 0.5f, -10);
            Camera.main.orthographicSize = gridSize * cellSize * 0.6f;
        }

        public void ResetGrid()
        {
        }
    }
}