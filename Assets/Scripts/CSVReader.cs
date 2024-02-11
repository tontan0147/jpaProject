using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    //// Singleton instance
    //private static CSVReader _instance;

    //public static CSVReader Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = FindObjectOfType<CSVReader>();

    //            if (_instance == null)
    //            {
    //                GameObject singletonObject = new GameObject("CSVReader");
    //                _instance = singletonObject.AddComponent<CSVReader>();
    //            }
    //        }

    //        return _instance;
    //    }
    //}

    //public TextAsset textAssetData;

    //[System.Serializable]
    //public class Dock
    //{
    //    public string name;
    //    public string information;
    //    public string boat;
    //}

    //[System.Serializable]
    //public class DockList
    //{
    //    public Dock[] dock;
    //}

    //public DockList myDockList = new DockList();

    //private void Awake()
    //{
    //    // Ensure only one instance exists
    //    if (_instance != null && _instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        _instance = this;
    //        DontDestroyOnLoad(gameObject); // Preserve the GameObject between scenes
    //    }
    //}

    //void Start()
    //{
    //    ReadCSV();
    //}

    //private void ReadCSV()
    //{
    //    if (textAssetData == null)
    //    {
    //        Debug.LogError("TextAssetData is not assigned!");
    //        return;
    //    }

    //    string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

    //    int tableSize = data.Length / 3 - 1;

    //    myDockList.dock = new Dock[tableSize];

    //    for (int i = 0; i < tableSize; i++)
    //    {
    //        myDockList.dock[i] = new Dock();
    //        myDockList.dock[i].name = data[3 * (i + 1)];
    //        myDockList.dock[i].information = data[3 * (i + 1) + 1];
    //        myDockList.dock[i].boat = data[3 * (i + 1) + 2];
    //    }
    //}

    //public string GetDockNameFromIndex(int index)
    //{
    //    //No need to use this function if we create it as instance script
    //    if (myDockList == null)
    //    {
    //        Debug.Log("Dock list is empty!");
    //        return null;
    //    }
    //    return myDockList.dock[index].name;
    //}
}