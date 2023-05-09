using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//move later
using TMPro;


public class Player : MonoBehaviour, MyDataParse
{

    // Start is called before the first frame update
        public float Speed;
        public TextMeshProUGUI starcount, Tabtext, npcMessage, mapTitle, mapInfo;
        private int stars = 0;
        public GameObject   telescopecam, mainCam, eyepoint, AnilizerCam, AnilizerScreen, NotPadCam, notePadScreen, notestext;
        public GameObject telescreen, dialogBox;
        public bool telescreencheck, Diamondcheck, firstnote;
        public GameObject star, Diamond, snowobj, moonRockobj, waterobj;
        public bool moonRock, Diamonds, snow, water, Anilizer, cabin, goOutside;
        private bool GavityGame, constilationGame, notebook, SpaceVideo;

        public GameObject vid1, vid2, vid3, vidcam;
        public int vidnum = 1;
        private bool vidstar;
        public TMP_InputField noteinput;
        private bool allowedtomove;
        private string[] notes = new string[100];
        private int notenum = 0, itemNum;
        public GameObject videoui;
    

        private void vidchange(){
            if (vidnum == 1){
                vid1.SetActive(true);
                vid2.SetActive(false);
                vid3.SetActive(false);

                mapTitle.text = "Fire";
                mapInfo.text = "This lovely map shows fires burning on Earth. They might be naturally occurring or caused by some human intervention. Why might it be important for us to study fires?";

            }else if (vidnum == 2){
                vid1.SetActive(false);
                vid2.SetActive(true);
                vid3.SetActive(false);

                mapTitle.text = "Water Vapor";
                mapInfo.text = "These maps were created with the MODIS sensor on NASA’s Aqua Satellite. They tell us about our most important greenhouse gas, water vapor. These maps help us predict when it will rain or snow. Do you see any patterns during different seasons? What about in different locations?";

            }else if (vidnum == 3){
                vid1.SetActive(false);
                vid2.SetActive(false);
                vid3.SetActive(true);

                mapTitle.text = "Net Radiation";
                mapInfo.text = "What do you think of when you hear “radiation”? These maps are showing balance between incoming and outgoing energy. It is the total energy available to influence climate after light and heat are reflected, absorbed, or emitted by clouds and land.";

            }
        }
        public void nextvid(){
            vidnum++;
            if (vidnum>3){
                vidnum =1;
            }
            if (vidnum==3 && vidstar==false){
                addstar();
                vidstar = true;
            }
            vidchange();

        }
        public void prevvid(){
            vidnum--;
            if(vidnum < 1){
                vidnum = 3;
            }

            if (vidnum==3 && vidstar==false){
                addstar();
                vidstar = true;
            }
            vidchange();

        }
        
        public void exitvidscreen(){
            vidcam.SetActive(false);

        }
        private void clearobjects(){
            if(moonRock == true){
                Destroy(moonRockobj);
            }
            if(Diamonds == true){
                Destroy(Diamond);
            }if(snow == true){
                Destroy(snowobj);
            }
            if(water == true){
                Destroy(waterobj);
            }
        }

        private void collectDiamond(){
            Diamonds = true;
           if (snow == true&& water == true && Diamonds == true && moonRock == true){
                spawnstar();

            }
            
             Destroy(Diamond);
             itemNum = 0;
          Diamondcheck = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;
        }
        private void spawnstar(){
            GameObject stars;
            GameObject objects = snowobj;

            Vector3 location;
            location = new Vector3(objects.transform.position.x,objects.transform.position.y,objects.transform.position.z);
            stars = Instantiate(star,location,objects.transform.rotation);

        }
        private void collectsnow(){

            snow = true;
           
            if (snow == true&& water == true && Diamonds == true && moonRock == true){
                spawnstar();

            }
             Destroy(snowobj);
             itemNum = 0;
          Diamondcheck = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;
        }
        private void collectwater(){
            water = true;
            if (snow == true&& water == true && Diamonds == true && moonRock == true){
                spawnstar();

            }
             Destroy(waterobj);
             itemNum = 0;
          Diamondcheck = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;
        }
        private void collectmoonrock(){
            moonRock = true;
            if (snow == true&& water == true && Diamonds == true && moonRock == true){
                spawnstar();

            }
             Destroy(moonRockobj);
             itemNum = 0;
          Diamondcheck = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;
        }



        


        public void LoadData(GameData data){
            this.stars = data.stars;
            this.moonRock = data.moonRock;
            this.Diamonds = data.Diamonds;
            this.snow = data.snow;
            this.water = data.water;
            this.notes = data.notes;
            this.firstnote = data.firstnote;

        }
        public void SaveData(ref GameData data){
            data.stars = this.stars;
            data.moonRock = this.moonRock;
            data.Diamonds = this.Diamonds;
            data.snow = this.snow;
            data.water = this.water;
            data.notes = this.notes;
            data.firstnote = this.firstnote;
            

        }

    // Start is called before the first frame update
    void Start()
    {
        allowedtomove = true;
        starcount.text =""+ stars;
        startentrys();
        clearobjects();

        // test
    }
    public void changestarcount(){
        starcount.text =""+ stars;
    }
    public void addstar (){
        stars++;
        starcount.text =""+ stars;
    }
    private void startentrys(){
        if (firstnote == false){
        notes[0] = "Corey Alms 01/6/2023 Why do some planets shine bright like stars";
        notes[1] = "Tyrone Moore 1/3/2017  Today I saw a meteor! I almost missed it but I was patient. I wonder how many other people on Earth saw it.";
        notes[2] = "Tai H. 3/1/2023 We saw the Venus-Jupiter Conjuction tonight. What would the sky look like if we had 80 moons like Jupiter?";
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(telescreencheck == true){
                //telescopecam.SetActive(true);
           //mainCam.SetActive(false);
           Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
           
           SceneManager.LoadScene("solarmap");
           
           
            }if (Diamondcheck == true){
                collectDiamond();

            } else if (Anilizer == true){
               EnterAnilizer();

            } else if (SpaceVideo == true){
               Entervideo();

            } else if (notebook == true){
               EnterNotepade();

            } else if (GavityGame == true){
               SceneManager.LoadScene("Gravity");
    }
 else if (constilationGame == true){
                Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
               SceneManager.LoadScene("Menu");

            } else if (itemNum == 2){
                snow = true;
                collectsnow();
              

            } else if (itemNum == 3){
                moonRock = true;
                collectmoonrock();
              

            } else if (itemNum == 4){
              water = true;
              collectwater();

            } else if (goOutside == true){
                Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
               SceneManager.LoadScene("Outdoors");

            }else if (cabin == true){
                Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
               SceneManager.LoadScene("MainScene");

            }
        }
    }
    public void notepadtext(){

        notestext.GetComponent<TextMeshPro>().text = noteinput.text;


    }
    public void prevnote(){
        if (notenum>0){
            notenum--;
            viewnotes();

        }
    }
    public void nextnote(){
         notenum++;
         if (notes[notenum] == "" || notes[notenum] == null){
            notenum = 0;
            viewnotes();
         }else{
            viewnotes();
         }
    }


    public void viewnotes(){
        if (notes[notenum] == "" || notes[notenum] == null){
            notestext.GetComponent<TextMeshPro>().text = notes[0];
            notenum = 0;


        }else{
            notestext.GetComponent<TextMeshPro>().text = notes[notenum];
        }
        

    }
    public void AddNotrpadText(){
        if (notes[notenum] == "" || notes[notenum] == null){
            notes[notenum] = noteinput.text;
        }else{
            notenum++;
            AddNotrpadText();
        }
        if (firstnote == false){
            firstnote = true;
            addstar();

        }

    }
    public void removenotpadetext(){
        for (int i = notenum; i < notes.Length -1; i++){
            notes[i] = notes[i+1];
        }
        notes[notes.Length - 1] = "";
        notestext.GetComponent<TextMeshPro>().text = notes[notenum];
        

    }
    public void EnterNotepade(){
         telescreen.SetActive(false);
           telescreencheck = false;
           mainCam.SetActive(false);
           Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        NotPadCam.SetActive(true);
        notePadScreen.SetActive(true);
        allowedtomove = false;
        transform.position = new Vector3(-7f,.305f,20.5f);

        


    }
    public void ExitNotePad(){
        telescreen.SetActive(true);
           telescreencheck = false;
           mainCam.SetActive(true);
           Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        NotPadCam.SetActive(false);
        notePadScreen.SetActive(false);
        allowedtomove = true;


    }
    public void EnterAnilizer(){
        telescreen.SetActive(false);
           telescreencheck = false;
           mainCam.SetActive(false);
           AnilizerCam.SetActive(true);
           AnilizerScreen.SetActive(true);
           Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        allowedtomove = false;
        transform.position = new Vector3(-6.42f,.32f,11.61f);

           

    }
    public void Entervideo(){
        telescreen.SetActive(false);
           telescreencheck = false;
           mainCam.SetActive(false);
           AnilizerCam.SetActive(true);
           vidcam.SetActive(true);
           videoui.SetActive(true);
           Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        allowedtomove = false;
        transform.position = new Vector3(-6.42f,.32f,11.61f);

           

    } public void Exitvideoscreen(){
        telescreen.SetActive(true);
           telescreencheck = false;
           mainCam.SetActive(true);
           AnilizerCam.SetActive(false);
           AnilizerScreen.SetActive(false);
             Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        allowedtomove = true;
    }


    public void ExitAnilizer(){
        telescreen.SetActive(true);
           telescreencheck = false;
           mainCam.SetActive(true);
           AnilizerCam.SetActive(false);
           AnilizerScreen.SetActive(false);
             Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        allowedtomove = true;
    }
    void PlayerMovement(){
        if (allowedtomove == true)
            {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver)*Speed*Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
            }
        }
        
        private void OnTriggerEnter(Collider other){
       if(other.gameObject.CompareTag("Telescope")){
           telescreen.SetActive(true);
           telescreencheck = true;
           Tabtext.text = "Press Tab to access Telescope";
            npcMessage.text = "There's so much to learn about our Solar System! Take a look through our telescope to see what you can discover.";


        }else if(other.gameObject.CompareTag("speaker")){
            dialogBox.SetActive(true);
            telescreencheck = false;
        
        }else if(other.gameObject.CompareTag("Diamond")){
           Debug.Log("Diamond");
          Diamondcheck = true;
          itemNum = 1;
           
           
           telescreen.SetActive(true);
           telescreencheck = false;
           Tabtext.text = "Press Tab to Collect Diamond";

        }else if(other.gameObject.CompareTag("Snow")){
           
          Diamondcheck = false;
           
           itemNum = 2;
           telescreen.SetActive(true);
           telescreencheck = false;
           Tabtext.text = "Press Tab to Collect Snow";


        }else if(other.gameObject.CompareTag("Moon Rock")){
            itemNum = 3;
           
          Diamondcheck = false;
           
           
           telescreen.SetActive(true);
           telescreencheck = false;
           Tabtext.text = "Press Tab to Collect Moon Rock";
           

        }else if(other.gameObject.CompareTag("Water")){
            itemNum = 4;
           
          Diamondcheck = false;
           
           
           telescreen.SetActive(true);
           telescreencheck = false;
           Tabtext.text = "Press Tab to Collect water";
           

        }else if(other.gameObject.CompareTag("Anilizer")){
           
          
           
           
           telescreen.SetActive(true);
           telescreencheck = false;
           Tabtext.text = "Press Tab to access analyzer";
           Anilizer = true;
           npcMessage.text = "Our campers in the biochemical cabins have a tradition of sending us pieces of their planet when they return home.  You can find those samples scattered around the camp. Use this M.A.D tool to learn more about them.";


        }else if(other.gameObject.CompareTag("NoteBook")){
            Tabtext.text = "Press Tab to view and edit notebook";
            telescreen.SetActive(true);
           telescreencheck = false;
           notebook = true;
           npcMessage.text = "The best way to learn about your curiosity is to ask questions! Take a look at some of the questions our campers have left behind. I think you might have some of the answers.";
           
        

        }else if(other.gameObject.CompareTag("GavityGame")){
            Tabtext.text = "Press Tab to play gravity game";
            telescreen.SetActive(true);
           telescreencheck = false;
           GavityGame= true;
           npcMessage.text = "You found our gravity simulator! Take a step inside this chamber to see if you have what it takes to maneveur around different planets. It's not as easy as it looks!";
           
        

        }else if(other.gameObject.CompareTag("consellationGame")){
            Tabtext.text = "Press Tab to play constellation game";
            telescreen.SetActive(true);
           telescreencheck = false;
           constilationGame = true;
           npcMessage.text = "Great Monocerus! The constellations got mixed around! I need you to help me sort this out.";
           
        

        }else if(other.gameObject.CompareTag("Cabin")){
            Tabtext.text = "Press Tab to go in cabin";
            telescreen.SetActive(true);
           telescreencheck = false;
           constilationGame = false;
           cabin = true;           
        

        }else if(other.gameObject.CompareTag("Door")){
            Tabtext.text = "Press Tab to go Outside";
            telescreen.SetActive(true);
            dialogBox.SetActive(false);
           telescreencheck = false;
           constilationGame = false;
           cabin = true;
           goOutside = true;           
        

        }else if(other.gameObject.CompareTag("SpaceVideo")){
            Tabtext.text = "Press Tab to view space videos";
            telescreen.SetActive(true);
           telescreencheck = false;
           SpaceVideo = true;
           npcMessage.text = "I love studying these maps. Aren’t they beautiful? They tell us so much about how the Earth is changing! Go ahead and check it out for yourself.";
          
           // change conditions after videos are implemented
        //    if( spaceVideo == "fire"){
        //     npcMessage.text = "This lovely map shows fires burning on Earth. They might be naturally occurring or caused by some human intervention. Why might it be important for us to study fires?";
        //    }else if( spaceVideo == "water vapor"){
        //     npcMessage.text = "These maps were created with the MODIS sensor on NASA’s Aqua Satellite. They tell us about our most important greenhouse gas, water vapor. These maps help us predict when it will rain or snow. Do you see any patterns during different seasons? What about in different locations?";
        //    }else if( spaceVideo == "net radiation"){
        //     npcMessage.text = "What do you think of when you hear “radiation”? These maps are showing balance between incoming and outgoing energy. It is the total energy available to influence climate after light and heat are reflected, absorbed, or emitted by clouds and land.";
        //    }
        

        }
        }
        
private void OnTriggerExit(Collider other){
       if(other.gameObject.CompareTag("Telescope")){
           Debug.Log("uncollided");
           
           telescreen.SetActive(false);
           telescreencheck = false;

        } else if(other.gameObject.CompareTag("speaker")){
            dialogBox.SetActive(false);
            telescreencheck = false;

        } else if(other.gameObject.CompareTag("Diamond")){
           
          Diamondcheck = false;
           itemNum = 0;
           
           telescreen.SetActive(false);
           telescreencheck = false;

        }else if(other.gameObject.CompareTag("Snow")){
           itemNum = 0;
          Diamondcheck = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;

        }else if(other.gameObject.CompareTag("Water")){
           itemNum = 0;
          Diamondcheck = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;

        }
        
        else if(other.gameObject.CompareTag("Moon Rock")){
           itemNum = 0;
          Diamondcheck = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;

        }else if(other.gameObject.CompareTag("Anilizer")){
           
          Diamondcheck = false;
          Anilizer = false;
           
           
           telescreen.SetActive(false);
           telescreencheck = false;

        }else if(other.gameObject.CompareTag("NoteBook")){
            Tabtext.text = "Press Tab to view and edit notebook";
            telescreen.SetActive(false);
           telescreencheck = false;

           Diamondcheck = false;
          Anilizer = false;
          notebook = false;
          GavityGame = false;
          constilationGame = false;
          SpaceVideo = false;

           
        

        }else if(other.gameObject.CompareTag("GavityGame")){
            Tabtext.text = "Press Tab to play gravity game";
            telescreen.SetActive(false);
           telescreencheck = false;
           Diamondcheck = false;
          Anilizer = false;
          notebook = false;
          GavityGame = false;
          constilationGame = false;
          SpaceVideo = false;


           
        

        }else if(other.gameObject.CompareTag("consellationGame")){
            Tabtext.text = "Press Tab to play constellation game";
            telescreen.SetActive(false);
           telescreencheck = false;

           Diamondcheck = false;
          Anilizer = false;
          notebook = false;
          GavityGame = false;
          constilationGame = false;
          SpaceVideo = false;


           
        

        }else if(other.gameObject.CompareTag("SpaceVideo")){
            Tabtext.text = "Press Tab to view videos";
            telescreen.SetActive(false);
           telescreencheck = false;

           Diamondcheck = false;
          Anilizer = false;
          notebook = false;
          GavityGame = false;
          constilationGame = false;
          SpaceVideo = false;


           
        

        }else if(other.gameObject.CompareTag("Cabin")){
            Tabtext.text = "Press Tab to view constellationideos";
            telescreen.SetActive(false);
           telescreencheck = false;

           Diamondcheck = false;
          Anilizer = false;
          notebook = false;
          GavityGame = false;
          constilationGame = false;
          SpaceVideo = false;
          cabin = false;


           
        

        }else if(other.gameObject.CompareTag("Door")){
            Tabtext.text = "Press Tab to view constellationideos";
            telescreen.SetActive(false);
           telescreencheck = false;

           Diamondcheck = false;
          Anilizer = false;
          notebook = false;
          GavityGame = false;
          constilationGame = false;
          SpaceVideo = false;
          cabin = false;
          goOutside = false;


           
        

        }
}
}

