// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
    //private Vector3 startingPosition;
    //public Material inactiveMaterial;
    //public Material gazedAtMaterial;
    public ScoreManager levelScoreManager;
    //private LinkedList<Vector3> positions;
    //LinkedListNode<Vector3> current;
    //static int TotalCubesCreated;
    public int cubeID;
    public EnemyManager EnemyManager;
    public GameObject playerCamera;
    public Transform enemyUI;

    
    private SizeController sizeController = new SizeController();
    private bool isGazed = false;

    public void SetID(int ID)
    {
        this.cubeID = ID;
    } 
    void Start()
    {
        sizeController.isTouched = false;
        sizeController = GetComponent<SizeController>();
    }

    private void Update()
    {
        if (isGazed)
        {
            SetPathHeight();
        }
        //Debug.Log( playerCamera.GetComponent<Transform>().eulerAngles.x);
    }
    private void TeleportRandomly()
    {
        
    }

   
    public void PlayerGazedAtMe()
    {
        sizeController.isTouched = true;
        GetComponent<EnemyPath>().speed = 2.5f;
        isGazed = true;
    }

    public void PlayerStopGazedAtMe()
    {
        sizeController.isTouched = false;
        //GetComponent<EnemyPath>().speed = 0;
        isGazed = false;

    }

    public void SetPathHeight()
    {
        float camRotX = playerCamera.GetComponent<Transform>().eulerAngles.x;
        Vector3 newPosition = new Vector3();
        newPosition = enemyUI.transform.localPosition;
        //Debug.Log("camRotX is : " + camRotX);
        if (camRotX < 330 && camRotX >= 275)
        {
            newPosition.y = -0.35f;
            enemyUI.transform.localPosition = newPosition ;

            return;
        }
        if (camRotX >= -1 && camRotX <85 )
        {
            newPosition.y = 0.35f;
            enemyUI.transform.localPosition = newPosition;

            return;
        }
        newPosition.y = 0.0f;
        enemyUI.transform.localPosition = newPosition;

        return;
    }

}
