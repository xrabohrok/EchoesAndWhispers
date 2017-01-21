using System.Collections.Generic;
using UnityEngine;

public class TurnMaster : MonoBehaviour
{

    public List<GameObject> TurnPhases;
    public GameObject gameCam;

    private List<TurnPhase> turnParts;

	// Use this for initialization
	void Start () {
		turnParts = new List<TurnPhase>();
	    foreach (var turnPhase in TurnPhases)
	    {
	        var temp = turnPhase.GetComponent<TurnPhase>();
	        if (temp != null)
	        {
	            turnParts.Add(temp);
	        }
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    foreach (var turnPhase in turnParts)
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
