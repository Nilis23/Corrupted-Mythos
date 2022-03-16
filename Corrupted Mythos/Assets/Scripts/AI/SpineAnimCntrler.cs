using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimCntrler : MonoBehaviour
{
    public SkeletonAnimation sAnimation;

    /*Fire animation as necessary
     * 
     * The index of each animation should be as follows:
     * 0: Attack
     * 1: Dead
     * 2: Idle //Placeholder until we can determine a solution for being hit
     * 3: Walk
     * This should be the same for each pre-built enemy using the spine animation toolkit, for those instances where it is not adjustments may be needed
     * 
     */
    public void DoSpineAnim(int indx, string name, bool loop = false)
    {
        sAnimation.AnimationState.SetAnimation(indx, name, loop);
    }
}
