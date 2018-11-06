using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeFactory : MonoBehaviour {
    public GameObject PipeSegment;

    private Queue<GameObject> pipes = new Queue<GameObject>();
    private float offset;

    public float acceleration = 0.1f;
    public float startSpeed = 1f;
       

	// Use this for initialization
	void Start () {
        for (var i = 0; i < 10; i++)
        {
            var segment = Instantiate(PipeSegment);
            segment.transform.rotation = Quaternion.Euler(0, 0, 90);
            segment.transform.Translate(0, 0, i * 4f);
            segment.transform.localScale = Vector3.one * 5;
            pipes.Enqueue(segment);
        }
	}

    // Update is called once per frame
    void Update()
    {
        var dt = -(startSpeed + acceleration * Time.timeSinceLevelLoad) * Time.deltaTime;
        offset += dt;

        if (offset < -4f)
        {
            offset += 4f;
            var segment = pipes.Dequeue();
            segment.transform.position = new Vector3(0, 0, pipes.Count * 4f + offset);
            pipes.Enqueue(segment);
        }

        var i = 0;
        foreach (var segment in pipes)
        {
            segment.transform.position = new Vector3(0, 0, i * 4f + offset);
            i++;
        }
    }
}
