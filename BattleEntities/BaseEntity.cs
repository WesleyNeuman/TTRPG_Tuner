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
        public Dictionary<string, int> NormalStats;
        public Dictionary<string, int> CurrentStats;
        public DeathState DeathState;
        public int DeathSaves = 0;
        public List<StatusType> CurrentStatuses = new List<StatusType>();

        public List<BaseAction> Actions = new List<BaseAction>();
        public List<DamageType> Resistances = new List<DamageType>();
        public List<DamageType> Immunities = new List<DamageType>();
        public List<DamageType> Weaknesses = new List<DamageType>();
        public List<StatusType> StatusImmunities = new List<StatusType>();

        public AiProfile AiProfile = new AiProfile(1, 0, 0, 0, 0);

        public BaseEntity()
        {
            this.Name = "New Battle Entity";
            this.NormalStats = new Dictionary<string, int> { {"HP", 10} };
            this.CurrentStats = this.NormalStats;
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

            this.CurrentStats["HP"] = this.CurrentStats["HP"] - damage;
            this.CheckDying();
            return damage;
        }

        public int ReceiveHealing(int healing)
        {
            this.CurrentStats["HP"] = this.CurrentStats["HP"] + healing;
            this.CurrentStats["HP"] = this.CurrentStats["HP"] > this.NormalStats["HP"] ? this.NormalStats["HP"] : this.CurrentStats["HP"];
            
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
            if (this.CurrentStats["HP"] > 0)
            {
                this.DeathState = DeathState.Alive;
                this.DeathSaves = 0;
            }
            else if (this.CurrentStats["HP"] < 0 && this.DeathState == DeathState.Alive)
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
                this.CurrentStats["HP"] = 1;
                this.DeathState = DeathState.Alive;
            }
            else if ((this.DeathState == DeathState.Dying && this.DeathSaves <= -3)
                    || this.CurrentStats["HP"] == this.NormalStats["HP"]*-1)
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