using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEdge : MonoBehaviour {

    [SerializeField]
    protected float mInitialSpeed;

    protected GameObject HexBase;
    protected Transform baseTransform;

	protected virtual void Start () {

        HexBase = GameObject.FindWithTag("Base");
        baseTransform = HexBase.transform;
	}
	
	// Update is called once per frame
	protected virtual void Update () {

        //move towards the center
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, baseTransform.position, mInitialSpeed * Time.deltaTime);
        //scale the edge while it moves
        transform.localScale = new Vector3(calculateLength(), transform.localScale.y, transform.localScale.z);
	}

    private float calculateLength()
    {
        float lengthBetween = (baseTransform.position - gameObject.transform.position).magnitude;
        float newLength = (2 * lengthBetween) / Mathf.Sqrt(3);
        //if it reached the center destroy it
        if(newLength <= 0)
        {
            Destroy(gameObject);
        }
        return newLength;
    }
}
