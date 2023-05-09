using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        mouseOn();
    }
    public void mouseOn(){
         Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    public void mouseOff(){
         Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
