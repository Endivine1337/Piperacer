using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {

       // Debug.Log(gameObject.name + "was triggered by" + other.gameObject.name);
        if (other.tag == "Obstacle")
        {
            Debug.Log(gameObject.name + "was triggered by" + other.gameObject.name);
            StartCoroutine(playerDeath());
            //SceneManager.LoadScene("menu");
        } 
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator playerDeath()
    {
        Destroy(this.gameObject.GetComponent<MeshRenderer>());
        Destroy(this.gameObject.GetComponent<CapsuleCollider>());
        Destroy(this.gameObject.GetComponent<PlayerController>());
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("menu");

    }
}
