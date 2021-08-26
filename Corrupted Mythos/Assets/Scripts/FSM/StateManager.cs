using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    List<State> ValidStates;
    [SerializeField]
    State startState;

    State currentState;

    private void Start()
    {
        foreach(State state in ValidStates)
        {
            state.executingManager = this;
        }
    }
    void Update()
    {
        if(currentState == null)
        {
            currentState = startState;
        }
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState(); //If the current state is not null, it will run the state's logic and then grab the returned state

        if(nextState != null)
        {
            toNextState(nextState); //This then sets current state to next state
        }
    }

    private void toNextState(State newState)
    {
        if (ValidStates.Contains(newState))
        {
            currentState = newState;
        }
    }
}
