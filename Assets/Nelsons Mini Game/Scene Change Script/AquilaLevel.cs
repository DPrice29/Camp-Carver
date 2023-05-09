using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AquilaLevel : MonoBehaviour
{
    private void OnMouseUp(){
        SceneManager.LoadScene("Aquila");
    }
}
