<<<<<<< HEAD
﻿using UnityEngine;

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
=======
﻿using UnityEngine;

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

    public GameObject targetReticule;
    public GameObject sourceReticule;

    private int actionsLeft = 2;
    private ClickScript clickControl;

    private Camera camera;

    private Person draggedThing = null;
    private float targetZoom;

    private bool panning = false;
    private Vector2 mouseanchor;
    private Vector2 mouseWorldLast;

    private float zDepth = -100;

    private bool rumorMode;
    private bool rumorModeLocked;
    private GameObject rumorSource;
    private GameObject rumorTarget;
    private int rumorModePhase = 0;
    private GameObject rumorIndicatorSource;
    private GameObject rumorIndicatorTarget;
    public GameObject LinkIndicationPrefab;
    private GameObject currentLinkIndication;
    private TurnMaster keeper;


    // Use this for initialization
	void Start ()
	{
	    clickControl = GetComponent<ClickScript>();
	    targetZoom = .5f;
	    rumorMode = false;
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
                    processRumorMouseInput(personality);

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
            camera.transform.position -= currentMouseCam - new Vector3(mouseWorldLast.x, mouseWorldLast.y, 0);

            if (camera.transform.position.x > maxPan_right)
>>>>>>> da39f2a5fff1b99357463fee69bc59aab8a1ce2a
                camera.transform.position = new Vector3(maxPan_right, camera.transform.position.y, zDepth);
            if (camera.transform.position.x < maxPan_left)
                camera.transform.position = new Vector3(maxPan_left, camera.transform.position.y, zDepth);
            if (camera.transform.position.y < maxPan_down)
                camera.transform.position = new Vector3(camera.transform.position.x, maxPan_down, zDepth);
            if (camera.transform.position.y > maxPan_up)
                camera.transform.position = new Vector3(camera.transform.position.x, maxPan_up, zDepth);
<<<<<<< HEAD


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
=======


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

        processRumors();



        //process actions
        mouseWorldLast = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void processRumorMouseInput(Person personality)
    {
        if (rumorMode)
        {
            if (rumorSource == null)
            {
                Debug.Log("chose source");
                rumorSource = personality.gameObject;

                currentLinkIndication = Instantiate(LinkIndicationPrefab);
                currentLinkIndication.SetActive(true);
                var temp = currentLinkIndication.GetComponent<Link>();
                temp.recieveTargets(personality);

                rumorModePhase++;
            }
            else if (rumorTarget == null)
            {
                Debug.Log("chose target");
                rumorTarget = personality.gameObject;
                rumorModePhase++;
            }
        }
    }

    private void processRumors()
    {
        if (rumorMode)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (rumorModePhase == 1)
                {
                    rumorIndicatorSource = Instantiate(sourceReticule, rumorSource.transform.position, this.transform.rotation);
                    rumorIndicatorSource.transform.parent = rumorSource.transform;
                }
                if (rumorModePhase == 2)
                {
                    rumorIndicatorTarget = Instantiate(targetReticule, rumorTarget.transform.position, this.transform.rotation);
                    currentLinkIndication.GetComponent<Link>().passToPersonTarget(rumorTarget.GetComponent<Person>());
                    rumorIndicatorTarget.transform.parent = rumorTarget.transform;

                    //start rumor
                    keeper.recieveTurnAction(new TurnAction(0, rumorSource.GetComponent<Person>(), rumorTarget.GetComponent<Person>()));

                    rumorModePhase = 0;
                    rumorMode = false;
                    rumorModeLocked = true;
                }
            }
        }
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

    public void startRumorMode()
    {
        if(!rumorModeLocked)
        {
            rumorMode = true;
            rumorModePhase = 0;
        }
    }

    public void turnStart()
    {
        actionsLeft = actions;
        Cursor.visible = true;
        rumorModeLocked = false;
    }

    public void informOfRealDad(TurnMaster master)
    {
        keeper = master;
    }
}
>>>>>>> da39f2a5fff1b99357463fee69bc59aab8a1ce2a
