using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollow : MonoBehaviour
{
    float smooth = 5.0f;
    float tiltAngle = 30.0f;
    public int score;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GameObject.Find("Text");
    }

    // Update is called once per frame


    void Update()
    {
        float halfW = Screen.width/2 , halfH = Screen.height/2 ;

        transform.position = new Vector3(
    (Input.mousePosition.x - halfW) / halfW *2,
    (Input.mousePosition.y - halfH) / halfH *2, transform.position.z);
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle*2;
        float tiltAroundX =  Input.GetAxis("Mouse Y") * tiltAngle * -2;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        text.GetComponent<Text>().text = "Score: " + score;
    }
    private void OnCollisionEnter(Collision collision)
    {
        score++;
    }


}
