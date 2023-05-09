using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLife : MonoBehaviour
{
    private Player data;
    private Rigidbody rb;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
       data = GameObject.Find("Player").GetComponent<Player>();
       rb= gameObject.GetComponent<Rigidbody>();
       timer = 200;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        destroy();
    }
    private void movement(){
        rb.velocity = new Vector3(0,1,0);
        rb.AddTorque (Vector3.forward);
    }
    private void destroy(){
        if (timer<=0){
            data.addstar();
            data.changestarcount();
            Destroy(gameObject);
            
        }else{
            timer--;
            
        }
    }

}