using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public BaseState _from;
    public BaseState _to;
    public Func<bool> _condition;

    public Transition(BaseState from, BaseState to, Func<bool> condition)
    {
        _from = from;
        _to = to;
        _condition = condition;
    }

    public Transition(BaseState to, Func<bool> condition)
    {
        _to = to;
        _condition = condition;
    }
}
