using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseInit : MonoBehaviour
{

    public UnityEvent OnFirebaseLoaded = new UnityEvent();

    async void Start()
    {
        var dependencyStatus = await FirebaseApp.CheckDependenciesAsync();
        if (dependencyStatus == DependencyStatus.Available)
        {
            OnFirebaseLoaded.Invoke();
        }

    }

}
