using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPhase : MonoBehaviour, TurnPhase
{
    private Camera agentCam;
    private int phase;
    public Vector3 startCam;
    public GameObject Agent;
    private Agent AgentComp;
    public GameObject FirstPerson;

    public float zoomInScale;
    public float globalScale;
    public float camSwooshSpeed;
    private float startCamScale;
    private float camSwoosh;
    private Vector3 agentStart;

    private bool amDone;
    private TurnMaster masterController;

    // Use this for initialization
	void Start ()
	{
	    AgentComp = Agent.GetComponent<Agent>();
	    amDone = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void turnStart()
    {
        startCam = agentCam.transform.position;
        startCamScale = agentCam.orthographicSize;
        agentStart = Agent.transform.position;
    }

    public void DoPhase()
    {
        //move cam to agent
        if (phase == 0)
        {
            agentCam.transform.position = Vector3.Lerp(startCam, Agent.transform.position, camSwoosh);
            agentCam.orthographicSize = Mathf.Lerp(startCamScale, zoomInScale, camSwoosh);

            camSwoosh += camSwooshSpeed;

            if (camSwoosh >= .9f)
            {
                camSwoosh = 0;
                phase++;
            }
        }
        //move agent
        else if (phase == 1)
        {
            if (AgentComp.Target == null)
            {
                AgentComp.Target = FirstPerson.GetComponent<Person>();
            }
            else
            {
                //determine other person here
            }

            Agent.transform.position = Vector3.Lerp(agentStart, AgentComp.Target.transform.position, camSwoosh);
            agentCam.transform.position = Agent.transform.position;

            camSwoosh += camSwooshSpeed;

            if (camSwoosh >= .9f)
            {
                camSwoosh = 0;
                phase++;
            }

        }
        //move cam to global view
        //done!
    }

    public void RecieveCameraControl(Camera cam)
    {
        agentCam = cam;
    }

    public void informOfRealDad(TurnMaster master)
    {
        masterController = master;
    }

    public bool amIDone()
    {
        return amDone;
    }
}
