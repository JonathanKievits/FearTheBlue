using UnityEngine;

public enum OperationSystem{windows, mac}
public enum ControllerType {xbox, playstation, none};

public class Values : MonoBehaviour
{
    private OperationSystem operatingSystem;
    public OperationSystem CurrentOS{get{return operatingSystem;}}

    private ControllerType controllerType;
    public ControllerType CurrentController{get{return controllerType;}}

    private void Awake()
    {
        var os = System.Environment.OSVersion.Platform.ToString().ToLower();
        if (os.Contains("unix") || os.Contains("mac") || os.Contains("apple"))
            operatingSystem = OperationSystem.mac;
        if (os.Contains("win32nt") || os.Contains("win") || os.Contains("microsoft"))
            operatingSystem = OperationSystem.windows;

        var joystick = "";
        for (var i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetJoystickNames()[i] != "")
            {
                joystick = Input.GetJoystickNames()[i].ToLower();
                break;
            }
        }

        if (operatingSystem == OperationSystem.mac)
        {
            if (joystick.Contains("sony"))
                controllerType = ControllerType.playstation;
            else if (joystick.Contains("microsoft"))
                controllerType = ControllerType.xbox;
            else
                controllerType = ControllerType.none;
        }

        if (operatingSystem == OperationSystem.windows)
        {
            if (joystick.Contains("wireless controller") || joystick.Contains("sony"))
                controllerType = ControllerType.playstation;
            else if (joystick.Contains("xbox"))
                controllerType = ControllerType.xbox;
            else
                controllerType = ControllerType.none;
        }

        Controller.setController(controllerType, operatingSystem);
    }

    private void Update()
    {/*
        if (Input.GetButtonDown(Controller.Cross))
            print("go");*/
    }
}
