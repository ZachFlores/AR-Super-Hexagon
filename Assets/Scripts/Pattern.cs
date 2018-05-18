using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pattern : MonoBehaviour {

    [System.Serializable]
    public class Row
    {
        public bool[] cols = new bool[6];
    }

    public Row[] rows;

}
