using MelonLoader;
using BTD_Mod_Helper;
using PathsPlusPlus;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Enums;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using JetBrains.Annotations;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppSystem.IO;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Utils;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Runtime.CompilerServices;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

using DartlingGunnerFourthPath;

[assembly: MelonInfo(typeof(DartlingGunnerFourthPath.DartlingGunnerFourthPath), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace DartlingGunnerFourthPath;

public class DartlingGunnerFourthPath : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<DartlingGunnerFourthPath>("DartlingGunnerFourthPath loaded!");
    }
    public class FourthPath2 : PathPlusPlus
    {
        public override string Tower => TowerType.DartlingGunner;
        public override int UpgradeCount => 5;

    }
    public class DeadlyDarts : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 450;
        public override int Tier => 1;
        public override string Icon => VanillaSprites.BloonImpactUpgradeIcon;

        public override string Description => "Darts can knockback bloons and deal more damage.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(new WindModel("stunner", 1f, 2f, 100f, true, null, 0, null, 3));
            attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
        }
    }
    public class CrusherDarts : UpgradePlusPlus<FourthPath2>
    {
        public override int Cost => 1250;
        public override int Tier => 2;
        public override string Icon => VanillaSprites.HeatTippedDartUpgradeIcon;

        public override string Description => "Crusher darts can deal even more damage, but can also do damage to lead.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            attackModel.weapons[0].projectile.GetDamageModel().damage *= 3;
        }
    }
        public class DeathShots : UpgradePlusPlus<FourthPath2>
        {
            public override int Cost => 1450;
            public override int Tier => 3;
            public override string Icon => VanillaSprites.BarbedDartsUpgradeIcon;

            public override string Description => "Slower shooting darts knockback bloons for longer.";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("MonkeySub-020").GetAttackModel().weapons[0].projectile.display;
                attackModel.weapons[0].rate *= 1.4f;
                attackModel.weapons[0].projectile.pierce += 2;
                attackModel.weapons[0].projectile.GetDamageModel().damage *= 7;
                attackModel.weapons[0].projectile.scale *= 1.7f;
            }
        }
        public class ExtremeDestruction : UpgradePlusPlus<FourthPath2>
        {
            public override int Cost => 22500;
            public override int Tier => 4;
            public override string Icon => VanillaSprites.TheBIgOneUpgradeIcon;

            public override string Description => "Darts are destructive, smashing through most layers.";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.pierce += 4;
                attackModel.weapons[0].projectile.GetDamageModel().damage *= 26;
                attackModel.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("MonkeySub-004").GetAttackModel().weapons[0].projectile.display;
            }
        }
        public class Railgunner : UpgradePlusPlus<FourthPath2>
        {
            public override int Cost => 95000;
            public override int Tier => 5;
            public override string Icon => VanillaSprites.EliteDefenderUpgradeIcon;

            public override string Description => "Shoots a single railgun shot every few seconds capable of wiping away layers of bloons.";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].rate *= 3f;
                attackModel.weapons[0].projectile.pierce += 5;
                attackModel.weapons[0].projectile.GetDamageModel().damage *= 98;
                attackModel.weapons[0].projectile.GetBehavior<WindModel>().distanceMax *= 12f;
                attackModel.weapons[0].projectile.GetBehavior<WindModel>().distanceMin *= 10f;
                attackModel.weapons[0].projectile.GetDamageModel().distributeToChildren = true;
                attackModel.weapons[0].projectile.display = Game.instance.model.GetTowerFromId("DartlingGunner-300").GetAttackModel().weapons[0].projectile.display;
                attackModel.weapons[0].projectile.scale *= 4;
            }
        }
    }