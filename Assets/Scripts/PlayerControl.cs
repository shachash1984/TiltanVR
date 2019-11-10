using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    Rigidbody _rigidBody;
    [SerializeField] float speed;
    public bool canWalk;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputManager.S.OnJoystickAxisInputEvent += Walk;
        InputManager.S.OnJoystickTriggerInput += Shoot;
    }

    private void OnDisable()
    {
        InputManager.S.OnJoystickAxisInputEvent -= Walk;
        InputManager.S.OnJoystickTriggerInput -= Shoot;
    }

    private void FixedUpdate()
    {
        if (canWalk)
        {
            //Vector3 camForward = GameManager.S.cameraTransform.forward;
            //_rigidBody.MovePosition(transform.position + camForward * Time.deltaTime * speed);
        }
    }

    void Walk(float x, float y)
    {
        if(canWalk)
        {
            Transform camTransfornm = GameManager.S.cameraTransform;
            Vector3 direction = camTransfornm.forward * y + camTransfornm.right * x;
            _rigidBody.velocity = direction * speed * Time.deltaTime;
            //Debug.Log(_rigidBody.velocity);
        }

    }

    void Shoot()
    {

    }

}
