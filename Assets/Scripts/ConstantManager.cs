using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConstantManager : MonoBehaviour
{
    public static ConstantManager Instance;
    public string playerName;
    public string champion;
    public int highScore;

    // Start is called before the first frame update

    private void Awake()
    {
        //Debug.Log(Application.persistentDataPath);
        LoadScore();
        if(Instance!=null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string champion;
        public int highScore;
    }
    public void SaveScore(int m_Points)
    {
        Debug.Log("Recieved");
        if (m_Points > highScore)
        {
            Debug.Log("Saved");
            SaveData data = new SaveData();
            data.champion = playerName;
            data.highScore = m_Points;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            champion = data.champion;
            highScore = data.highScore;
        }
        else
        {
            return;
        }
    }
}
