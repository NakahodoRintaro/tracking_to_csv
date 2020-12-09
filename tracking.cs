using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System;
using System.IO;


public class tracking : MonoBehaviour
{
    //public GameObject Agent;
    [SerializeField, Tooltip("取得する間隔")]
    public float interval;

    private float time;
    private float exTime;
    [SerializeField, Tooltip("取得する時間")]
    public float exportTime;
    protected string ls;



    // Use this for initialization
    void Start()
    {
        name = this.name;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        exTime += Time.deltaTime;
        if (time > interval)
        {
            Vector3 pos = this.transform.position;
            var posStr = Time.realtimeSinceStartup.ToString() +","+pos.x + "," + pos.y + "," + pos.z;

            ls = ls + "\n" + posStr;
            time = 0;
        }


        if (exTime > exportTime)
        {
            //ここに処理
            StreamWriter sw = new StreamWriter(name + '_' + "pos.csv", false);
            sw.WriteLine(ls);
            sw.Flush();
            sw.Close();
            Debug.Log("Exported !!");
        }
    }
}