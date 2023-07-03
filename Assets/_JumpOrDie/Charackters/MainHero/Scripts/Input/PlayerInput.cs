using UnityEngine;

namespace JumpOrDie
{
    public class PlayerInput : MonoBehaviour
    {
        public delegate void EnterData(InputData inputData);
        public event EnterData Inputted;

        private InputData _inputData = new InputData();

        private event EnterData DoubleInputted;

        private void Update()
        {
            float horizontal = Input.GetAxis(ConstantsInput.HORIZONTAL);
            float vertical = Input.GetAxisRaw(ConstantsInput.VERTICAL);
            bool jump = Input.GetButtonDown(ConstantsInput.JUMP);
            bool fire1 = Input.GetButtonDown(ConstantsInput.FIRE1);
            bool fire2 = Input.GetButtonDown(ConstantsInput.FIRE2);
            bool fire3 = Input.GetButtonDown(ConstantsInput.FIRE3);

            _inputData = new InputData
            {
                HorizontalDirection = horizontal,
                VerticalDirection = vertical,
                Jump = jump,
                Fire1 = fire1,
                Fire2 = fire2,
                Fire3 = fire3
            };

            Inputted?.Invoke(_inputData);
        }

        private void OnEnable()
        {
            if (DoubleInputted != null)
            {
                Inputted = DoubleInputted;
            }
        }

        private void OnDisable()
        {
            DoubleInputted = Inputted;
            Inputted = null;
        }
    }
}
