using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigDipperLevel : MonoBehaviour
{
    private void OnMouseUp(){
        SceneManager.LoadScene("SampleScene");
    }
}
