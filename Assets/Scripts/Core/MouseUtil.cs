using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUtil
{ 
    public static Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}