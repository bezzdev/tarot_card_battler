namespace tarot_card_battler.Core.Statemachines
{
    public class StateMachine
    {
        public State current_state;

        public StateMachine(State state)
        {
            state.stateMachine = this;
            SetState(state);
        }
        public void Update()
        {
            if (current_state != null)
            {
                current_state.Update();
            }
        }
        public void EarlyRender()
        {
            if (current_state != null)
            {
                current_state.EarlyRender();
            }
        }

        public void Render()
        {
            if (current_state != null)
            {
                current_state.Render();
            }
        }

        public void SetState(State state)
        {
            if (current_state != null)
            {
                current_state.OnLeave();
            }

            current_state = state;

            if (current_state != null)
            {
                current_state.stateMachine = this;
                current_state.OnEnter();
            }
        }
    }
}
