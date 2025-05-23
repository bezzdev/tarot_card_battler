﻿using Raylib_cs;
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
                var screen = Coordinates.WorldToScreen((int)hoveredCard.owner.field.position.x, (int)hoveredCard.owner.field.position.y);
                int x = screen.x;
                int y = screen.y;

                int xSpacing = 170;
                
                int height = hoveredCard.cardArt.Height;
                int width = hoveredCard.cardArt.Width;

                int effectWidth = width;
                int effectHeight = height;

                int widthPerLine = effectWidth;

                Color textColor = Color.White;

                Color effectNonActiveColor = new Color(1f, 1f, 1f, 0.1f);
                Color effectActiveColor = new Color(1f, 1f, 1f, 0.2f);

                int effectActiveSlot = hoveredCard.slotIndex;
                int textMargin = 4;

                bool inHand = effectActiveSlot == -1;
                bool inPast = effectActiveSlot == 0;
                bool inPresent = effectActiveSlot == 1;
                bool inFuture = effectActiveSlot == 2;

                bool showPast = inHand || inPast || Raylib.IsKeyDown(KeyboardKey.LeftShift);
                bool showPresent = inHand || inPresent || Raylib.IsKeyDown(KeyboardKey.LeftShift);
                bool showFuture = inHand || inFuture || Raylib.IsKeyDown(KeyboardKey.LeftShift);

                if (showPast)
                {
                    // past
                    int ex = x + (-xSpacing + -effectWidth/2);
                    int ey = y + (-effectHeight/2);
                    Raylib.DrawRectangle(ex, ey, effectWidth, effectHeight, Color.Black);
                    Raylib.DrawTextureEx(hoveredCard.cardArt, new System.Numerics.Vector2(ex, ey), 0, 1f, effectActiveSlot == 0 ? effectActiveColor : effectNonActiveColor);

                    string text = hoveredCard.pastEffect.tooltip;
                    TextRendering.RenderLines(text, 20, textColor, ex + textMargin, ey + textMargin, widthPerLine - textMargin - textMargin);
                }

                if (showPresent)
                {
                    // present
                    int ex = x + (-effectWidth / 2);
                    int ey = y + (-effectHeight / 2);
                    Raylib.DrawRectangle(ex, ey, effectWidth, effectHeight, Color.Black);
                    Raylib.DrawTextureEx(hoveredCard.cardArt, new System.Numerics.Vector2(ex, ey), 0, 1f, effectActiveSlot == 1 ? effectActiveColor : effectNonActiveColor);

                    string text = hoveredCard.presentEffect.tooltip;
                    TextRendering.RenderLines(text, 20, textColor, ex + textMargin, ey + textMargin, widthPerLine - textMargin - textMargin);
                }

                if (showFuture)
                {
                    // future
                    int ex = x + (+xSpacing + -effectWidth / 2);
                    int ey = y + (-effectHeight / 2);
                    Raylib.DrawRectangle(ex, ey, effectWidth, effectHeight, Color.Black);
                    Raylib.DrawTextureEx(hoveredCard.cardArt, new System.Numerics.Vector2(ex, ey), 0, 1f, effectActiveSlot == 2 ? effectActiveColor : effectNonActiveColor);

                    string text = hoveredCard.futureEffect.tooltip;
                    TextRendering.RenderLines(text, 20, textColor, ex + textMargin, ey + textMargin, widthPerLine - textMargin - textMargin);
                }
            }
        }
    }
}
