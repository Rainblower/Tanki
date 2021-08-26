using UnityEngine;
using Views.Tank;

namespace Controllers
{
    public class DamageController
    {
        public bool DoDamage(Entity entity, float projectileDamage)
        {
            entity.Health -= projectileDamage * (1 - entity.Armor / 100);
            
            Debug.Log("Entity: " + entity.gameObject.name + $" take {projectileDamage} damage -" + $" Health: {entity.Health}");
            
            if (entity.Health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}