using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Authentication.ExtendedProtection;
using System.Xml;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class FenceGenerator : MonoBehaviour
{
    public GameObject[] fenceObject;

    float[] fencePositionX = { 0.5f, 0.5f, 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f, 7.5f, 7.5f, 6.5f, 5.5f, 4.5f, 3.5f, 2.5f, 1.5f, 0.5f };
    float[] fencePositionY = { 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f, 0.49f,  0.49f};
    float[] fencePositionZ = { 0.5f, 1.5f, 2.5f, 3.5f, 3.5f, 3.5f, 3.5f, 3.5f, 2.5f, 1.5f, 0.5f, -0.5f, -1.5f, -1.5f, -1.5f, -1.5f, -1.5f, -1.5f, -0.5f };

    [SerializeField] private string fencePath = "fence/bAKeiGxuSsiTHmoZMe3t";

    [FirestoreData]
    public struct FenceData {
        [FirestoreProperty] public Array position {get; set;}
    

    }


    public void GetData()
    {





        var firestore = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = firestore.Document(fencePath);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            Debug.Log(task.Result.ConvertTo<FenceData>());

        });
    }

    public void GenerateFence()
    {
        GetData();

        for (int i = 0; i < fenceObject.Length; i++)
        {
            Vector3 spawnPosition = new Vector3(fencePositionX[i], fencePositionY[i], fencePositionZ[i]);
            Instantiate(fenceObject[i], spawnPosition, Quaternion.identity);
        }


    }




}
