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
        public List<BaseEntity> _characters;
        public List<BaseEntity> _enemies;
        public List<BaseAction> _actions;
        public List<DamageType> _damageTypes;
        public List<StatusType> _statusTypes;
        public BuildEncounterPartialClass()
        {
            this._damageTypes = this.GetDefaultDamageTypes();
            this._statusTypes = this.GetDefaultStatusTypes();
            this._actions = this.GetDefaultActions();
            this._characters = this.GetDefaultEntities();
            this._enemies = this.GetDefaultEntities();
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
                            DamageType = this._damageTypes[0],
                            Range = 0,
                            AreaOfAffect = new AreaOfEffect { Size=1, AoeType = AoeType.SingleTile }
                        },
                        new BaseActionComponent {
                            DamageType = this._damageTypes[1],
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