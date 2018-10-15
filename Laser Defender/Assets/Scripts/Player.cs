using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 10f;
    // zmienna okresla jak daleko od granicy ekranu moze byc nasz "samolot" (obiekt player)
    [SerializeField] float padding = 0.5f;
    [SerializeField] GameObject playerLaser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    Coroutine firingCoroutine;

    float xMin, xMax, yMin, yMax;

    // Use this for initialization
    void Start () {
        SetUpMoveBondaries();

        // Coroutine - czyli metoda do robienia czegos w sposob ciagly do spelnienia jakiegos warunku - np strzelaj puki spacja jest przycisnieta 
        // StartCoroutine(WaitForThreeSec());
	}

    // Update is called once per frame
    void Update () {
        Move();
        Fire();

    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(playerLaser, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move()
    {
        // Time.deltaTime podaje ile czasu trwal ostatni frame (fps)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        // Debug.Log(deltaX);
        // dobra funkcja/metoda - pamietaj o niej... (Mathf.Clamp) daa!
        var newXPosit = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosit = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2 (newXPosit, newYPosit);
    }

    private void SetUpMoveBondaries()
    {
        Camera gameCamera = Camera.main;
        // w tym wypadku zamyka ekran na wartosciach naszej kamery, sam ma zakresy od 0 do 1, czyli 0 dla x to wartosc lewej granicy kamery, a wiec tego
        // co widzimy w grze
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        // w wektorze y i z jest w tym wypadku bez znaczenia, bo bierzemy tylko wartosc x
        // czyli bierze 1 - to jest skrajna wartosc x dla camery i podstawia wartosc z naszej plaszczyzny gry atm ~5.62
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        // Debug.Log(xMin);
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 1)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

/* // Playin with Coroutine
    private IEnumerator WaitForThreeSec()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(3);
        Debug.Log(Time.time);
    }
*/
}
