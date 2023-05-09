using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public Transform obstuction;
    float zoomspeed = 2f;
    void Start(){
       obstuction = Target;
    }
    void LateUpdate(){
        CamControl();
        //viewBlocked();
    }

void CamControl(){
        mouseX += Input.GetAxis("Mouse X")* rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -10, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY,mouseX,0);
        Player.rotation = Quaternion.Euler(0,mouseX,0);
    }

    // Update is called once per frame
    void viewBlocked(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f)){
            if (hit.collider.gameObject.tag != "Player"){
                obstuction = hit.transform;
                obstuction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                if(Vector3.Distance(obstuction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f){
                    transform.Translate(Vector3.forward* zoomspeed*Time.deltaTime);
                }
            }else{
                obstuction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, Target.position) < 4.5f){
                    transform.Translate(Vector3.back * zoomspeed *Time.deltaTime);
                }

            }
        }

    }
}
