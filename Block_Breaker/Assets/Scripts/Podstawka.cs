using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podstawka : MonoBehaviour {

    // configuration parameters
    [SerializeField] float minX = 0.5f, maxX = 15.5f;
    [SerializeField] float widthInUnits; // 16f - wartosc domyslna powinna byc, do zapamietania, ze mozna bez

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
                Debug.Log(Input.mousePosition.x/Screen.width * widthInUnits);
                // Vector2 bo x,y -- Vector3 gdyby x,y,z
                Vector2 paddlePosit = new Vector2(10f, 0.15f);
                // transform.position odnosi sie do unity transform -> position (inspector)
                // pamietaj, ze script przypisany jest do Podstawika... , wiec na niego dziala,
                // przestawi paletke na podane wartosci!
                transform.position = paddlePosit;
        */

        float mousePositionX = Input.mousePosition.x / Screen.width * widthInUnits;
        Vector2 paddlePosit = new Vector2(transform.position.x, transform.position.y);
        paddlePosit.x = Mathf.Clamp(mousePositionX, minX, maxX); //ogranicza zakres, w tym wypadku x
        transform.position = paddlePosit;

    }
}
