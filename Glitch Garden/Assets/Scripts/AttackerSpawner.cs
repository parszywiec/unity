using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    bool spawn = true;
    [SerializeField] Attacker Lizard;
    [SerializeField] float minSpawnDelay = 1f, maxSpawnDealy = 5f;


	IEnumerator Start () {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDealy));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Instantiate(Lizard, transform.position, transform.rotation);
    }
}
