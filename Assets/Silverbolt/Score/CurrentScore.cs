using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class CurrentScore : ScriptableObject
{
    public float score;
    private void Awake()
    {
        score = 0;
    }
}
