using UnityEngine;

public abstract class BaseState
{
    private MonoBehaviour monoBehaviour;
    public abstract void StartState(MonoBehaviour mono);
    public abstract void UpdateState();
}
