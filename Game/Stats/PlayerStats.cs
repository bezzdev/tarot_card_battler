using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using tarot_card_battler.Core;
using tarot_card_battler.Util;

namespace tarot_card_battler.Game.Stats
{
    public class PlayerStats
    {
        public Coord position = new Coord(0, 0);

        public int health = 0;
        public int maxHealth = 20;
        public int level = 0;
        public int drawPerTurn = 3;
        public int shield = 0;
        public int strength = 0;
        public int weakness = 0;
        public int gold = 0;
        public bool deathCountdown = false;
        public bool renderStats = false;
        public int countdown = 2;

        public void TakeDamage(int damage)
        {
            if (damage < 0) return;
            if (shield > 0)
            {
                shield -= damage;

                if (shield < 0)
                {
                    damage = -shield;

                    shield = 0;
                }
                else
                {
                    damage = 0;
                }
            }

            health -= damage;

            if (health < 0)
            {
                health = 0;
            }
        }

        public void Heal(int heal)
        {
            health += heal;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public void Shield(int shield)
        {
            this.shield += shield;
        }

        public void AddStrength(int strength)
        {
            this.strength += strength;
        }

        public void AddWeakness(int weakness)
        {
            this.weakness += weakness;
        }

        public void AddGold(int gold)
        {
            this.gold += gold;
        }

        public void RemoveGold(int gold)
        {
            this.gold -= gold;
        }

        public void Render()
        {
            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);
            int spacing = 60;
            int x = screen.x;
            int y = screen.y;

            y -= spacing;
            Vector2 pos = new Vector2(x, y);
            if (deathCountdown == true)
            {
                Raylib.DrawTextureEx(References.ShieldIcon, pos, 0f, 1f, Color.White); //todo change
                Raylib.DrawText(countdown.ToString(), x + 70, y + 5, 48, Color.White);
            }
            if (renderStats)
            {
                y += spacing;
                pos = new Vector2(x, y);
                Raylib.DrawTextureEx(References.ShieldIcon, pos, 0f, 1f, Color.White);
                Raylib.DrawText(strength.ToString(), x + 70, y + 5, 48, Color.White);

                y += spacing;
                pos = new Vector2(x, y);
                Raylib.DrawTextureEx(References.StrengthIcon, pos, 0f, 1f, Color.White);
                Raylib.DrawText(strength.ToString(), x + 70, y + 5, 48, Color.White);

                y += spacing;
                pos = new Vector2(x, y);
                Raylib.DrawTextureEx(References.WeaknessIcon, pos, 0f, 1f, Color.White);
                Raylib.DrawText(weakness.ToString(), x + 70, y + 5, 48, Color.White);

                y += spacing;
                pos = new Vector2(x, y);
                Raylib.DrawTextureEx(References.GoldIcon, pos, 0f, 1f, Color.White);
                Raylib.DrawText(gold.ToString(), x + 70, y + 5, 48, Color.White);
            }
        }
    }
}
