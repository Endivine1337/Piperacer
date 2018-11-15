using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour {
    public GameObject Obstacle;
    public GameObject ObstaclePivot;
    

    public float acceleration = 0.1f;
    public float startSpeed = 1f;

    private float offset;

    private Queue<GameObject> obstacles = new Queue<GameObject>();
    // Use this for initialization
    void Start () {
        for (var i = 0; i < 10; i++)
        {
            var obst = Instantiate(Obstacle);
            obst.SetActive(i > 1);
            obst.transform.SetParent(ObstaclePivot.transform);
            RandomPosition(obst.transform, i * 4f + 1f);
            //obst.transform.localScale = Vector3.one * 5;

            obstacles.Enqueue(obst);
        }

    }
	
	// Update is called once per frame
	void Update () {
        
        var dt = -(startSpeed + acceleration * Time.timeSinceLevelLoad) * Time.deltaTime;
        offset += dt;
        if (offset < -4f)
        {
            offset += 4f;
            var obst = obstacles.Dequeue();
            RandomPosition(obst.transform, obstacles.Count * 4f + offset);
            obst.SetActive(true);
            //segment.transform.position = new Vector3(0, 50f, obstacles.Count * 4f + offset);
            //randomize Position(Pipe Rotation)
            obstacles.Enqueue(obst);
        }

        var i = 0;
        foreach (var obst in obstacles)
        {
            obst.transform.localPosition = new Vector3(obst.transform.localPosition.x, obst.transform.localPosition.y, i * 4f + offset);
            //obst.transform.Translate(0, 0, i * 4f + offset);
            i++;
        }
    }

    void RandomPosition(Transform obst, float z)
    {
        var angle = Random.value * Mathf.PI * 2;
        var x = Mathf.Cos(angle) * 0.4f;
        var y = Mathf.Sin(angle) * 0.4f;
        obst.localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
        obst.localPosition = new Vector3(x, y, z);
    }
}
