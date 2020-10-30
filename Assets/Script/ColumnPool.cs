using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int ColumnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = 0f;
    public float columnMax = 4f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(5f,-25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 15f;
    private int currentColumn = 0;
    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[ColumnPoolSize];
        for(int i = 0; i < ColumnPoolSize; i++){
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate){
            timeSinceLastSpawned = 0f;
            float spawnYPos = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPos);
            currentColumn++;
            currentColumn %=5;
        }
    }
}
