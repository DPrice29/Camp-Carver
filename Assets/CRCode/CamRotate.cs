using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CamRotate : MonoBehaviour
{
    public TextMeshProUGUI title ,Info;
    public Transform Target;
    public GameObject Sun0, Mercury1, Venus2, Earth3, Mars4, Jupiter5, Saturn6, Uranus7, Neptune8;
    public int planetNum;
    // Start is called before the first frame update
    void Start()
    {
        planetNum = 0;
        movePostion();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
     public void nextPlanet(){
        if(planetNum<8){
            planetNum++;
            movePostion();
        }else{
            planetNum = 0;
            movePostion();
        }
    }

    public void prevPlanet(){
        if (planetNum>0){
            planetNum--;
            movePostion();
        }else{
           planetNum = 8;
            movePostion();
    }}

    public void movePostion(){
        if (planetNum == 0){
            Target =Sun0.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-546);
             transform.rotation = Quaternion.identity;
             title.text = "Sun";
             Info.text ="-the sun contains 99.86% of the mass of the entire solar system and could contain roughly 1.3 million Earths. \n -The Sun is an average-sized star. Some stars are just a tenth of its size, while others are more than 700 times bigger.\n -Due to its huge mass and strong gravity, the Sun is a near perfect sphere.";

        }else if (planetNum == 1){
            Target =Mercury1.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-18);
             transform.rotation = Quaternion.identity;
             title.text = "Mercury";
             Info.text ="-Mercury spins slowly compared to Earth, so one day lasts a long time. \n -Mercury takes 59 Earth days to make one full rotation. But a year on Mercury goes fast. \n -Because it's the closest planet to the sun, it goes around the Sun in just 88 Earth days.";
             //Info.text ="";

        }else if (planetNum == 2){
            Target =Venus2.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-46);
             transform.rotation = Quaternion.identity;
             title.text = "Venus";
             Info.text ="-In addition to being extremely hot \n -Venus is unusual because it spins in the opposite direction of Earth and most other planets. \n -It also has a very slow rotation making its day longer than its year";

        }else if (planetNum == 3){
            Target =Earth3.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-46);
             transform.rotation = Quaternion.identity;
             title.text = "Earth";
             Info.text ="-Earth has never been perfectly round. \n -The planet bulges around the equator by an extra 0.3 percent as a result of the fact that it rotates about its axis. \n -Earth's diameter from North to South Pole is 12,714 kilometers (7,900 miles), while through the equator it is 12,756 kilometers (7,926 miles).";

        }else if (planetNum == 4){
            Target =Mars4.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-25);
             transform.rotation = Quaternion.identity;
             title.text = "Mars";
             Info.text ="-Mars is also known as the Red Planet. \n -Mars is named after the Roman god of war. \n -Mars has 2 moons called Deimos and Phobos. \n -Mars is the 4th planet from the sun. \n -Mars is smaller than Earth with a diameter of 4217 miles.";

        }else if (planetNum == 5){
            Target =Jupiter5.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-420);
             transform.rotation = Quaternion.identity;
             title.text = "Jupiter";
             Info.text ="-Jupiter is the biggest planet in our solar system. \n -It's similar to a star, but it never got big enough to start burning. \n -Jupiter is covered in swirling cloud stripes. \n -It has big storms like the Great Red Spot, which has been going for hundreds of years.";

        }else if (planetNum == 6){
            Target =Saturn6.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-420);
             transform.rotation = Quaternion.identity;
             title.text = "Saturn";
             Info.text ="-Saturn is huge. \n -You cannot stand on Saturn. \n- Its beautiful rings are not solid. \n -Some of these bits are as small as grains of sand. \n -The rings are huge but thin. \n -Other planets have rings. \n -Saturn could float in water because it is mostly made of gas.";

        }else if (planetNum == 7){
            Target =Uranus7.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-200);
             transform.rotation = Quaternion.identity;
             title.text = "Uranus";
             Info.text ="Uranus is the coldest planet in the Solar System: \n -Uranus orbits the Sun on its side \n -A Season on Uranus lasts one long day – 42 years \n -Uranus is the second-least dense planet \n -Uranus has rings \n -The atmosphere of Uranus contains “ices” \n -Uranus has 27 moons:";

        }else if (planetNum == 8){
            Target =Neptune8.transform;
             transform.position = new Vector3 (Target.position.x,Target.position.y,Target.position.z-200);
             transform.rotation = Quaternion.identity;
             title.text = "Neptune";
             Info.text ="-More than 30 times as far from the Sun as Earth \n -Neptune is the only planet in our solar system not visible to the naked eye \n -the first predicted by mathematics before its discovery.  \n -In 2011 Neptune completed its first 165-year orbit since its discovery in 1846.";

        }
       
    }
    public void sceneChange(){
        SceneManager.LoadScene("MainScene");

    }
    public void openLink(){
        if (planetNum == 0){
            Application.OpenURL("https://solarsystem.nasa.gov/solar-system/sun/overview/");
            
             title.text = "Sun";

        }else if (planetNum == 1){

            Application.OpenURL("https://solarsystem.nasa.gov/planets/mercury/overview/#:~:text=Mercury%20is%20the%20fastest%20planet,Sun%2C%20the%20faster%20it%20travels.");
             title.text = "Mercury";

        }else if (planetNum == 2){
            Application.OpenURL("https://solarsystem.nasa.gov/planets/venus/overview/#:~:text=Venus%20has%20a%20thick%2C%20toxic,is%20closer%20to%20the%20Sun.");
             title.text = "Venus";

        }else if (planetNum == 3){
            Application.OpenURL("https://climate.nasa.gov/news/2469/10-interesting-things-about-earth/");
             title.text = "Earth";

        }else if (planetNum == 4){
           Application.OpenURL("https://solarsystem.nasa.gov/planets/mars/overview/#:~:text=%E2%80%8BMars%20is%20the%20fourth,more%20active%20in%20the%20past.");
             title.text = "Mars";

        }else if (planetNum == 5){
            Application.OpenURL("https://solarsystem.nasa.gov/planets/jupiter/overview/");
             title.text = "Jupiter";

        }else if (planetNum == 6){
           Application.OpenURL("https://www.nasa.gov/audience/forstudents/k-4/home/F_Saturn_Fun_Facts_K-4.html");
             title.text = "Saturn";

        }else if (planetNum == 7){
           Application.OpenURL("https://solarsystem.nasa.gov/planets/uranus/overview/#:~:text=Uranus%20is%20the%20seventh%20planet,a%20comet%20or%20a%20star.");
             title.text = "Uranus";

        }else if (planetNum == 8){
            Application.OpenURL("https://solarsystem.nasa.gov/planets/neptune/overview/");
             title.text = "Neptune";

        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Target.position, Vector3.up, 10*Time.deltaTime);
        
    }
}
