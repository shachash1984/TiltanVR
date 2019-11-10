using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LookAtHandler : MonoBehaviour {

    public delegate void LookStatusChanged(LookAtHandler l, bool isLooking);
    public static event LookStatusChanged OnLookStatusChanged;
    public Transform camTransform;
    Material _material;
    float _deltaDegrees;
    float maxFocusDegrees = 10;
    public bool isLookingAtMe = false;

    public float DeltaDegrees
    {
        get
        {
            return _deltaDegrees;
        }

        set
        {
            if(value != _deltaDegrees)
            {
                _deltaDegrees = value;
            }
            //DegreeValueChanged();
        }
    }

    void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }


    private void Start()
    {
        camTransform = GameManager.S.cameraTransform;
    }

    //void DegreeValueChanged()
    //{
    //    if(isLookingAtMe)
    //    {
    //        ChangeColor(Color.green);
    //    }
    //    else
    //    {
    //        ChangeColor(Color.white);
    //    }
    //}

    public void HandleLookAt(Collider c)
    {
       
        if (!isLookingAtMe && c.Equals(GetComponent<Collider>()))
        {
            isLookingAtMe = true;
            if (OnLookStatusChanged != null)
                OnLookStatusChanged(this, true);
            Utils.ChangeColor(_material, Color.green);
        }
        else if(isLookingAtMe && c.Equals(GetComponent<Collider>()))
        {
            isLookingAtMe = false;
            if (OnLookStatusChanged != null)
                OnLookStatusChanged(this, false);
            Utils.ChangeColor(_material, Color.white);
        }
        else if(DeltaDegrees > maxFocusDegrees)
        {
            isLookingAtMe = false;
            if (OnLookStatusChanged != null)
                OnLookStatusChanged(this, false);
            Utils.ChangeColor(_material, Color.white);
        }

    }



    private void OnGUI()
    {
        GUILayout.Label("Delta Degrees: " + DeltaDegrees.ToString("f2"));
        GUILayout.Label("Is looking at me: " + isLookingAtMe.ToString());
    }
}
