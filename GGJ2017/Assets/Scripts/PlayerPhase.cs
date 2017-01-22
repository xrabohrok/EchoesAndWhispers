using UnityEngine;

[RequireComponent(typeof(ClickScript))]
public class PlayerPhase : MonoBehaviour, TurnPhase
{

    public int actions = 2;
    public float zoomMultiplier = .6f;
    public float maxZoom = 600;
    public float minZoom = 200;

    private int actionsLeft = 2;
    private ClickScript clickControl;

    private Camera camera;

    private Person draggedThing = null;
    private float targetZoom;


    // Use this for initialization
	void Start ()
	{
	    clickControl = GetComponent<ClickScript>();
	    targetZoom = .5f;
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

        targetZoom += Input.GetAxis("Mouse ScrollWheel") * zoomMultiplier;
        if (targetZoom <= 0)
            targetZoom = 0;
        else if (targetZoom >= 100)
            targetZoom = 100;

        var progress = targetZoom / 100;

        camera.orthographicSize = Mathf.Lerp(minZoom, maxZoom, progress);

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
