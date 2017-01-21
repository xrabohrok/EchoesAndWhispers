using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(ClickScript))]
public class PlayerPhase : MonoBehaviour, TurnPhase
{

    public int actions = 2;

    private int actionsLeft = 2;
    private ClickScript clickControl;

    private Camera camera;

    private Person draggedThing = null;

    // Use this for initialization
	void Start ()
	{
	    clickControl = GetComponent<ClickScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoPhase()
    {
        // mouse Control
        var clickHover = clickControl.getAndClearClicked();

        if (clickHover.Count > 0)
        {
            foreach (var thing in clickHover)
            {
                var personality = thing.GetComponent<Person>();
                if (personality != null && (Input.GetMouseButtonDown(0)))
                {
                    //the only legit thing right now is to click/drag
                    draggedThing = personality;
                }
            }

        }

        if (draggedThing != null)
        {
            draggedThing.move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if (Input.GetMouseButtonUp(0))
        {
            draggedThing = null;
        }
        //process actions
    }

    public void RecieveCameraControl(Camera cam)
    {
        camera = cam;
    }

    public bool amIDone()
    {
        var isDone = actionsLeft <= 0;
        if (isDone)
        {
            Cursor.visible = false;
        }
        return isDone;
    }

    public void turnStart()
    {
        actionsLeft = actions;
        Cursor.visible = true;
    }
}
