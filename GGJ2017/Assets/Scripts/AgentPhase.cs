using UnityEngine;

public class AgentPhase : MonoBehaviour, TurnPhase
{
    private int phase;
    public Vector3 endCam;
    public GameObject Agent;
    public GameObject FirstPerson;

    public float zoomInScale;
    public float globalScale;
    public float camSwooshSpeed;
    private float camSwoosh;

    private bool amDone;

    // Use this for initialization
	void Start ()
	{
	    amDone = false;
	}
	


    public void turnStart()
    {
        Debug.Log("start Agent turn");
        amDone = false;
        phase = 0;
    }

    public void DoPhase()
    {

    }

    public void RecieveCameraControl(Camera cam)
    {
    }

    public void informOfRealDad(TurnMaster master)
    {
    }

    public bool amIDone()
    {
        return true;
    }
}
