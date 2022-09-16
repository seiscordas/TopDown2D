using UnityEngine;

namespace kl
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        private bool moveRight;
        private bool jump;
        private bool moveUp;

        public bool MoveX { get => moveRight; internal set => moveRight = value; }
        public bool MoveY { get => moveUp; internal set => moveUp = value; }
        public bool Jump { get => jump; internal set => jump = value; }
    }
}
