using UnityEngine;
public enum ControllerType { xbox, playstation };
public enum Os { windows, mac };
public class Controller
{
    private static string triangle = "";
    public static string Triangle { get { return triangle; } }
    private static string square = "";
    private static string Square { get { return square; } }
    private static string cross = "";
    public static string Cross { get { return cross; } }
    private static string circle = "";
    public static string Circle { get { return circle; } }
    private static string leftStickX = "";
    public static string LeftStickX { get { return leftStickX; } }
    private static string leftStickY = "";
    public static string LeftStickY { get { return leftStickY; } }
    private static string rightStickX = "";
    public static string RightStickX { get { return rightStickX; } }
    private static string rightStickY = "";
    public static string RightStickY { get { return rightStickY; } }
    private static string l1 = "";
    public static string L1 { get { return l1; } }
    private static string r1 = "";
    public static string R1 { get { return r1; } }
    private static string l2 = "";
    public static string L2 { get { return l2; } }
    private static string r2 = "";
    public static string R2 { get { return r2; } }
    private static string leftThumb = "";
    public static string LeftThumb { get { return leftThumb; } }
    private static string rightThumb = "";
    public static string RightThumb { get { return rightThumb; } }
    private static string dpadX = "";
    public static string DpadX { get { return dpadX; } }
    private static string dpadY = "";
    public static string DpadY { get { return dpadY; } }

    public static void setController(ControllerType controller, Os os)
    {
        if (triangle != "")
        {
            return;
        }

        if (os == Os.mac)
        {
            if (controller == ControllerType.playstation)
            {
                setPlaystation();
                return;
            }

            if (controller == ControllerType.xbox)
            {
                triangle = "xboxYMac";
                square = "xboxXMac";
                cross = "xboxAMac";
                circle = "xboxBMac";
                leftStickX = "xboxLeftStickXMac";
                leftStickY = "xboxLeftStickYMac";
                rightStickX = "xboxRightStickXMac";
                rightStickY = "xboxRightStickYMac";
                l1 = "xboxLBMac";
                r1 = "xboxRBMac";
                l2 = "xboxLTMac";
                r2 = "xboxRTMac";
                leftThumb = "xboxLeftThumbMac";
                rightThumb = "xboxRightThumbMac";
                return;
            }
        }

        if (os == Os.windows)
        {
            if (controller == ControllerType.playstation)
            {
                setPlaystation();
                return;
            }

            if (controller == ControllerType.xbox)
            {
                triangle = "xboxYWin";
                square = "xboxXWin";
                cross = "xboxAWin";
                circle = "xboxBWin";
                leftStickX = "xboxLeftStickXWin";
                leftStickY = "xboxLeftStickYWin";
                rightStickX = "xboxRightStickXWin";
                rightStickY = "xboxRightStickYWin";
                l1 = "xboxLBWin";
                r1 = "xboxRBWin";
                l2 = "xboxLTWin";
                r2 = "xboxRTWin";
                leftThumb = "xboxLeftThumbWin";
                rightThumb = "xboxRightThumbWin";
                dpadX = "xboxDpadXWin";
                dpadY = "xboxDpadYWin";
                return;
            }
        }
    }

    private static void setPlaystation()
    {
        triangle = "psTriangle";
        square = "psSquare";
        cross = "psCross";
        circle = "psCircle";
        leftStickX = "psLeftStickX";
        leftStickY = "psLeftStickY";
        rightStickX = "psRightStickX";
        rightStickY = "psRightStickY";
        l1 = "psL1";
        r1 = "psR1";
        l2 = "psL2";
        r2 = "psR2";
        leftThumb = "psLeftThumb";
        rightThumb = "psRightThumb";
        dpadX = "psDpadX";
        dpadY = "psDpadY";
    }
}
