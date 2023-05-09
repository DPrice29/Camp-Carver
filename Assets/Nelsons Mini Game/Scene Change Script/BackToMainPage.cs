using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// programed By Chris Rhone
public class BackToMainPage : MonoBehaviour
{
    // Start is called before the first frame update
  private void OnMouseUp(){
        SceneManager.LoadScene("MainScene");
    }
}
