﻿using FluentAssertions;
using GameCore.Domain;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace GameCore.Specs.StepDefinitions
{
    [Binding]
    public class GoldorakSteps
    {
        private Goldorak _goldorak;

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
            // get value for first row (PositionOfImpact)
            var positionOfImpact = table.Rows.First(row => row["attribute"] == "PositionOfImpact")["value"];

            // get value for second row (Resistance)
            var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];

            try

            {
                _goldorak.PositionOfImpact = (PositionOfImpact)Enum.Parse(typeof(PositionOfImpact), positionOfImpact);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            int defaultDamageResistance;

            if (Int32.TryParse(resistance, out defaultDamageResistance))
            {
                _goldorak.DefaultDamageResistance = defaultDamageResistance;
            }
            else throw new InvalidCastException();
        }


        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _goldorak.Hit(damage);
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


    }
}
