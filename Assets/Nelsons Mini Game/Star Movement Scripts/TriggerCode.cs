using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCode : MonoBehaviour
{
    [SerializeField] private Rigidbody2D star;
    [SerializeField] private Vector3 location;// Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision){
        star = collision.GetComponent<Rigidbody2D>();
        if(star != null){
            star.MovePosition(location);
        }
    }
}
