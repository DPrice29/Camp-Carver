using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solarsystem : MonoBehaviour
{
    //soloar sytem cam code
    //public GameObject SunCam, MercuryCam1, VenusCam2, EarthCam3, MarsCam4, JupiterCam5, SaturnCam6, UranusCam7, NeptuneCam8;
    public GameObject maincam;
    public int camNum;
    
    

    
   





    readonly float solarspeed = 10000f;
    GameObject[] Planets;
    // Start is called before the first frame update
    void Start()
    {
        camNum = 0;
        
        Planets = GameObject.FindGameObjectsWithTag("Planets");
        PlanetRotation();
        foreach(GameObject a in Planets){
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){
        Gravity();
        
    }
    void PlanetRotation(){
        foreach(GameObject a in Planets){
            foreach(GameObject b in Planets){
                if(!a.Equals(b)){
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((solarspeed*m2)/r);
                }

            }
            }

    }
    void Gravity(){
        foreach(GameObject a in Planets){
            foreach(GameObject b in Planets){
                if(!a.Equals(b)){
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized*(solarspeed*(m1*m2)/(r*r)));
                }
            }
        }
    }
    
}
