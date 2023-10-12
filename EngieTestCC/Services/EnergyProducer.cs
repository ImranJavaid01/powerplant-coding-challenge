namespace EngieTestCC.Services
{
    public class EnergyProducer : IEnergyProducer
    {
        private readonly IPowerPlantSelector _powerPlantSelector;

        public EnergyProducer(IPowerPlantSelector powerPlantSelector)
        {
            _powerPlantSelector = powerPlantSelector;
        }
        /// <summary>
        /// This Method calculate load for a selected power plant
        /// </summary>
        /// <param name="remainingLoad"></param>
        /// <param name="fuelCosts"></param>
        /// <param name="availableplants"></param>
        /// <returns></returns>
        public ProductionPlan ProduceEnergy(decimal remainingLoad, List<FuelCost> fuelCosts, List<Powerplant> availableplants)
        {
            //Select the plan power plant for which we calclute load
            var selectedPowerPlant = _powerPlantSelector.SelectPowerPlant(availableplants);
            var maxCapacity = selectedPowerPlant.Pmax;
            if (selectedPowerPlant.Type == PlantType.windturbine.ToString())
            {
                var windFuel = fuelCosts.First(x => x.Type == FuelType.Wind);
                maxCapacity = Convert.ToDecimal(selectedPowerPlant.Pmax) * windFuel.Cost / 100;
            }
            var energyProduced = maxCapacity > remainingLoad ? remainingLoad : maxCapacity;
            return new ProductionPlan { Name = selectedPowerPlant.Name, Production = energyProduced };
        }
    }
}
