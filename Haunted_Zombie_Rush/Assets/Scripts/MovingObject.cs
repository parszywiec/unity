using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    [SerializeField] private float objectSpeed = 1.5f;
    [SerializeField] private float resetPosition = 0f; // -57.92655
    [SerializeField] private float startPosition = 0f; // 98.07359
    //private float poprawnaStartPozycja = 156f;

    protected virtual void Update () {
        MoveLeft();

    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);
        if(transform.localPosition.x <= resetPosition)
        {
            Vector3 newPosition = new Vector3(startPosition, transform.position.y, transform.position.z);
            //Vector3 newPosition = new Vector3(poprawnaStartPozycja + transform.position.x, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
