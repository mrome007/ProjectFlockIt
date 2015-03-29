using UnityEngine;
using System.Collections;
using System;

public static class TestIt
{
    public static void Assert(bool condition, string message)
    {
        if(!condition)
        {
            Debug.LogWarning(message);
            throw new Exception();
        }
    }
}
