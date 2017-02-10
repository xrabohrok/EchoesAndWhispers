using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDistilationPhase : MonoBehaviour, TurnPhase {
    private Camera theCam;
    private TurnMaster myMaster;

    // Use this for initialization
	void Start () {
		
	}

    public void turnStart()
    {
        //not much to do here
    }

    public void DoPhase()
    {
        throw new System.NotImplementedException();
    }

    public void RecieveCameraControl(Camera cam)
    {
        theCam = cam;
    }

    public void informOfRealDad(TurnMaster master)
    {
        myMaster = master;
    }

    public bool amIDone()
    {
        throw new System.NotImplementedException();
    }
}
