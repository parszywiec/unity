using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakableBlockCount; // Serialized for debuging purposes
    [SerializeField] int toWinBlockNumber = 0; // do testowania, win condition ile klockow moze zostac pomimo wygranej

    // cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void SumOfBreakableBlcks()
    {
        breakableBlockCount++;
    }

    public void BlockDestoyed()
    {
        breakableBlockCount--;
        if (breakableBlockCount <= toWinBlockNumber)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
