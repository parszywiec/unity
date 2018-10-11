using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockKursowy : MonoBehaviour {

    // config params
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;

    // state variables
    [SerializeField] int hitsRecived; // serialized for debug purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<Level>();
            level.SumOfBreakableBlcks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        hitsRecived++;
        if (maxHits <= hitsRecived)
        {
            DestoryBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        // do przemyslenia block domyslny 0 pomijamy tym sposobem, zaladowalem do gry dodatkowo na zero
        // block startowy, a moglem pominac i zaczac od uszkodzonego, bo startowy jest na starcie
        // wtedy hitsRecived beda -1 tak jak w kursie !!! 
        // toDo!
        // kolejna sprawa dodatkowe tagi sa zbedne, maxHitsy po prostu ustawiam na inna wartosc... da...
        int spriteIndex = hitsRecived;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestoryBlock()
    {
        Destroy(gameObject);
        level.BlockDestoyed();
        PlayBlockDestorySFK();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestorySFK()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        // odwolanie odrazu do innego obieku z tej gry, bez inicjowania zmiennej itd !!!!! 
        // MEGA IMPORTANTE RZECZ!!! <-
        FindObjectOfType<GameSession>().addToScore();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position , transform.rotation);
        // niszczy obiekty tymczasowe, po sekundzie, pytanie czemu sparkles zaklada 2 obiekty, a nie 1?
        Destroy(sparkles, 1f);
    }
}
