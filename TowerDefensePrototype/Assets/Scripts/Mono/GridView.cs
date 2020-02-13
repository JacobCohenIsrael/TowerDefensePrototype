using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridView : MonoBehaviour
{
    [SerializeField] private float gridCellSize = 10f;
    [SerializeField] private int gridWidth= 1;
    [SerializeField] private int gridHeight = 1;

    private Grid<int> grid;
    private TextMesh[,] textArray;
    private Vector3 originPosition;

    private void Start()
    {
        grid = new Grid<int>(gridWidth, gridHeight, () => { return 0; });
        textArray = new TextMesh[gridWidth, gridHeight];
        grid.OnValueChanged += OnGridValueChanged;
        originPosition = transform.position;

        for (int x = 0; x < grid.GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GridArray.GetLength(1); y++)
            {
                //textArray[x, y] = createWorldText(transform.parent, grid.GridArray[x, y].ToString(), GetWorldPosition(x, y) + new Vector3(gridCellSize, gridCellSize) * 0.5f, 30, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 1);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, grid.GridArray.GetLength(1)), GetWorldPosition(grid.GridArray.GetLength(0), grid.GridArray.GetLength(1)), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(grid.GridArray.GetLength(0), 0), GetWorldPosition(grid.GridArray.GetLength(0), grid.GridArray.GetLength(1)), Color.white, 100f);
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        Vector2Int gridPosition = GetGridPosition(worldPosition);
        grid.SetValue(gridPosition.x, gridPosition.y, value);
    }

    public int GetValue(Vector3 worldPosition)
    {
        Vector2Int gridPosition = GetGridPosition(worldPosition);
        return grid.GetValue(gridPosition.x, gridPosition.y);
    }

    private void OnGridValueChanged(int x, int y, int value)
    {
        textArray[x, y].text = value.ToString();
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * gridCellSize + originPosition;
    }

    private TextMesh createWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("WorldText", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    private Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt((worldPosition - originPosition).x / gridCellSize), Mathf.FloorToInt((worldPosition - originPosition).y / gridCellSize));
    }
}
