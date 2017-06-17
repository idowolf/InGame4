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
    //public EnemyManager EnemyManager;
    public GameObject playerCamera;
    public YAxisMovement enemyUI;
    public AudioSource audio;
    public Transform burstComponent;
    ParticleSystem.EmissionModule em1;
    List<Transform> emch;

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
        emch = new List<Transform>();
        emch.Add(burstComponent);
        foreach (Transform child in burstComponent)
        {
            emch.Add(child);
            ParticleSystem.EmissionModule em1 = child.GetComponent<ParticleSystem>().emission;
            em1.enabled = false;
        }
        audio = GetComponent<AudioSource>();


    }

    private void Update()
    {
        if (isGazed)
        {
            SetPathHeight();
        }
    }
    private void TeleportRandomly()
    {

    }


    public void PlayerGazedAtMe()
    {
        isGazed = true;
        sizeController.isTouched = true;
        GetComponent<EnemyPath>().speed = 2.5f;
        foreach (Transform child in emch)
        {
            ParticleSystem.EmissionModule em1 = child.GetComponent<ParticleSystem>().emission;
            em1.enabled = true;
        }
        audio.GetComponent<AudioSource>().enabled = true;
        audio.Play();
             
    }
    public void PlayerStopGazedAtMe()
        {
            sizeController.isTouched = false;
            //GetComponent<EnemyPath>().speed = 0;
            isGazed = false;
            StartCoroutine(stopBurst());

        }

    IEnumerator stopBurst()
    {
        yield return new WaitForSeconds(.1f);
        foreach (Transform child in emch)
        {
            ParticleSystem.EmissionModule em1 = child.GetComponent<ParticleSystem>().emission;
            em1.enabled = false;
        }
        audio.GetComponent<AudioSource>().enabled = false;
    }


    

    public void SetPathHeight()
    {
        float camRotX = playerCamera.GetComponent<Transform>().eulerAngles.x;
        //Vector3 newPosition = new Vector3();
        //newPosition = enemyUI.transform.localPosition;
        if (camRotX < 330 && camRotX >= 275)
        {
            enemyUI.SetYTarget(2);

            return;
        }
        if (camRotX >= -1 && camRotX <85 )
        {
            enemyUI.SetYTarget(-2);

            return;
        }
        if (enemyUI.transform.localPosition.y != 0f)
        {
            enemyUI.SetYTarget(0);
            return;
        }
    }

}
