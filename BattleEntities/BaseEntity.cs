using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleEntities.Actions;
using TTRPG_Tuner.BattleProperties;

namespace TTRPG_Tuner.BattleEntities
{
    public class BaseEntity
    {
        public string Name;
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public DeathState DeathState;
        public int DeathSaves = 0;
        public List<StatusType> CurrentStatuses = new List<StatusType>();

        public List<BaseAction> Actions = new List<BaseAction>();
        public List<DamageType> Resistances = new List<DamageType>();
        public List<DamageType> Immunities = new List<DamageType>();
        public List<DamageType> Weaknesses = new List<DamageType>();
        public List<StatusType> StatusImmunities = new List<StatusType>();

        public BaseEntity()
        {
            this.Name = "New Battle Entity";
        }

        public int TakeDamage(int damage, DamageType damageType)
        {
            if (this.Immunities.Contains(damageType))
            {
                return 0;
            }
            else if (this.Resistances.Contains(damageType))
            {
                damage = damage / 2;
            }
            
            if (this.Weaknesses.Contains(damageType))
            {
                damage = damage * 2;
            }

            this.CurrentHp = this.CurrentHp - damage;
            this.CheckDying();
            return damage;
        }

        public int ReceiveHealing(int healing)
        {
            this.CurrentHp = this.CurrentHp + healing;
            this.CurrentHp = this.CurrentHp > this.MaxHp ? this.MaxHp : this.CurrentHp;
            
            this.CheckDying();
            return healing;
        }

        public bool ReceiveStatus(StatusType status)
        {
            if (this.StatusImmunities.Contains(status))
            {
                return false;
            }
            else
            {
                this.CurrentStatuses.Add(status);
                return true;
            }
        }

        private void CheckDying()
        {
            if (this.CurrentHp > 0)
            {
                this.DeathState = DeathState.Alive;
                this.DeathSaves = 0;
            }
            else if (this.CurrentHp < 0 && this.DeathState == DeathState.Alive)
            {
                this.DeathState = DeathState.Dying;
                this.DeathSaves = 0;
            }
            else if (this.DeathState == DeathState.Dying)
            {
                this.MakeDeathSave();
            }

            if (this.DeathState == DeathState.Dying && this.DeathSaves >= 3)
            {
                this.CurrentHp = 1;
                this.DeathState = DeathState.Alive;
            }
            else if ((this.DeathState == DeathState.Dying && this.DeathSaves <= -3)
                    || this.CurrentHp == this.MaxHp*-1)
            {
                this.DeathState = DeathState.Dead;
            }
        }

        private void MakeDeathSave()
        {
            Random r = new Random();
            if (r.Next() > 0.5)
            {
                this.DeathSaves += 1;
            }
            else
            {
                this.DeathSaves -=1;
            }
        }
    }

    public enum DeathState
    {
        Alive,
        Dying,
        Dead
    }
}