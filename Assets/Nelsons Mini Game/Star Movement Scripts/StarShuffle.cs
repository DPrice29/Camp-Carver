using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarShuffle : MonoBehaviour
{
    public Transform[] StarsToShuffle; // Array for the stars to shuffle
    public float XMax;//max for X is 20
    public float XMin;//min for X is -20
    public float YMax;//max for Y is 9
    public float YMin;//min for Y is -8

    void Start(){
        ShuffleStars();
        StarSlots = new List<Collider2D>();
        StarSlots.Add(GameObject.Find("Location Trigger 1").GetComponent<Collider2D>());
        StarSlots.Add(GameObject.Find("Location Trigger 2").GetComponent<Collider2D>());
        StarSlots.Add(GameObject.Find("Location Trigger 3").GetComponent<Collider2D>());
        StarSlots.Add(GameObject.Find("Location Trigger 4").GetComponent<Collider2D>());
        StarSlots.Add(GameObject.Find("Location Trigger 5").GetComponent<Collider2D>());
        StarSlots.Add(GameObject.Find("Location Trigger 6").GetComponent<Collider2D>());
        StarSlots.Add(GameObject.Find("Location Trigger 7").GetComponent<Collider2D>());
        rb = GetComponent<Rigidbody2D>();
    }
    
    void ShuffleStars(){
        for (int i = 0; i < StarsToShuffle.Length; i++){
            int randomLoc = Random.Range(i, StarsToShuffle.Length); // Get a random Location within the remaining array
            Transform temp = StarsToShuffle[i];
            StarsToShuffle[i] = StarsToShuffle[randomLoc];
            StarsToShuffle[randomLoc] = temp;
        }
        
        for (int i = 0; i < StarsToShuffle.Length; i++){
            float randomX = Random.Range(XMin, XMax); // Get a random x Location within a set area
            float randomY = Random.Range(YMin, YMax); // Get a random y Location within a set area
            StarsToShuffle[i].position = new Vector2(randomX, randomY); // Set the object's position to the random location
        }
    }
    // Code for Moving objects
    private Vector3 offset; //The mouse's postion when you click
    private bool Dragging;
    private List<Collider2D> StarSlots;
    private Rigidbody2D rb;
    private int SlotsFilled;

    private void OnMouseDown(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;
        Dragging = true;
    }

    private void OnMouseDrag(){
        if (Dragging){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
            rb.MovePosition(new Vector2(mousePosition.x, mousePosition.y));
        }
    }

    public static int AfterSlotFilled = 0;
    
    private void OnMouseUp(){
        Dragging = false;
        int B4SlotsFilled = SlotsFilled;
        
        foreach(Collider2D StarSlot in StarSlots){
            //StarSlot refers to a single "Location Trigger" object inside of the StarSlots List
            if(StarSlot.OverlapPoint(transform.position)){
                AfterSlotFilled++;
                break;
            }
        }

        if(AfterSlotFilled == 7){
            SceneManager.LoadScene("LevelComplete");
            AfterSlotFilled = 0;
        }

        if(AfterSlotFilled > B4SlotsFilled){
            //Add a sound effect if time permits
        }

        foreach(Collider2D StarSlot in StarSlots){
            if(StarSlot.OverlapPoint(transform.position)){
                Vector3 SlotCenter = StarSlot.bounds.center;
                transform.position = new Vector3(SlotCenter.x, SlotCenter.y, transform.position.z);//This will center the stars into place
                Debug.Log("Object dropped into slot" + AfterSlotFilled);
                break;
            }
        }
    }
}
