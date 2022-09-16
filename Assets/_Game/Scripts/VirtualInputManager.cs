using UnityEngine;

namespace kl
{
    //public class VirtualInputManager : MonoBehaviour
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        private bool moveRight;
        private bool jump;
        private bool moveUp;
        private bool attack;

        public bool MoveX { get => moveRight; internal set => moveRight = value; }
        public bool MoveY { get => moveUp; internal set => moveUp = value; }
        public bool Jump { get => jump; internal set => jump = value; }
        public bool Attack { get => attack; set => attack = value; }
    }
}
