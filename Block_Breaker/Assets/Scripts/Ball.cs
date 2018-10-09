using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // config params
    [SerializeField] Podstawka paddle1;
    [SerializeField] float xPush = 2f, yPush = 15f;

    //state
    Vector2 podstawkaDoKuliVector;
    // powinna byc inicjowana w "Start" - mam nadzieje, ze do tego wroce ;)
    bool hasStarted = false;

	// Use this for initialization
	void Start () {
        podstawkaDoKuliVector = transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted) // znaczy to samo, oba dzialaja -- hasStarted != true
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 pozycPodstawki = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = pozycPodstawki + podstawkaDoKuliVector;
    }
    private void LaunchOnMouseClick()
    {
        // tylko transform mozna dostac od tak, bo kazdy obiekt w unity go ma,
        // inne (dodawane) komponenty adresujemy GetComponent... (jak ponizej)

        if (Input.GetMouseButtonDown(0))
        {
            // jak napisane w nazwie metody, polecenie poniezej startuje kule
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }
}
