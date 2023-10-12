
namespace EngieTestCC.Test.Services
{
    public class PowerPlantSelectorTest
    {
        private IPowerPlantSelector _sut;
        public PowerPlantSelectorTest()
        {
            _sut = new PowerPlantSelector();
        }
        [Fact]
        public void SelectPowerPlant_IfWindPantExist_ReturnWindPlant()
        {
            List<Powerplant> powerplants = new List<Powerplant>()
            {
                new Powerplant{ Name="windpark1",Type=nameof(PlantType.windturbine)},
                new Powerplant{ Name="gasfiredbig1",Type=nameof(PlantType.gasfired)},
                new Powerplant{ Name="tj1",Type=nameof(PlantType.turbojet)}
            };
            var result = _sut.SelectPowerPlant(powerplants);

            Assert.NotNull(result);
            Assert.Equal(nameof(PlantType.windturbine), result.Type);

        }
        [Fact]
        public void SelectPowerPlant_IfGasPantExist_ReturnGasPlant()
        {
            List<Powerplant> powerplants = new List<Powerplant>()
            {
                new Powerplant{ Name="gasfiredbig1",Type=nameof(PlantType.gasfired)}
            };
            var result = _sut.SelectPowerPlant(powerplants);

            Assert.NotNull(result);
            Assert.Equal(nameof(PlantType.gasfired), result.Type);

        }
        [Fact]
        public void SelectPowerPlant_IfTurboPantExist_ReturnTurboPlant()
        {
            List<Powerplant> powerplants = new List<Powerplant>()
            {
                new Powerplant{ Name="tj1",Type=nameof(PlantType.turbojet)}
            };
            var result = _sut.SelectPowerPlant(powerplants);

            Assert.NotNull(result);
            Assert.Equal(nameof(PlantType.turbojet), result.Type);

        }
        [Fact]
        public void SelectPowerPlant_IfNoPantExist_ReturnNoPlant()
        {
            List<Powerplant> powerplants = new List<Powerplant>()
            {
                new Powerplant{ Name="tj1",Type="Random"}
            };
            var result = _sut.SelectPowerPlant(powerplants);

            Assert.Null(result);

        }
    }
}
