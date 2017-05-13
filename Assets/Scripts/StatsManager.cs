﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatsManager : MonoBehaviour {

    public class StatsNode : IComparable
    {
        public float value ;
        public DateTime date = new DateTime();
        public String name ;

        /*
         *adding the record to the records list.
         * flag - if 1, the smaller the better
         * else - the greater the better!!!
         * 
         */
        

        public StatsNode()
        {
            value = 0;
            date = DateTime.Now;
            name = "name";
        }

        public int CompareTo(StatsNode obj)
        {
            if (obj == null) return 0;
            if (this.value > obj.value)
            {
                return 1;
            }
            if (this.value < obj.value)
            {
                return -1;
            }
            else return 0;
        }

        public int CompareTo(object obj)
        {
            return CompareTo((StatsNode)obj);
        }

        public String ToString()
        {

            return ("value : " + value + " date: "  + date);
        }

    }

    

    public float timeFromStart , lastRotationTime;
    public int cameraYPosAtStart, cameraYpos;
    public float maxRotationTime, tempRotationTime;
    bool rotationFinished ;

    public float speed, maxSpeed;
    Vector3 lastPosition;

    public int maxCombo;

    public static int chartSize = 3;
    public static List<StatsNode> fastRotList = new List<StatsNode>();
    public static List<StatsNode> maxSpeedList = new List<StatsNode>();
    public static List<StatsNode> maxComboList = new List<StatsNode>();

    StatsNode speedRecord;
    StatsNode comboRecord;
    StatsNode rpmRecord;

    

    // Use this for initialization
    void Start () {
        maxRotationTime = float.MaxValue;
        timeFromStart = 0f;
        lastRotationTime = 0f;
        cameraYPosAtStart =(int) ((transform.parent.GetComponent<Transform>().rotation.y + 180) % 360);
        rotationFinished = false;
        
        lastPosition = GetComponent<Transform>().position;

        

        speedRecord = new StatsNode();
        comboRecord = new StatsNode();
        rpmRecord = new StatsNode();
        rpmRecord.value = float.MaxValue;

        
    }
	
	// Update is called once per frame
	void Update () {
        timeFromStart += Time.deltaTime;
        
        
        calcRotationTime();
        updateMaxCombo();
        updateMaxSpeed();
        lastPosition = GetComponent<Transform>().position;
        maxSpeed = 0f;

    }
    
    
    private void calcRotationTime() {
        cameraYpos =(int) ((transform.parent.GetComponent<Transform>().rotation.y + 180) % 360);
         
        if ((cameraYPosAtStart == cameraYpos))
        {
            if (rotationFinished)
            {
                tempRotationTime = timeFromStart - lastRotationTime;
                lastRotationTime = timeFromStart;
                
                if (tempRotationTime < maxRotationTime)
                {
                    maxRotationTime = tempRotationTime;
                    rpmRecord.value = maxRotationTime;
                }
                rotationFinished = false;
            }
            
        } else
        {
            rotationFinished = true;
        }
    }

    private void updateMaxCombo()
    {
        maxCombo = maxCombo < ComboManager.ComboLength ? ComboManager.ComboLength : maxCombo;
        comboRecord.value = maxCombo;
    }

    private void updateMaxSpeed()
    {
        speed = (GetComponent<Transform>().position - lastPosition).magnitude / Time.deltaTime;
        if (speed > maxSpeed)
        {
            maxSpeed = speed;
            speedRecord.value = maxSpeed;
            //Debug.Log("speed: " + speed);
        }
    }

    /*
     *update record tables, use when GAME is OVER 
     */
    public void updateRecordTable() {
        
        maxSpeedList.Add(speedRecord);
        maxComboList.Add(comboRecord);
        fastRotList.Add(rpmRecord);
        maxComboList.Sort();
        maxSpeedList.Sort();
        fastRotList.Sort();
        fastRotList.Reverse();
           
    }

    public void printRecordTable()
    {
        StatsNode temp;
        Debug.Log(maxSpeedList.Count);
        int num = Math.Min(3, maxSpeedList.Count);
        Debug.Log(maxSpeedList);
    }

   
}