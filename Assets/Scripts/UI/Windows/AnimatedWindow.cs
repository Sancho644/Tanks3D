using Model;
using UnityEngine;

namespace UI.Windows
{
    public class AnimatedWindow : MonoBehaviour
    {
        private Animator _animator;
        private readonly int Show = Animator.StringToHash("Show");
        private readonly int Hide = Animator.StringToHash("Hide");

        protected GameSession _session;

        protected virtual void Start()
        {
            _session = GameSession.Instance;
            _animator = GetComponent<Animator>();

            _animator.SetTrigger(Show);
        }

        public void Close()
        {
            _animator.SetTrigger(Hide);
        }

        protected virtual void OnCloseAnimationComplete()
        {
            Destroy(gameObject);
        }
    }
}