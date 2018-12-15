
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class MyDoorClick : MonoBehaviour, IInputClickHandler
{
    Animator m_Animator;
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (m_Animator != null)
        {
            bool _state = m_Animator.GetBool("character_nearby");
            m_Animator.SetBool("character_nearby", !_state);
        }

        eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
    }
}
