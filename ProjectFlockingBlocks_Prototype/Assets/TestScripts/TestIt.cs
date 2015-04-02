using UnityEngine;
using System.Collections;
using System;

public static class TestIt
{
    public static void Assert(bool condition)
    {
        if(!condition)
        {
            throw new Exception();
        }
    }
}
