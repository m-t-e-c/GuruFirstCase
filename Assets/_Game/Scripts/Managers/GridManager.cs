using System;
using UnityEngine;
using System.Collections.Generic;
using GuruFirstCase.Interfaces;
using Object = UnityEngine.Object;

namespace GuruFirstCase
{
    public class GridManager : IGridManager
    {
        private GridCell[,] _gridCells;
        private int _gridSize;
        private float _cellSize;

        public void CreateGrid(GameObject cellPrefab, int gridSize, float cellSize)
        {
            ResetGrid();

            _gridSize = gridSize;
            _cellSize = cellSize;

            _gridCells = new GridCell[_gridSize, _gridSize];
            GameObject gridParent = new GameObject("Grid" + _gridSize + "x" + _gridSize);
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Vector3 cellPosition = new Vector3(x * _cellSize, y * _cellSize, 0);
                    GameObject cellObj = Object.Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                    GridCell cell = cellObj.GetComponent<GridCell>();
                    cell.Init(x, y, CheckFilledCellChain);
                    cell.transform.SetParent(gridParent.transform);
                    _gridCells[x, y] = cell;
                }
            }

            FitAndCenterCamera(_gridSize, _cellSize);
        }

        private void FitAndCenterCamera(int gridSize, float cellSize)
        {
            var camera = Camera.main;
            float cameraPos = (gridSize * cellSize - 1) / 2;
            camera.transform.position = new Vector3(cameraPos, cameraPos, -10);
            camera.orthographicSize = gridSize * cellSize + 0.5f;
        }

        public void ResetGrid()
        {
            if (_gridCells != null)
            {
                foreach (GridCell cell in _gridCells)
                {
                    if (cell != null)
                    {
                        Object.Destroy(cell.gameObject);
                    }
                }
            }

            _gridSize = 0;
            _cellSize = 0.0f;
            _gridCells = null;
        }

        private void CheckFilledCellChain(GridCell gridCell)
        {
            List<GridCell> chainedCells = new List<GridCell>();

            FindConnectedCells(gridCell, chainedCells);

            if (chainedCells.Count >= 3)
            {
                foreach (GridCell cell in chainedCells)
                {
                    cell.ResetCell();
                }

                chainedCells.Clear();
            }
        }

        private void FindConnectedCells(GridCell currentCell, List<GridCell> connectedCells)
        {
            if (connectedCells.Contains(currentCell) || !currentCell.IsFilled)
            {
                return;
            }

            connectedCells.Add(currentCell);

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x != 0 && y != 0)
                        continue;

                    int newX = currentCell.X + x;
                    int newY = currentCell.Y + y;

                    if (newX >= 0 && newX < _gridSize && newY >= 0 && newY < _gridSize)
                    {
                        GridCell neighborCell = _gridCells[newX, newY];
                        if (neighborCell.IsFilled)
                        {
                            FindConnectedCells(neighborCell, connectedCells);
                        }
                    }
                }
            }
        }
    }
}
