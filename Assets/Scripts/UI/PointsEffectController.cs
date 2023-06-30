using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PointsEffectController : MonoBehaviour
    {
        [SerializeField] private Text _points;

        public void SetPoints(int value)
        {
            _points.text = value.ToString();
        }
    }
}