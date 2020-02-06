using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCore.Domain
{
    /// <summary>
    /// Author      : Emmanuel Nuyttens
    /// Date        : 02-2020
    /// Purpose     : Goldorak domain class
    /// </summary>
    public class Goldorak
    {
       
        #region Properties

        public int Health { get; protected set; } = 100;
        public bool IsDead { get; protected set; } = false;

        public int DefaultDamageResistance { get; set; } = 0;
        public PositionOfImpact PositionOfImpact { get; set; } = PositionOfImpact.Other;

        public int MagicalPower
        {
            get { return MagicalItems.Sum(magicalItem => magicalItem.Power); }
        }

        public List<MagicalItem> MagicalItems { get; set; } = new List<MagicalItem>();

        
        public int TeamMatesValue
        {
            get { return TeamMates.Sum(teamMate => teamMate.Value); }
        }

        public List<TeamMate> TeamMates { get; set; } = new List<TeamMate>();

        public UfoState UfoState { get; set; } = UfoState.Docked;

        public DateTime LastMaintenanceDate { get; set; }

        #endregion Properties

        #region Behavior

        public void Hit(int damage)
        {
            var positionOfImpactSpecificDamageResistance = 0;

            switch (PositionOfImpact)
            {
                case PositionOfImpact.Other:
                    break;
                case PositionOfImpact.Head:
                    positionOfImpactSpecificDamageResistance = 10;
                    break;
                case PositionOfImpact.Chest:
                    positionOfImpactSpecificDamageResistance = 20;
                    break;
                case PositionOfImpact.Legs:
                    positionOfImpactSpecificDamageResistance = 30;
                    break;
                case PositionOfImpact.Feet:
                    positionOfImpactSpecificDamageResistance = 40;
                    break;
                default:
                    throw new Exception("Unsupported");
            };

            var totalDamageTaken = Math.Max(damage - positionOfImpactSpecificDamageResistance - DefaultDamageResistance, 0);

            Health -= totalDamageTaken;

            if(Health <= 0)
            {
                IsDead = true;
            }
        }

        public void RepairHealth()
        {
            if(UfoState == UfoState.Docked)
            {
                Health = 100;
            }
            else
            {
                Health = Health < 100 ? Health + 10 : Health;
            }
        }

        public void ReadHealthScroll()
        {
            var daysSinceMaintenance = DateTime.Now.Subtract(LastMaintenanceDate).Days;

            if(Health < 100 && daysSinceMaintenance <= 2)
            {
                Health = 100;
            }
        }

        public void UseMagicalItem(string itemName)
        {
            try
            {

                int powerReduction = 10;

                if (UfoState == UfoState.Docked)
                {
                    powerReduction = 0;
                }

                var itemToReduce = MagicalItems.First(item => item.Name == itemName);

                itemToReduce.Power -= powerReduction;

                itemToReduce.Power = itemToReduce.Power < 0 ? 0 : itemToReduce.Power;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Behavior
    }
}
