using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    private void Awake()
    {
        TextAsset fileNameCSV = (TextAsset)Resources.Load("FileNameList") as TextAsset;
        string allData = fileNameCSV.text;
        string[] fileList = allData.Split('\n');

        for(int i = 1; i < fileList.Length - 1; ++i)
        {
            Debug.Log(fileList[i]);
            // ReadCSV(fileList[i]);
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void ReadAllStat()
    {

    }
    private void ReadCSV(string fileName)
    {
        TextAsset fileNameCSV = (TextAsset)Resources.Load(fileName) as TextAsset;
        string allData = fileNameCSV.text;
        string[] dataList = allData.Split('\n');

        for(int i = 1; i < dataList.Length - 1; ++i)
        {
            string[] splitedData = dataList[i].Split(',');
            
        }
    }
}
