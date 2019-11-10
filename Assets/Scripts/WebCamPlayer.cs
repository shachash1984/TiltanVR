using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamPlayer : MonoBehaviour {

    public Material renderMaterial;

	void Start () {
        WebCamTexture webcamTexture = new WebCamTexture();
        renderMaterial.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
	
	
}
