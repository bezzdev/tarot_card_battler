using Raylib_cs;

namespace tarot_card_battler.Core.Cards;


public class Card(

) {
    public Texture2D cardArt;
    public required String name; 
    public required String number;

    public required Effect pastEffect;

    public virtual void TriggerPastEffect(){
        pastEffect.triggerEffect();
    } 

    public virtual void TriggerPresentEffect(){
        pastEffect.triggerEffect();
    }

    public virtual void TriggerFutureEffect(){
        pastEffect.triggerEffect();
    }
}