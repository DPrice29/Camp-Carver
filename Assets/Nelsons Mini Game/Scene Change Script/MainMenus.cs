using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
    private void OnMouseUp(){
        SceneManager.LoadScene("Menu");
    }
}
