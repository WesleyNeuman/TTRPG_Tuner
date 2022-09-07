using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleEntities;
using TTRPG_Tuner.BattleEntities.Actions;
using TTRPG_Tuner.BattleProperties;

namespace TTRPG_Tuner.Pages.BuildEncounter
{
    public partial class BuildEncounterPartialClass
    {
        public List<BaseEntity> Characters;
        public List<BaseEntity> Enemies;
        public List<BaseAction> Actions;
        public List<DamageType> DamageTypes;
        public List<StatusType> StatusTypes;
        public BuildEncounterPartialClass()
        {
            this.DamageTypes = this.GetDefaultDamageTypes();
            this.StatusTypes = this.GetDefaultStatusTypes();
            this.Actions = this.GetDefaultActions();
            this.Characters = this.GetDefaultEntities();
            this.Enemies = this.GetDefaultEntities();
        }

        public List<StatusType> GetDefaultStatusTypes()
        {
            return new List<StatusType> {
                new StatusType {
                    Name = "Bleeding"
                }
            };
        }

        public List<DamageType> GetDefaultDamageTypes()
        {
            return new List<DamageType> {
                new DamageType {
                    Name = "Slashing"
                },
                new DamageType {
                    Name = "Bleeding"
                }
            };
        }

        public List<BaseAction> GetDefaultActions()
        {
            return new List<BaseAction> {
                new BaseAction {
                    Name = "Lacerating Sword",
                    ActionComponents = new List<BaseActionComponent> {
                        new BaseActionComponent {
                            DamageType = this.DamageTypes[0],
                            Range = 0,
                            AreaOfAffect = new AreaOfEffect { Size=1, AoeType = AoeType.SingleTile }
                        },
                        new BaseActionComponent {
                            DamageType = this.DamageTypes[1],
                            Range = 0,
                            AreaOfAffect = new AreaOfEffect { Size=1, AoeType = AoeType.SingleTile }
                        }
                    }
                }
            };
        }

        public List<BaseEntity> GetDefaultEntities()
        {
            return new List<BaseEntity> {
                new BaseEntity {
                    MaxHp = 10,
                    CurrentHp = 10,
                    Actions = GetDefaultActions()
                }
            };
        }
    }
}