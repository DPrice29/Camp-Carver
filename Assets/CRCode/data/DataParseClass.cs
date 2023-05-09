using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataParseClass : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField]private string fileName;
    private List<MyDataParse> DataParsesObjects;
    private GameData gameData;
    private List<MyDataParse> dataPersistanceObjects;
    private FileDataHandler dataHandler;
    public static DataParseClass instance {get; private set;}
    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.DataParsesObjects = FindallDataParseObjects();
        LoadGame();
    }
    private void awake(){
        if (instance != null){
            Debug.LogError("found more than one");
        }
        instance = this;
    }
    public void NewGame(){
        this.gameData = new GameData();

    }
    public void LoadGame(){
        this.gameData = dataHandler.Load();
        if (this.gameData == null){
            Debug.Log("No Data found. New Game");
            NewGame();
        }
        foreach( MyDataParse DataParsesObj in DataParsesObjects){
            DataParsesObj.LoadData(gameData);
        }
        
         

    }
    public void SaveGame(){
        foreach (MyDataParse dataParseObj in DataParsesObjects){
            dataParseObj.SaveData(ref gameData);
        }
        Debug.Log(gameData.stars);
        dataHandler.Save(gameData);

    }
    private void OnApplicationQuit()
    {
        SaveGame();

    }
     private List<MyDataParse> FindallDataParseObjects(){
            IEnumerable<MyDataParse> DataParsesObjects = FindObjectsOfType<MonoBehaviour>().OfType<MyDataParse>();
            return new List<MyDataParse>(DataParsesObjects);
        }
}
