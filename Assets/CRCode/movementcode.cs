using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementcode : MonoBehaviour
{
    public GameObject bwheel, fwheel, fwheel2, bwheel2;
    public float Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement(){
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver)*Speed*Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        bwheel.transform.Rotate(Vector3.down*ver);
        bwheel2.transform.Rotate(Vector3.down*ver);
        fwheel.transform.Rotate(Vector3.down*ver);
        fwheel2.transform.Rotate(Vector3.down*ver);
        }
}
