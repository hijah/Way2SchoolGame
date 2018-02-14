using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    private enum Direction
    {
        Left, Right, Neutral
    }

    private Direction movement = Direction.Neutral;
    public float count = 0;
    public float deadzone = 0.5f;
    public float horizontalSpeed = 0.3f;

    List<Touch> _listOfTouches = new List<Touch>();


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            HandleInput(i);
        }
    }





    void HandleInput(int i)
    {
        switch (Input.GetTouch(i).phase)
        {
            case TouchPhase.Began:
                _listOfTouches.Add(Input.GetTouch(i));
                Debug.Log("<color=red>Finger add</color>" + _listOfTouches.Count);
                break;
            case TouchPhase.Ended:
                _listOfTouches.RemoveAll(touch => touch.fingerId == Input.GetTouch(i).fingerId);
                Debug.Log("<color=red>Finger fjernet</color>" + _listOfTouches.Count);
                break;
            case TouchPhase.Moved:
                if (Vector2.SqrMagnitude(Input.GetTouch(i).deltaPosition) > deadzone)
                {
                    if (Input.GetTouch(i).position.x > _listOfTouches.Find(touch => touch.fingerId == Input.GetTouch(i).fingerId).position.x)
                    {
                        movement = Direction.Right;
                        Debug.Log("<color=red>Bevægelse højre</color>");
                        transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
                    }
                    else
                    {
                        movement = Direction.Left;
                        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
                        Debug.Log("<color=red>Bevægelse venstre</color>");
                    }
                    //movement = Direction.Neutral;
                    //Debug.Log ("<color=red>Bevægelse rgistreret</color>");
                }
                break;
        }
    }
}
