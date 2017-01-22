using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float speed = 4.0F;
    private Vector3 dragOrigin;
    
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
        
        coordinates.position = coordinates.position + new Vector3(20.0f, 0.0f, 0.0f);
       
        Camera.main.transform.position = Vector3.Lerp(transform.position, coordinates.transform.position, speed * Time.deltaTime);
    }

    public void showNetwork()
    {
        
        Vector3 center = new Vector3();
        Camera.main.ScreenToWorldPoint(center);
    }

    public void cameraDrag()
    {

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

        Camera.main.transform.LookAt(input);

    }

    public void focusDual(Transform one, Transform two)
    {
        //TODO: Implement zooming on two targets


    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }
}