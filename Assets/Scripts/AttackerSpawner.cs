using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float timeToStartSpawning = 0f;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;
    float spawnerTimer = 0f;
    bool spawningStarted = false;

    bool spawn = true;

    private void Update()
    {
        CheckForStartSpawning();
    }

    private void CheckForStartSpawning()
    {
        if (spawningStarted) { return; }
        spawnerTimer += Time.deltaTime;
        if (spawnerTimer >= timeToStartSpawning)
        {
            StartCoroutine(StartSpawning());
            spawningStarted = true;
        }
    }

    IEnumerator StartSpawning()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            if (!spawn) { yield break; }
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
                    (myAttacker, transform.position, transform.rotation)
                    as Attacker;
        newAttacker.transform.parent = transform;
    }
}
