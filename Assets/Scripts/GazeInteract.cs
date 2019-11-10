using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInteract : MonoBehaviour {

    public LayerMask layerMask;
    RaycastHit hit;
    RaycastHit prevHit;
    LookAtHandler currentTarget;

	
	void Update () {
        
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100f ,layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentTarget = hit.collider.GetComponent<LookAtHandler>();
            if (!currentTarget.isLookingAtMe)
                currentTarget.HandleLookAt(hit.collider);
            prevHit = hit;
        }
        else
        {
            if(prevHit.collider != null)
            {
                currentTarget.HandleLookAt(prevHit.collider);
            }
            prevHit = hit;
            currentTarget = null;
        }
	}
}
