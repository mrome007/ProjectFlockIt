using UnityEngine;
using System.Collections;
using System;

public static class TestIt
{
    public static void Assert(bool condition, string message)
    {
        if(!condition)
        {
            Debug.LogError(message);
            throw new Exception();
        }
    }
}
