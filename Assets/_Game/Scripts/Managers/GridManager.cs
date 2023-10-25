using System.Collections.Generic;
using GuruFirstCase.Interfaces;
using UnityEngine;

namespace GuruFirstCase
{
    public class GridManager : IGridManager
    {
        readonly List<GameObject> gridCells = new();

        public void CreateGrid(GameObject cellPrefab, int gridSize, float cellSize)
        {
            ResetGrid();

            GameObject gridParent = new GameObject($"Grid{gridSize}x{gridSize}");
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Vector3 cellPosition = new Vector3(i * cellSize, j * cellSize, 0);
                    GameObject cell = Object.Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                    cell.transform.SetParent(gridParent.transform);
                    gridCells.Add(cell);
                }
            }

            FitAndCenterCamera(gridSize,cellSize);
        }

        void FitAndCenterCamera(int gridSize, float cellSize)
        {
            var camera = Camera.main;
            float cameraPos = (gridSize * cellSize - 1) / 2;
            camera.transform.position = new Vector3(cameraPos, cameraPos, -10);
            camera.orthographicSize = gridSize * cellSize + 0.5f;
        }

        public void ResetGrid()
        {
            foreach (GameObject cell in gridCells)
            {
                Object.Destroy(cell);
            }
            gridCells.Clear();
        }
    }
}