using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : Pool<Asteroid>
{
    private float padding;

    [Space(20)] 
    [SerializeField] private Transform initialTop;
    [SerializeField] private Transform initialBot;
    [SerializeField] private Transform rightWall;

    private GameSettings gameSettings;
    private int initialAmount;
    private float time;
    private float spawnProbability;

    private const float minScale = 0.5f;
    private const float maxScale = 1.2f;

    protected override void Awake()
    {
        base.Awake();

        gameSettings = Resources.Load<GameSettings>("GameSettings");
        initialAmount = gameSettings.AsteroidsInitialAmount;
        time = gameSettings.AsteroidsSpawnFrequently;
        spawnProbability = gameSettings.AsteroidsSpawnProbability;

        GlobalEvents.Other.AsteroidsStarted.Event += SpawnOnStart;
        padding = rightWall.position.x;
    }

    private void Start()
    {
        SpawnInitial();
    }

    private void SpawnOnStart()
    {
        StartCoroutine(SpawningCoroutine());
    }

    private void SpawnInitial()
    {
        var height = initialTop.position.y - initialBot.position.y;
        for (int i = 0; i < initialAmount; i++)
        {
            var posX = parent.transform.position.x + Random.Range(-padding, padding);
            var posY = initialBot.position.y + i * (height / initialAmount);
            SpawnOnce(posX, posY);
        }
    }

    private IEnumerator SpawningCoroutine()
    {
        yield return new WaitForEndOfFrame();
        while (GameInfo.IsAsteroidStarted)
        {
            if (Random.Range(0.0f, 1.0f) >= 1.0f - spawnProbability)
            {
                var posX = parent.transform.position.x + Random.Range(-padding, padding);
                var posY = parent.transform.position.y;
                SpawnOnce(posX, posY);
            }
            yield return new WaitForSeconds(time);
        }
        
    }

    private void SpawnOnce(float x, float y)
    {
        var rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        var scale = Random.Range(minScale, maxScale);
        var instance = Spawn(new Vector3(x, y), rotation);
        instance.transform.localScale = new Vector3(scale, scale, 1.0f);
        instance.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GlobalEvents.Other.AsteroidsStarted.Event -= SpawnOnStart;
    }
}
