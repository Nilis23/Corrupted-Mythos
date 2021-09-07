using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test Artifact", menuName = "Artifacts/Test Artifact", order = 0)]
public class TestArtifact : Artifact
{
    public override void doAction()
    {
        Debug.Log("Artifact doing a thing");
    }
}
