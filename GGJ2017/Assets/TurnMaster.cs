using System.Collections.Generic;
using UnityEngine;

public class TurnMaster : MonoBehaviour
{

    public List<TurnPhase> TurnPhases;
    public GameObject gameCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    foreach (var turnPhase in TurnPhases)
	    {
	        if (!turnPhase.amIDone())
	        {
	            turnPhase.RecieveCameraControl(gameCam.GetComponent<Camera>());
                turnPhase.DoPhase();
	        }
	    }
	}
}

public interface TurnPhase
{
    void DoPhase();
    void RecieveCameraControl(Camera cam);
    bool amIDone();

}
