﻿using FluentAssertions;
using GameCore.Domain;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GameCore.Specs.StepDefinitions
{
    [Binding]
    public class GoldorakSteps : TechTalk.SpecFlow.Steps
    {
        private Goldorak _goldorak;
        private readonly GoldorakStepsContext _goldorakStepsContext;


        public GoldorakSteps(GoldorakStepsContext goldorakStepsContext)
        {
            this._goldorakStepsContext = goldorakStepsContext;
        }

        [Given(@"I'm a new Goldorak")]
        public void GivenIMANewGoldorak()
        {
            _goldorak = new Goldorak();
        }

        [Given(@"I have a default damage resistance of (.*)")]
        public void GivenIHaveADefaultDamageResistanceOf(int defaultDamageResistance)
        {
            _goldorak.DefaultDamageResistance = defaultDamageResistance;
        }

        [Given(@"The position of impact is my Head")]
        public void GivenThePositionOfImpactIsMyHead()
        {
            _goldorak.PositionOfImpact = PositionOfImpact.Head;
        }

        [Given(@"The position of impact is (.*)")]
        public void GivenThePositionOfImpactIs(string positionOfImpact)
        {
            try

            {
                _goldorak.PositionOfImpact = (PositionOfImpact)Enum.Parse(typeof(PositionOfImpact), positionOfImpact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            //V1: Weakly typed
            // get value for first row (PositionOfImpact)
            //var positionOfImpact = table.Rows.First(row => row["attribute"] == "PositionOfImpact")["value"];

            // get value for second row (Resistance)
            //var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];

            //try

            //{
            //    _goldorak.PositionOfImpact = (PositionOfImpact)Enum.Parse(typeof(PositionOfImpact), positionOfImpact);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            //V2: Strongly Typed Data table
            //int defaultDamageResistance;
            //if (Int32.TryParse(resistance, out defaultDamageResistance))
            //{
            //    _goldorak.DefaultDamageResistance = defaultDamageResistance;
            //}
            //else throw new InvalidCastException();
            //var attributes = table.CreateInstance<GoldorakAttributes>();

            //V3: Dynamic attributes
            dynamic attributes = table.CreateDynamicInstance();
            _goldorak.PositionOfImpact = (PositionOfImpact)Enum.Parse(typeof(PositionOfImpact),attributes.PositionOfImpact);
            _goldorak.DefaultDamageResistance = attributes.Resistance;
            
        }


        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _goldorak.Hit(damage);
        }

        [When(@"I take (.*) damage")]
        [Scope(Tag="docked")]
        public void WhenITakeDamageAsDocked(int damage)
        {
            _goldorak.UfoState = UfoState.Docked;
            _goldorak.Hit(damage);
            _goldorak.LastMaintenanceDate = DateTime.Now;
            _goldorak.ReadHealthScroll();
        }

        [Then(@"My health should remain (.*)")]
        public void ThenMyHealthShouldRemain(int expectedHealth)
        {
            _goldorak.Health.Should().Be(expectedHealth);
        }

        [Given(@"My Goldorak character ufo state is (.*)")]
        public void GivenMyGoldorakCharacterUfoStateIsDocked(UfoState ufoState)
        {
            _goldorak.UfoState = ufoState;
        }

        [When(@"Execute a repair health request")]
        public void WhenExecuteARepairHealthRequest()
        {
            _goldorak.RepairHealth();
        }

        [Given(@"I have the following magical items")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {
            //V1 : Weakly typed
            //foreach(var row in table.Rows)
            //{
            //    var name = row["item"];
            //    var value = row["value"];
            //    var power = row["power"];

            //    _goldorak.MagicalItems.Add(new MagicalItem
            //    {
            //        Name = name,
            //        Value = int.Parse(value),
            //        Power = int.Parse(power)
            //    });
            //}

            //V2 : Strongly typed
            //var items = table.CreateSet<MagicalItem>();
            //_goldorak.MagicalItems.AddRange(items);

            //V3 : Dynamic attributes
            var items = table.CreateDynamicSet();
            foreach(var magicalItem in items)
            {
                _goldorak.MagicalItems.Add(new MagicalItem
                {
                    Name = magicalItem.name,
                    Value = magicalItem.value,
                    Power = magicalItem.power
                });
            }

        }


        [Then(@"My total magical power should be (.*)")]
        public void ThenMyTotalMagicalPowerShouldBe(int expectedPower)
        {
            _goldorak.MagicalPower.Should().Be(expectedPower);
        }

        [Given(@"I last had maintenance (.* days ago)")]
        public void GivenILastHadMaintenanceDaysAgo(DateTime lastMaintenanceDate)
        {
            _goldorak.LastMaintenanceDate = lastMaintenanceDate;
        }

        [When(@"I request as restore health")]
        public void WhenIRequestAsRestoreHealth()
        {
            _goldorak.ReadHealthScroll();
        }

        [Given(@"I have the following team mates")]
        public void GivenIHaveTheFollowingTeamMates(IEnumerable<TeamMate> teamMates)
        {
            _goldorak.TeamMates.AddRange(teamMates);
        }

        [Then(@"my team mates should be worth (.*)")]
        public void ThenMyTeamMatesShouldBeWorth(int value)
        {
            _goldorak.TeamMatesValue.Should().Be(value);
        }

        //# passing data : ScenarioContext (not thread safe)
        //[Given(@"I have a magic item with a power of (.*)")]
        //public void GivenIHaveAMagicItemWithAPowerOf(int power)
        //{
        //    ScenarioContext.Current["power"] = power;
        //}

        //[Then(@"The magic item power should not be reduced")]
        //public void ThenTheMagicvItemPowerShouldNotBeReduced()
        //{
        //    int expectedPower = (int)ScenarioContext.Current["power"];
        //}

        [Given(@"I'm Docked to my base station")]
        public void GivenIMDockedToMyBaseStation()
        {
            _goldorak.UfoState = UfoState.Docked;
        }

        [Given(@"I have a magical item MegaVolts with a power of (.*)")]
        public void GivenIHaveAMagicalItemMegaVoltsWithAPowerOf(int power)
        {
            // create a magical item of megavolts
            _goldorak.MagicalItems.Add(new MagicalItem
            {
                Name = "MegaVolts",
                Power = power
            });

            // add starting power to the shared context
            // so we can use it in other step definitions
            _goldorakStepsContext.StartingMagicalPower = _goldorak.MagicalItems[0].Power;
        }

        [When(@"I use a magical item MegaVolts")]
        public void WhenIUseAMagicalItemMegaVolts()
        {
            _goldorak.UseMagicalItem("MegaVolts");
        }

        [Then(@"The magical item MegaVolts power should not be reduced")]
        public void ThenTheMagicalItemMegaVoltsPowerShouldNotBeReduced()
        {
            int expectedPower = _goldorakStepsContext.StartingMagicalPower;

            _goldorak.MagicalPower.Should().Be(expectedPower);
        }

    }
}
