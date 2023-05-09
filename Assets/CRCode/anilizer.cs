using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class anilizer : MonoBehaviour
{
    private Player data;
    public bool water, moonRock, snow, Diamonds;
    public GameObject waterobj, moonrockobj,snowobj, diamondobj;
    public TextMeshProUGUI sender, origin, funFact;
    public int number;
    public TextMeshProUGUI objectname;

    public void itemchange(){
        if (number==0){
            data = GameObject.Find("Player").GetComponent<Player>();
            waterobj.SetActive(true);
            moonrockobj.SetActive(false);
            snowobj.SetActive(false);
            diamondobj.SetActive(false);
            if (data.water == true){
                objectname.text = "Water";
                sender.text = "Millie";
                origin.text = "Mississippi River, U.S., Earth";
                funFact.text = "326 species of birds use the Mississippi River Basin as their migratory flyway.";
                
            }else{
                objectname.text = "Object 1 Not Found";
                waterobj.SetActive(false);
                 sender.text = "???";
                origin.text = "???";
                funFact.text = "???";
            }
        } else if (number==1){
            data = GameObject.Find("Player").GetComponent<Player>();
            waterobj.SetActive(false);
            moonrockobj.SetActive(true);
            snowobj.SetActive(false);
            diamondobj.SetActive(false);
            if (data.moonRock == true){
                objectname.text = "Moon Rock";
                sender.text = "Rel";
                origin.text = "Rhea Moon, Saturn";
                funFact.text = "Rhea is the second largest of Saturn’s 83 moons.";
            }else{
                objectname.text = "Object 2 Not Found";
                moonrockobj.SetActive(false);
                 sender.text = "???";
                origin.text = "???";
                funFact.text = "???";
            }
        }else if (number==2){
            data = GameObject.Find("Player").GetComponent<Player>();
            waterobj.SetActive(false);
            moonrockobj.SetActive(false);
            snowobj.SetActive(true);
            diamondobj.SetActive(false);
            if (data.snow == true){
                objectname.text = "Snow";
                sender.text = "Henrique";
                origin.text = "The Great Dark Spot, Neptune";
                funFact.text = "The atmosphere on Venus contains vaporized metals like basalt that freeze to form so called snow.";
            }else{
                objectname.text = "Object 3 Not Found";
                snowobj.SetActive(false);
                 sender.text = "???";
                origin.text = "???";
                funFact.text = "???";
            }
        }else if (number==3){
            data = GameObject.Find("Player").GetComponent<Player>();
            waterobj.SetActive(false);
            moonrockobj.SetActive(false);
            snowobj.SetActive(false);
            diamondobj.SetActive(true);
            if (data.Diamonds == true){
                objectname.text = "Diamond";
                sender.text = "Julia";
                origin.text = "Galle Ring, Neptune";
                funFact.text = "10 million tons of diamonds rain down on Neptune each year.";
            }else{
                objectname.text = "Object 4 Not Found";
                diamondobj.SetActive(false);
                objectname.text = "???";
                sender.text = "???";
                origin.text = "???";
                funFact.text = "???";
            }
        }

    }
    public void nextItem(){
        if (number >= 3){
            number = 0;
        }else{
            number++;
        }
        itemchange();

    }
    public void previousItem(){
        if (number <= 0){
            number = 3;
        }else{
            number--;
        }
        itemchange();

    }

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Player").GetComponent<Player>();
        itemchange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
