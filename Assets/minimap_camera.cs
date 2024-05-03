using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class minimap_camera : MonoBehaviour
{
    public Transform Player;
    public Camera MainCamera;
    public bool RotateWithPlayer = true;
    // Start is called before the first frame update
    void Start()
    {
        SetPosition();
        SetRotation();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Player != null)
        {
            SetPosition();
            if(RotateWithPlayer && MainCamera)
            {
                SetRotation();
            }
        }
    }
    private void SetRotation()
    {
        transform.rotation = Quaternion.Euler(90.0f, MainCamera.transform.eulerAngles.y, 0.0f);
    }
    private void SetPosition()
    {
        var newPos = MainCamera.transform;
        var newP = newPos.position;
        newP.y = transform.position.y;
        transform.position = newP;
    }

}
