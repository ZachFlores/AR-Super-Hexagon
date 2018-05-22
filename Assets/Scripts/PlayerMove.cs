using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private GameManager manager;

    private float speed;

    private Transform originalTransform;

    private void Start()
    {
        originalTransform = gameObject.transform;
        StartOver();
    }

    void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(Vector3.up * Time.deltaTime * speed * -1);
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        manager.lose();
    }

    public void StartOver()
    {
        gameObject.transform.rotation = originalTransform.rotation;
        //take two "beats" to go 360 degrees
        speed = 1 / (manager.beatsPerMinute / 60);
        speed = 2 * speed * 360;
    }

    public void lose()
    {
        GetComponent<PlayerMove>().enabled = false;
    }
}
