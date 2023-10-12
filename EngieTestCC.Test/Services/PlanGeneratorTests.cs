using EngieTestCC.Services;
using NSubstitute;

namespace EngieTestCC.Test.Services
{
    public class PlanGeneratorTests
    {
        private IEnergyProducer _energyProducer;
        private IPlanGenerator _sut;
        public PlanGeneratorTests()
        {
            _energyProducer = Substitute.For<IEnergyProducer>();

        }
        [Fact]
        public void GeneratePlan_LoadIsNotZero_ShouldGenerateAPlan()
        {
            var load = 100;

            List<Powerplant> powerplants = new List<Powerplant>()
            {
            new Powerplant(){ Efficiency= 15.5M,Name="P1", Pmax=200,Pmin=100,Type="type"},
            new Powerplant(){ Efficiency= 12.5M,Name="P2", Pmax=100,Pmin=500,Type="type1"}
            };

            List<FuelCost> fuelCosts = new List<FuelCost>() {
            new FuelCost(){ Cost=13,Type=FuelType.Wind},
            new FuelCost(){ Cost=8,Type=FuelType.Kerosine}
            };

            _energyProducer.ProduceEnergy(Arg.Any<decimal>(), Arg.Any<List<FuelCost>>(), Arg.Any<List<Powerplant>>()).Returns(new ProductionPlan { Name = "P1", Production = 50 });

            _sut = new PlanGenerator(_energyProducer);
            var result = _sut.GeneratePlan(load, fuelCosts, powerplants);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);

            Assert.All(result, plan =>
            {
                Assert.Equal("P1", plan.Name);
                Assert.Equal(50, plan.Production);
            });
        }
    }
}
