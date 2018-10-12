using UnityEngine;

public class Ball : MonoBehaviour {

    // config params
    [SerializeField] Podstawka paddle1;
    [SerializeField] float xPush = 2f, yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomnessCollision = 0.2f;

    // state
    Vector2 podstawkaDoKuliVector;
    // powinna byc inicjowana w "Start" - mam nadzieje, ze do tego wroce ;)
    bool hasStarted = false;

    // cached component
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

	// Use this for initialization
	void Start () {
        podstawkaDoKuliVector = transform.position - paddle1.transform.position;
        // w sumie zwykle przypisanie do zmiennej, mozna tez wywolac obiekt w ten sposob, bez zmiennej,
        // jak bylo w metodzie LaunchOnMouseClick()
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
//             GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            // powyzej stara wersja, ponizej nowa, w zwiazku z lektura 76, stworzylem zmienna, ktora moge
            // podmienic jako GetComp, zeden wow, ale przydatne do zapamietania
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x = Random.Range(0f, randomnessCollision);
        Vector2 velocityTweak = new Vector2(x, x);
        if (hasStarted)
        {
            // kolejna wskazowka na przyszlosc UnityEngine. itd wybiera z ktorej biblioteki metode uzywamy
            // poniewaz wycialem usingi systemowe, nie jest to potrzebne, ale zostawiam dla potomnych
            // powyzej Random uzywam bez tego ...
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            // velocity - wazna czesc - w sensie czesto do niej sie odwoluje...
            myRigidBody2D.velocity += velocityTweak;
        }
    }

}
