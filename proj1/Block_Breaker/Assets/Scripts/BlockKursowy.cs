using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockKursowy : MonoBehaviour {

    // config params
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int maxHits;  // w kursie przeniesione do metody HandleHit() i inicjowane jako dlugosc listy ze spritami +1, bo 1 sprite jest zainicjowany osobno w "Sprite Renderze"!
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
        // niby lepsza wersja przypisania ilosci hit pointow na podstawie ilosci spritow, a wiec ile razy go zmienimy tyle bedzie hit pointow miec klocek
        int maxHits = hitSprites.Length + 1;
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
        // poprawki zrobione - komenatrz zostawiam dla potomnych...
        int spriteIndex = hitsRecived-1;
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Block sprite is missing from array (its name - " + gameObject.name + ")");
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
