using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using System;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

[Serializable]
public class UserData {
    public string userData; 
    public float KD;
}

public class UserDataManagment : MonoBehaviour {
    public UserData userData;
    DatabaseReference dbReference;
    [SerializeField] FirebaseAuth auth;
    [SerializeField] string userID;

    private async void Awake() {
        var dependencies = await FirebaseApp.CheckAndFixDependenciesAsync();

        if (dependencies != DependencyStatus.Available) {
            Debug.LogError("Not aviable" + dependencies);
            return;
        }

        auth = FirebaseAuth.DefaultInstance;

        userID = auth?.CurrentUser.UserId;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.LogWarning("Firebase is redy. CurrentID: " + userID);

    }

    public void SaveData() {
        if (!IsRedy()) return;

        string json = JsonUtility.ToJson(userData);
        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task => {
            if (task.IsCanceled) { Debug.Log("Save canceled"); return; }
            if (task.IsFaulted) { Debug.Log("Save failed" + task.Exception); return; }
            Debug.Log("Save succesgfull for UID: " + userID);
        });
    }

    private bool IsRedy() {
        if (auth == null || dbReference == null) {
            Debug.LogError("Firebase is not yet initialized");
            return false;
        }
        if (auth.CurrentUser == null) {
            Debug.LogError("No user detected");
            return false;
        }
        if (string.IsNullOrEmpty(userID)) {
            userID = auth.CurrentUser.UserId;
        }

        return true;
    }

    public string UserID {
        get { return userID; }
    }

}
