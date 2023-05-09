using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLocation : MonoBehaviour
{
    // This code changes the color of the object after 
    //Currently not working, but this is more cosmetic then nessesary
    [SerializeField] private GameObject selectedStar; // The Star that triggers the location to change color
    [SerializeField] private Color NewColor; // color the object will change to
    private Material original; //original color of the object
    void Start()
    {
        original = GetComponent<Renderer>().material;
    }

    private void OnMouseDown(){
        if(selectedStar == gameObject){
            GetComponent<Renderer>().material.color = NewColor;
        }
    }

    private void OnMouseUp(){
        if(selectedStar == gameObject){
            GetComponent<Renderer>().material = original;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
