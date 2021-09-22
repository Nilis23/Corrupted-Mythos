using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    List<State> ValidStates;
    [SerializeField]
    State startState;
    
    public Seeker seeker;
    public GameObject player;
    public EnemyNavigator nav;

    public GameObject pointOne;
    public GameObject pointTwo;
    public int point = 0;

    public int timer;
    public bool idle;

    State currentState;
    public int collisions = 0;

    private void Start()
    {
        //Find and store the player
        player = GameObject.FindGameObjectWithTag("Player");
        //Grab this agent's seeker
        seeker = this.GetComponent<Seeker>();
        nav = this.GetComponent<EnemyNavigator>();

        if (currentState == null)
        {
            currentState = startState;
        }

        idle = true;
    }
    void Update()
    {
        RunStateMachine();

        if(timer > 0)
        {
            timer--;
        }
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState(this); //If the current state is not null, it will run the state's logic and then grab the returned state

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
            currentState.StartState(this);
        }
    }

    public int getCollisionState()
    {
        return collisions;
    }

    public void SwapTarget()
    {
        if(point == 0)
        {
            nav.target = pointTwo;
            point = 1;
        }
        else if(point == 1)
        {
            nav.target = pointOne;
            point = 0;
        }
    }
    public void SetTarget(GameObject targ)
    {
        nav.target = targ;
    }
}
