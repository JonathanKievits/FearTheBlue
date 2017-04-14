using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckController : MonoBehaviour
{
    private void Awake()
    {
        var joysticks = Input.GetJoystickNames()[0].ToLower();
        var os = System.Environment.OSVersion.Platform.ToString().ToLower();
        print(joysticks);
        if (os == "unix")
        {
            if (joysticks.Contains("sony"))
            {
                Controller.setController(ControllerType.playstation, Os.mac);
                return;
            }

            if (joysticks.Contains("xbox"))
            {
                Controller.setController(ControllerType.xbox, Os.mac);
                return;
            }
        }

        if (os == "win32nt")
        {
            if (joysticks.Contains("wireless controller"))
            {
                Controller.setController(ControllerType.playstation, Os.windows);
                return;
            }

            if (joysticks.Contains("xbox"))
            {
                Controller.setController(ControllerType.xbox, Os.windows);
                return;
            }
        }
    }
}

