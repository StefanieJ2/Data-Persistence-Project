using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0; 

  
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.score = score;

        // Transform Instance (data) to JSON, store it in the string variable 'json'
        string json = JsonUtility.ToJson(data);
    
        // Write 'json' string to persistentDataPath (determined by Platform) 
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        // takes the saved file, stores it into 'path'
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            // transform 'json' back, stores in class made for it (above)
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.score;
        }
    }
}
