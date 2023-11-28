using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager ins;

    private void Awake()
    {
        if (ins == null)
            ins = this;
    }
    public Vector3 getMousePos()
    {
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        mousePositionWorld.z = 0;
        return mousePositionWorld;
    }
}
