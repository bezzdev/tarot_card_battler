using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarot_card_battler.Game.Stats
{
    public class PlayerStats
    {
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
    }
}
