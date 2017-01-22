using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float speed = 4.0F;
    private Vector3 dragOrigin;
    //TODO:Find the center that needs to be focused on 
    // public Vector2 center = ();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void focusPerson(Transform coordinates)
    {
        //TODO:Move view to person, center left person
        coordinates.position = coordinates.position + new Vector3(20.0f, 0.0f, 0.0f);
       // Camera.main.transform.LookAt(coordinates);
        //TODO:Set zoom
        Camera.main.transform.position = Vector3.Lerp(transform.position, coordinates.transform.position, speed * Time.deltaTime);
    }

    public void showNetwork()
    {
        //TODO: Zoom out, character on left investigators on right

        Vector3 center = new Vector3();
        Camera.main.ScreenToWorldPoint(center);
       // Camera.main.orthographicSize = fullMapOut;
    }

    public void cameraDrag()
    {
        //TODO: Pan and move the camera

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * speed, 0, pos.y * speed);

        transform.Translate(move, Space.World);
    }

    public void cameraZoom(Transform input)
    {
        //TODO: Take in object then zoom in or out
        Camera.main.transform.LookAt(input);


    }

    public void focusDual(Transform one, Transform two)
    {
        //TODO: Implement zooming on two targets


    }

    public void OnDrawGizmos()
    {
        //The center
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }
}