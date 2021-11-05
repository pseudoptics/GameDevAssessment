using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    float screenHeight, screenWidth;
    float spawnHeight, spawnWidth;
    private GameObject spawnedCherry;
    public GameObject cherry;
    public Tweener tweener;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = 15;
        screenWidth = GetScreenRatio();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 10) {
            int edge = PickCameraEdge();
            Debug.Log(edge);
            switch (edge) {
                case 0:
                    spawnHeight = screenHeight + 2;
                    spawnWidth = Random.Range(-screenWidth, screenWidth);
                    break;
                case 1:
                    spawnHeight = Random.Range(-screenHeight, screenHeight); ;
                    spawnWidth = screenWidth + 2;
                    break;
                case 2:
                    spawnHeight = -screenHeight - 2;
                    spawnWidth = Random.Range(-screenWidth, screenWidth);
                    break;
                case 3:
                    spawnHeight = Random.Range(-screenHeight, screenHeight); ;
                    spawnWidth = -screenWidth - 2;
                    break;
            }
            spawnedCherry = Instantiate(cherry, new Vector3(spawnWidth, spawnHeight, 0), Quaternion.identity);
            tweener.CreateTween(spawnedCherry.transform, spawnedCherry.transform.position, new Vector3(-spawnWidth, -spawnHeight, 0), 10f);
            timer = 0;
        }

        if (!tweener.TweenExists()) {
            timer += Time.deltaTime;
            if (spawnedCherry != null) {
                Destroy(spawnedCherry);
            }
        }
    }

    private int PickCameraEdge()
    {
        return Random.Range(0, 4);
    }

    public int GetScreenRatio()
    {
        if (Camera.main.aspect > 2.1) {
            return 32;
        }

        else if (Camera.main.aspect > 1.7) {
            return 26;
        }

        return 20;
    }
}
