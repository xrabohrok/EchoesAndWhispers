using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPhase : MonoBehaviour, TurnPhase
{
    private Camera agentCam;
    private int phase;
    private Vector3 startCam;
    public Vector3 endCam;
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
        Debug.Log("start Agent turn");
        agentStart = Agent.transform.position;
        amDone = false;
        phase = 0;
    }

    public void DoPhase()
    {
        //move cam to agent
        if (phase == 0)
        {
            agentCam.transform.position = Vector2.Lerp(startCam, Agent.transform.position, camSwoosh);
            agentCam.transform.position = new Vector3(agentCam.transform.position.x, agentCam.transform.position.y, -10);
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
                var connections = AgentComp.Target.getConnections();
                var otherPeople = new List<Person>();
                foreach (var connection in connections)
                {
                    if (connection.personB != AgentComp.Target && connection.personB.alive)
                        otherPeople.Add(connection.personB);
                    if (connection.personA != AgentComp.Target && connection.personA.alive)
                        otherPeople.Add(connection.personA);
                }

                AgentComp.Target = otherPeople[Mathf.FloorToInt(Random.value * otherPeople.Count)];
            }
            phase++;
        }
        else if(phase==2)
        { 

        Agent.transform.position = Vector2.Lerp(agentStart, AgentComp.Target.transform.position, camSwoosh);
            agentCam.transform.position = Agent.transform.position;
            agentCam.transform.position = new Vector3(agentCam.transform.position.x, agentCam.transform.position.y, -10);


            camSwoosh += camSwooshSpeed * Time.deltaTime;

            if (camSwoosh >= .9f)
            {
                camSwoosh = 0;
                phase++;
                amDone = true;
            }

        }
        //move cam to global view
        //done!
    }

    public void RecieveCameraControl(Camera cam)
    {
        agentCam = cam;
        startCam = agentCam.transform.position;
        startCamScale = agentCam.orthographicSize;
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
