
using UnityEngine;
using System;
/// <summary>
/// 封装Debug Bool IsLog控制
/// </summary>
public class Debuger
{
    /// <summary>
    /// 打印开关
    /// </summary>
    public static bool IsLog = true;
    public static Action<string> onLog;
    public static void Log(object message, string color = "")
    {
        if (!IsLog) return;
        if (message == null) { Debug.Log(message); return; }
        var msg = message.ToString();
        msg = msg.Length > 1500 ? string.Format("{0}后面还有更多就不显示了。。。。", msg.Substring(0, 1500)) : msg;
        if (color != "")
            Debug.Log(string.Format("<color=#{0}>{1}</color>", color, msg));
        else
            Debug.Log(msg);
        if (onLog != null) onLog(msg);

    }

    public static void LogFormat(string format, params object[] values)
    {
        if (!IsLog) return;
        Log(string.Format(format, values));
    }

    public static void LogOk(object message)
    {
        if (!IsLog) return;
        Log(message, "00ff00");
    }

    public static void LogError(object message)
    {
        if (!IsLog) return;
        Log(message, "ff0000");
    }

    public static void LogWarning(object message, string color = "00ffff")
    {
        if (!IsLog) return;

        if (message == null) { Debug.Log(message); return; }
        var msg = message.ToString();
        msg = msg.Length > 1500 ? string.Format("{0}后面还有更多就不显示了。。。。", msg.Substring(0, 1500)) : msg;
        if (color != "")
            Debug.LogWarning(string.Format("<color=#{0}>{1}</color>", color, msg));
        else
            Debug.LogWarning(msg);
        if (onLog != null) onLog(msg);
    }

    public static void LogException(string message, string color = "ff00000")
    {
        if (!IsLog) return;
        if (message == null) { Debug.Log(message); return; }
        var msg = message.ToString();
        msg = msg.Length > 1500 ? string.Format("{0}后面还有更多就不显示了。。。。", msg.Substring(0, 1500)) : msg;
        if (color != "")
            Debug.LogException(new System.Exception(string.Format("<color=#{0}>{1}</color>", color, msg)));
        else
            Debug.LogException(new System.Exception(msg));
        if (onLog != null) onLog(msg);
    }
}

