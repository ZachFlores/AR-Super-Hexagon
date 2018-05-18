using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float speed;
	

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
        Debug.Log("Hardcoded the lose function for right now");
        Destroy(gameObject);
    }
}
