using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPhase : MonoBehaviour, TurnPhase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void turnStart()
    {
        throw new System.NotImplementedException();
    }

    public void DoPhase()
    {
        throw new System.NotImplementedException();
    }

    public void RecieveCameraControl(Camera cam)
    {
        throw new System.NotImplementedException();
    }

    public void informOfRealDad(TurnMaster master)
    {
        throw new System.NotImplementedException();
    }

    public bool amIDone()
    {
        throw new System.NotImplementedException();
    }
}
