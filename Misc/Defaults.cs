using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTRPG_Tuner.BattleEntities;
using TTRPG_Tuner.BattleEntities.Actions;
using TTRPG_Tuner.BattleProperties;

namespace TTRPG_Tuner
{
    public static class Defaults
    {
        public static Dictionary<string, int> GetDefaultStats()
        {
            return new Dictionary<string, int> {
                { "HP", 10 }
            };
        }

        public static List<StatusType> GetDefaultStatusTypes()
        {
            return new List<StatusType> {
                new StatusType {
                    Name = "Bleeding"
                }
            };
        }

        public static List<DamageType> GetDefaultDamageTypes()
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

        public static List<BaseAction> GetDefaultActions()
        {
            return new List<BaseAction> {
                new BaseAction {
                    Name = "Lacerating Sword",
                    ActionComponents = new List<BaseActionComponent> {
                        new BaseActionComponent {
                            DamageType = GetDefaultDamageTypes()[0],
                            Range = 0,
                            AreaOfAffect = new AreaOfEffect { Size=1, AoeType = AoeType.SingleTile }
                        },
                        new BaseActionComponent {
                            DamageType = GetDefaultDamageTypes()[1],
                            Range = 0,
                            AreaOfAffect = new AreaOfEffect { Size=1, AoeType = AoeType.SingleTile }
                        }
                    }
                }
            };
        }

        public static List<BaseEntity> GetDefaultEntities()
        {
            return new List<BaseEntity> {
                new BaseEntity {
                    Actions = GetDefaultActions()
                }
            };
        }
    }
}