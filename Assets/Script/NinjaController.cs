using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    NinjaState currentState;
    GUIStyle _labelStyle; // style utk rich text IMGUI
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }
    void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysic();
        }
    }
    public void ChangeState(NinjaState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }
    protected virtual NinjaState GetInitialState()
    {
        return null;
    }
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();
    }
}
