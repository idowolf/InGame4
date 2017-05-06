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
    private Vector3 startingPosition;
    public Material inactiveMaterial;
    public Material gazedAtMaterial;
    public ScoreManager levelScoreManager;
    private LinkedList<Vector3> positions;
    LinkedListNode<Vector3> current;
    static int TotalCubesCreated;
    private int CubeID;
    void Start()
    {
        startingPosition = transform.localPosition;
        positions = new LinkedList<Vector3>();
        positions.AddFirst(new Vector3(0, 0, -18));
        positions.AddLast(new Vector3(1.4f, 0, -18.77f));
        positions.AddLast(new Vector3(2.8f, 0, -20.85f));
        positions.AddLast(new Vector3(1.4f, 0, -23.73f));
        positions.AddLast(new Vector3(0, 0, -23.5f));
        positions.AddLast(new Vector3(-1.4f, 0, -23.73f));
        positions.AddLast(new Vector3(-2.8f, 0, -20.85f));
        positions.AddLast(new Vector3(-1.4f, 0, -18.77f));
        current = positions.First;
        transform.localPosition = current.Value;
        Vector3 pos = transform.localPosition;
        pos.y = GameObject.FindGameObjectWithTag("Player").transform.localPosition.y + 0.5f;
        transform.localPosition = pos;
        SetGazedAt(false);
        CubeID = 0;
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;          


    }

    public void Reset()
    {
        transform.localPosition = startingPosition;
    }

    public void TeleportRandomly()
    {
        current = current.Next ?? current.List.First;
        transform.localPosition = current.Value;
        Vector3 pos = transform.localPosition;
        pos.y = GameObject.FindGameObjectWithTag("Player").transform.localPosition.y + 0.5f;
        transform.localPosition = pos;
        TotalCubesCreated++;
        CubeID++;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        TeleportRandomly();
        levelScoreManager.DecreaseLives();
        //TotalCubesCreated++;
    }
}
