using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pattern : MonoBehaviour {

    [System.Serializable]
    public class Row
    {
        public bool[] cols = new bool[6];
    }

    //float for the rate at the beat of the music will come
    public float rate;
    public Row[] rows;

}
