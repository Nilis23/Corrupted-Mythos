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
    public bool attack;

    State currentState;
    public int collisions = 0;
    public float stagr = 0;

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
            currentState.StartState(this);
        }

        if (startState.GetType() == typeof(idleState))
        {
            idle = true;
        }
    }
    void Update()
    {
        if (stagr <= 0)
        {
            RunStateMachine();

            if (timer > 0)
            {
                timer--;
            }
        }
        else
        {
            //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 73, 73);
            stagr -= Time.deltaTime;

            if(stagr <= 0)
            {
                this.transform.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
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
            nav.target = pointTwo.transform.position;
            point = 1;
        }
        else if(point == 1)
        {
            nav.target = pointOne.transform.position;
            point = 0;
        }
    }
    public void SetTarget(GameObject targ)
    {
        nav.target = targ.transform.position;
    }

    public State GetState()
    {
        return currentState;
    }

    public void knockback()
    {
        float dir = player.transform.position.x - transform.position.x;
        if(dir > 0)
        {
            Vector2 newPos = new Vector2(this.transform.position.x - 0.75f, this.transform.position.y);
            StartCoroutine(moveBack(newPos));
        }
        else if(dir < 0)
        {
            //Knockback to the left
            Vector2 newPos = new Vector2(this.transform.position.x + 0.75f, this.transform.position.y);
            StartCoroutine(moveBack(newPos));
        }
    }
    public void KnockUp()
    {
        StartCoroutine(knockUp());
    }

    IEnumerator moveBack(Vector2 targPos)
    {
        Vector2 orgPos = transform.position;
        float t = 0;
        while(t <= 0.25f)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(orgPos, targPos, t/0.25f);

            yield return null;
        }
    }

    IEnumerator knockUp()
    {
        Vector2 upPos = new Vector2(transform.position.x, transform.position.y + 4);
        Vector2 orgPos = transform.position;
        float t = 0;

        while(t <= 0.3f)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(orgPos, upPos, t / 0.3f);

            yield return null;
        }
        while(t <= 0.5f)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(upPos, orgPos, (t - 0.3f) / 0.25f);

            yield return null;
        }
    }

    public void setStgr(float val, bool clr = false)
    {
        stagr = val;

        if (clr)
        {
            this.transform.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
}
