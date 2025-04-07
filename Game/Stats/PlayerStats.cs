using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public void TakeDamage(int damage)
        {
            if (shield > 0)
            {
                shield -= (damage + strength - weakness);

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

            health -= (damage + strength - weakness);

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

        public void AddStrength(){
            this.strength += 1;
        }

        public void AddWeakness(){
            this.weakness += 1;
        }

        public void Render(){
            var screen = Coordinates.WorldToScreen((int)position.x, (int)position.y);
            int spacing = 60;
            int x = screen.x;
            int y = screen.y;
            Vector2 pos = new Vector2(x, y);
            Raylib.DrawTextureEx(References.Shield, pos, 0f, 0.5f, Color.White);
            Raylib.DrawText(shield.ToString(), x + 70, y + 5, 48, Color.White);

            y += spacing;
            pos = new Vector2(x, y);
            Raylib.DrawTextureEx(References.Shield, pos, 0f, 0.5f, Color.Orange);
            Raylib.DrawText(strength.ToString(), x + 70, y + 5, 48, Color.Orange);

            y += spacing;
            pos = new Vector2(x, y);
            Raylib.DrawTextureEx(References.Shield, pos, 0f, 0.5f, Color.Red);
            Raylib.DrawText(weakness.ToString(), x + 70, y + 5, 48, Color.Red);

            y += spacing;
            pos = new Vector2(x, y);
            Raylib.DrawTextureEx(References.Shield, pos, 0f, 0.5f, Color.Blue);
            Raylib.DrawText(drawPerTurn.ToString(), x + 70, y + 5, 48, Color.Blue);
        }
    }
}
