using System.Collections.Generic;
using UnityEngine;

public class TurnMaster : MonoBehaviour
{

    public List<GameObject> TurnPhases;
    public GameObject gameCam;

    private List<TurnPhase> turnParts;

    private int currentPhase;

    private bool firstTurn = true;

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
	    currentPhase = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (firstTurn)
	    {
            turnParts[currentPhase].informOfRealDad(this);
            turnParts[currentPhase].RecieveCameraControl(gameCam.GetComponent<Camera>());

            turnParts[currentPhase].turnStart();
	        firstTurn = false;
	    }

	   var turnPhase = turnParts[currentPhase];
	    if (!turnPhase.amIDone())
	    {
            turnPhase.DoPhase();
	    }
	    else
	    {
	        currentPhase++;
	        if (currentPhase >= turnParts.Count)
	        {
	            currentPhase = 0;
	        }
            turnParts[currentPhase].RecieveCameraControl(gameCam.GetComponent<Camera>());
            turnParts[currentPhase].turnStart();
	    }
	    
	}

    public void recieveTurnAction(TurnAction go)
    {
        
    }
}

public interface TurnPhase
{
    void turnStart();
    void DoPhase();
    void RecieveCameraControl(Camera cam);
    void informOfRealDad(TurnMaster master);
    bool amIDone();

}

public class TurnAction
{
    public TurnAction(int act, Lead leadA, Lead leadB)
    {
        action = act;
        A = leadA;
        B = leadB;
    }

    //rumor = 0
    public int action;

    public Lead A;
    public Lead B;
}
