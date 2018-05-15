using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private float speed;
	

	// Update is called once per frame
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hardcoded the lose function for right now");
        Destroy(gameObject);
    }
}
