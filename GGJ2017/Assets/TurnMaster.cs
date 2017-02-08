using System.Collections.Generic;
using UnityEngine;

public class TurnMaster : MonoBehaviour
{

    public List<GameObject> TurnPhases;
    public GameObject gameCam;

    private List<TurnPhase> turnParts;

    public int day;
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
        day = 1;
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
                day++;
	            currentPhase = 0;
                if(day > 15)
                {
                    // gameover?
                }
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
    public TurnAction(int act, Person personA, Person personB)
    {
        action = act;
        A = personA;
        B = personB;
    }
    
    public int action;

    public Person A;
    public Person B;
}
