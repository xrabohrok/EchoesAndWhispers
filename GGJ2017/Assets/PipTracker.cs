using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipTracker : MonoBehaviour
{

    public int pipsPerDay;

    private int workingPipsRemaining;
    public int pipsRemaining
    {
        get { return workingPipsRemaining; }
    }

    public void newTurnStarts()
    {
        workingPipsRemaining = pipsPerDay;
    }

	// Use this for initialization
	void Start () {
		
        newTurnStarts();
	}

    public bool attemptAddPips(int morePips)
    {
        if (morePips > workingPipsRemaining)
            return false;

        workingPipsRemaining -= morePips;
        return true;
    }


}
