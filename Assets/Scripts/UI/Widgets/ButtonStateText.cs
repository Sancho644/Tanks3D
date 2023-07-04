using UnityEngine;

namespace UI.Widgets
{
    public class ButtonStateText : MonoBehaviour
    {
        [SerializeField] private GameObject _normal;
        [SerializeField] private GameObject _pressed;

        public void SetActiveNormal(bool value)
        {
            _normal.SetActive(value);
        }
        
        public void SetActivePressed(bool value)
        {
            _pressed.SetActive(value);
        }
    }
}