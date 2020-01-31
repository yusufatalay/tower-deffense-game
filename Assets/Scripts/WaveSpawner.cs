using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves; 
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;//time needed to spawn other waves
    public Text waveCountdownText;
    private float countdown = 2f;  //initially: tiem requires to spawn the first wave

    private int waveIndex= 0;
    void Update()
    {
        if (EnemiesAlive>0)
        {
            return;
        }
        if (countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return; 
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);

        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("LEVEL COMPLETED!!!!!!!!!!!");
            this.enabled = false;  //if there is no more wave to spawn this line of code will disable "this" "WaveSpawner" script
        }

    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position,spawnPoint.rotation);
        EnemiesAlive++;
    }

}
