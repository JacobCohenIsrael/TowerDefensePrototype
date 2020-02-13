using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<TGridObject>
{
    public TGridObject[,] GridArray { get; }
    private int width;
    private int height;

    public Action<int , int, TGridObject> OnValueChanged;

    public Grid(int width, int height, Func<TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;

        GridArray = new TGridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GridArray[x, y] = createGridObject();
            }
        }
    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if (IsValid(x, y))
        {
            GridArray[x, y] = value;
            OnValueChanged.Invoke(x, y, value);
        }
    }

    public TGridObject GetValue(int x, int y)
    {
        if (IsValid(x, y))
        {
            return GridArray[x, y];
        }
        throw new IndexOutOfRangeException("Invalid Grid Range");
    }

    private bool IsValid(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}