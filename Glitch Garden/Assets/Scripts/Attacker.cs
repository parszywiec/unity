using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f,5f)][SerializeField] float currentSpeed = 0f;


	void Update () {
        // metoda do proszuszania obiektem, od razu ze wskaznikiem lewo/prawo/gora/dol itd.
        transform.Translate(Vector2.left * Time.deltaTime /*frame rate independent*/  *  currentSpeed);
	}

    public void setMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

}
