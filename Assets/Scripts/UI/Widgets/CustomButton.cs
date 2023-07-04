using UnityEngine.UI;

namespace UI.Widgets
{
    public class CustomButton : Button
    {
        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            base.DoStateTransition(state, instant);

            if (!gameObject.TryGetComponent<ButtonStateText>(out ButtonStateText textState)) return;

            textState.SetActiveNormal(state != SelectionState.Pressed);
            textState.SetActivePressed(state == SelectionState.Pressed);

            if (interactable) return;
            
            textState.SetActivePressed(true);
            textState.SetActiveNormal(false);
        }
    }
}