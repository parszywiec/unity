using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockKursowy : MonoBehaviour {

    [SerializeField] AudioClip destroySound;

    // cached reference
    Level level;


    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.SumOfBreakableBlcks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestoryBlock();
    }

    private void DestoryBlock()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestoyed();
        // odwolanie odrazu do innego obieku z tej gry
        FindObjectOfType<GameStatus>().addToScore();        
    }
}
