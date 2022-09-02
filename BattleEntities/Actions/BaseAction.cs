using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.Calculations;
using TTRPG_Tuner.BattleProperties;

namespace TTRPG_Tuner.BattleEntities.Actions
{
    public class BaseAction
    {
        public string Name;
        List<BaseActionComponent> ActionComponents;

        public BaseAction(string name)
        {
            this.Name = name;
            this.ActionComponents = new List<BaseActionComponent>();
        }
    }

    public class BaseActionComponent
    {
        public DiceRoll Value = DiceRoll.GetDefault();
        public DamageType DamageType = new DamageType();
        public int Save;
        public string? SaveStat;
        public int Range; // Range of 0 indicates self
        public AreaOfEffect AreaOfAffect = new AreaOfEffect();
        
        public virtual void Affect(BaseEntity entity)
        {
            
        }
    }

    public class Attack : BaseActionComponent
    {
        public override void Affect(BaseEntity entity)
        {
            int damage = this.Value.Roll();
            entity.TakeDamage(damage, this.DamageType);
        }
    }

    public class Healing : BaseActionComponent
    {
        public override void Affect(BaseEntity entity)
        {
            int healing = this.Value.Roll();
            entity.ReceiveHealing(healing);
        }
    }
}