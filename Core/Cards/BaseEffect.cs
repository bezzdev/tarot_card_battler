namespace tarot_card_battler.Core.Cards;

public class Effect {

    public virtual void triggerEffect(){}

}

public class DamageEffect: Effect {
    public override void triggerEffect() //param: playerBoard, param: opponentBoard
    {
        
    }
}