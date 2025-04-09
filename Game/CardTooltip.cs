using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Game.Cards;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game
{
    public class CardTooltip : Entity
    {
        public CardTooltip()
        {
            EntityLayerManager.AddEntity(this, 2);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Render()
        {
            if (InteractionManager.instance.hoveredCard != null && !Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                Card hoveredCard = InteractionManager.instance.hoveredCard;
                var screen = Coordinates.WorldToScreen((int)hoveredCard.position.x, (int)hoveredCard.position.y);
                float scale = 1f;

                float width = hoveredCard.cardArt.Width * scale;
                float height = hoveredCard.cardArt.Height * scale;

                int x = screen.x - (int)(width / 2);
                int y = screen.y - (int)(height / 2);

                string pastText = $"Past: {hoveredCard.pastEffect.tooltip}";
                string presentText = $"Present: {hoveredCard.presentEffect.tooltip}";
                string futureText = $"Future: {hoveredCard.futureEffect.tooltip}";

                int maxLength = new[] { pastText.Length, presentText.Length, futureText.Length }.Max();
                int maxSize = maxLength * 12;

                Raylib.DrawRectangle((int)(x - (maxSize / 2)), (y - 200), maxSize, (int)height / 2, Color.White); //CARD TOOLTIP
                Raylib.DrawText("Past: " + hoveredCard.pastEffect.tooltip, x - (maxSize / 2), (int)(y - 200), 24, Color.Purple);
                Raylib.DrawText("Present: " + hoveredCard.presentEffect.tooltip, x - (maxSize / 2), (y - 200 + 20), 24, Color.SkyBlue);
                Raylib.DrawText("Future: " + hoveredCard.futureEffect.tooltip, x - (maxSize / 2), (y - 200 + 40), 24, Color.Red);
                
            }
        }
    }
}
