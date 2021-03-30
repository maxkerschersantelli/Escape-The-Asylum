using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInitializer : MonoBehaviour
{
    CustomJoystick joystick;
    public bool left;

    // Start is called before the first frame update
    void Start()
    {
        joystick = this.GetComponent<CustomJoystick>();
        if (left)
        {
            ModeChanged(PlayerPrefs.GetInt("Left Stick Mode"));
        }
        else
        {
            ModeChanged(PlayerPrefs.GetInt("Right Stick Mode"));
        }
    }

    public void ModeChanged(int index)
    {
        switch (index)
        {
            case 0:
                joystick.SetMode(CustomJoystickType.Fixed);
                break;
            case 1:
                joystick.SetMode(CustomJoystickType.Floating);
                break;
            case 2:
                joystick.SetMode(CustomJoystickType.Dynamic);
                break;
            default:
                break;
        }
    }
}
