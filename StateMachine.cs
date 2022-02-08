using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public StateMachine(BaseState baseState, MonoBehaviour mono)
    {
        monoBehaviour = mono;
        currentState = baseState;
    }
    private MonoBehaviour monoBehaviour;
    private List<BaseState> states = new List<BaseState>();
    private List<Transition> transitions = new List<Transition>();
    private BaseState currentState;

    public void AddState(BaseState addState) => states.Add(addState);
    public void addTransition(Transition addTransition) => transitions.Add(addTransition);

    public void Start() => currentState.StartState(monoBehaviour);
    public void Update()
    {
        currentState.UpdateState();
        CheckTransition();
    }

    void CheckTransition()
    {
        foreach(Transition transition in transitions)
        {
            if(transition._from != null) //Test the condition to see if it has an origin baseState
            {
                if (transition._from == currentState)//Transition from a state
                {
                    if (transition._condition())//if the conditions are met goes to the next state
                    {
                        currentState = transition._to; 
                        Start();
                    }
                }
            }
            else //transition from any state
            {
                if (transition._condition())//if the conditions are met goes to the next state
                {
                    currentState = transition._to; 
                    Start();
                }
            }
        }
    }
}
