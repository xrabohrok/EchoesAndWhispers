using UnityEngine;

[RequireComponent(typeof(ClickScript))]
public class PlayerPhase : MonoBehaviour, TurnPhase
{

    public int actions = 2;
    public float zoomMultiplier = .6f;
    public float maxZoom = 600;
    public float minZoom = 200;

    public float maxPan_left = -400;
    public float maxPan_right = 1200;
    public float maxPan_up = 800;
    public float maxPan_down = -200;

    private int actionsLeft = 2;
    private ClickScript clickControl;

    private Camera camera;

    private Person draggedThing = null;
    private float targetZoom;

    private bool panning = false;
    private Vector2 mouseanchor;
    private Vector2 mouseWorldLast;

    private float zDepth = -100;


    // Use this for initialization
	void Start ()
	{
	    clickControl = GetComponent<ClickScript>();
	    targetZoom = .5f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (zDepth < -99)
	    {
	        zDepth = camera.transform.position.z;
	    }
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
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //pan cam
                var mouseWorldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
                mouseanchor = mouseWorldPoint;
                panning = true;
            }
        }

        if (panning)
        {
            var currentMouseCam = camera.ScreenToWorldPoint(Input.mousePosition);
            currentMouseCam = new Vector3(currentMouseCam.x, currentMouseCam.y, 0);
            camera.transform.position -= currentMouseCam - new Vector3( mouseWorldLast.x, mouseWorldLast.y, 0);

            if(camera.transform.position.x > maxPan_right)
                camera.transform.position = new Vector3(maxPan_right, camera.transform.position.y, zDepth);
            if (camera.transform.position.x < maxPan_left)
                camera.transform.position = new Vector3(maxPan_left, camera.transform.position.y, zDepth);
            if (camera.transform.position.y < maxPan_down)
                camera.transform.position = new Vector3(camera.transform.position.x, maxPan_down, zDepth);
            if (camera.transform.position.y > maxPan_up)
                camera.transform.position = new Vector3(camera.transform.position.x, maxPan_up, zDepth);


        }

        if (panning && Input.GetMouseButtonUp(0))
        {
            panning = false;
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
        mouseWorldLast = camera.ScreenToWorldPoint(Input.mousePosition);
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
