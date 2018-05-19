using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour {

    [SerializeField]
    private GameManager gameManager;
    //Edge Prefabs
    [SerializeField]
    private GameObject topLeft;
    [SerializeField]
    private GameObject left;
    [SerializeField]
    private GameObject bottomLeft;
    [SerializeField]
    private GameObject bottomRight;
    [SerializeField]
    private GameObject right;
    [SerializeField]
    private GameObject topRight;

    //array of patterns, to be put in by designer
    [SerializeField]
    private Pattern[] patterns;
    //stack of patterns to be used
    private Stack<Pattern> patternStack = new Stack<Pattern>();

    private Pattern currentPattern;
    bool patternSpawning = false;
    private float spawnRate;
    private float spawnTimer;

    private int rowIndex;
    // Use this for initialization
    void Start() {
        //shuffle algorithm here
        //push all patterns into a stack;
        for (int i = 0; i < patterns.Length; i++)
        {
            patternStack.Push(patterns[i]);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!patternSpawning && patternStack.Count != 0)
        {
            currentPattern = patternStack.Peek();
            rowIndex = 0;
            patternSpawning = true;
            spawnRate = 1 / ((gameManager.beatsPerMinute / currentPattern.rate)/60);
            spawnTimer = spawnRate;
            patternStack.Pop();
        }

        else if (patternSpawning)
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <=0)
            {
                if(rowIndex < currentPattern.rows.Length)
                {
                    spawn((currentPattern.rows)[rowIndex]);
                    rowIndex++;
                }
                else
                {
                    patternSpawning = false;
                }
                spawnTimer = spawnRate;
            }
        }

        else if (patternStack.Count == 0)
        {
            //win condition stuff
            Debug.Log("congrats, you beat the level");
        }
		
	}

    private void spawn(Pattern.Row row)
    {
        if (row.cols[0])
            Instantiate(topLeft, gameObject.transform);
        if (row.cols[1])
            Instantiate(left, gameObject.transform);
        if (row.cols[2])
            Instantiate(bottomLeft, gameObject.transform);
        if (row.cols[3])
            Instantiate(bottomRight, gameObject.transform);
        if (row.cols[4])
            Instantiate(right, gameObject.transform);
        if (row.cols[5])
            Instantiate(topRight, gameObject.transform);
    }
}
