using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour {

    private bool domovement = true;

    public float panBorderTickness=10f;
    public float panSpeed = 30f;
    public float scrollspeed = 5f;
    public float miny = 10f;
    public float maxy = 80f;
	// Update is called once per frame
	void Update () {

        if(Gamemanager.Gameisover)
        {
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Q))
            {
            domovement = !domovement;
        }


        if (!domovement)
            return;

		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderTickness)
        {
            transform.Translate(Vector3.forward *panSpeed *Time.deltaTime,Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderTickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderTickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderTickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll *1000* scrollspeed *Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, miny, maxy);
        transform.position = pos;

    }
}
