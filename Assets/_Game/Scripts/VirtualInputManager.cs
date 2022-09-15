using UnityEngine;

namespace kl
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        private bool moveRight;
        private bool moveLeft;
        private bool jump;
        private bool moveUp;
        private bool moveDown;

        public bool MoveRight { get => moveRight; internal set => moveRight = value; }
        public bool MoveLeft { get => moveLeft; internal set => moveLeft = value; }
        public bool Jump { get => jump; internal set => jump = value; }
        public bool MoveUp { get => moveUp; internal set => moveUp = value; }
        public bool MoveDown { get => moveDown; internal set => moveDown = value; }
    }
}
