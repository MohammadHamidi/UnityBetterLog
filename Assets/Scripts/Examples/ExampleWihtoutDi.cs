using System.Collections;
using System.Collections.Generic;
using Core.Application.Logging;
using UnityEngine;

public class ExampleWihtoutDi : MonoBehaviour
{
    private IDebugLogger _debugLogger;
    void Start()
    {
        _debugLogger = new DebugLogger();
        _debugLogger.Log("Test");
        _debugLogger.LogWarning("Test");
        _debugLogger.LogError("Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
