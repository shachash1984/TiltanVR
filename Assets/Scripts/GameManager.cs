using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager S;
    [HideInInspector] public Transform cameraTransform;

    private void Awake()
    {
        if (S != null)
            Destroy(gameObject);
        S = this;
        cameraTransform = Camera.main.transform;
        
    }

    
}
