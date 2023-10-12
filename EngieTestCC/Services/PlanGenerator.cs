namespace EngieTestCC.Services
{
    public class PlanGenerator : IPlanGenerator
    {
        private readonly IEnergyProducer _energyProducer;

        public PlanGenerator(IEnergyProducer energyProducer)
        {
            _energyProducer = energyProducer;
        }
        /// <summary>
        /// This method will return the multitude of all given power plants
        /// </summary>
        /// <param name="load"></param>
        /// <param name="fuelCosts"></param>
        /// <param name="powerplants"></param>
        /// <returns></returns>
        public List<ProductionPlan> GeneratePlan(decimal load, List<FuelCost> fuelCosts, List<Powerplant> powerplants)
        {
            var remainingLoad = load;
            List<ProductionPlan> productionPlan = new List<ProductionPlan>();

            while (powerplants.Count > 0)
            {
                //Get a calculated load production for a power plant
                var plan = _energyProducer.ProduceEnergy(remainingLoad, fuelCosts, powerplants);
                remainingLoad -= plan.Production;
                var powerPlantUsed = powerplants.FirstOrDefault(x => x.Name == plan.Name);
                powerplants.Remove(powerPlantUsed);
                productionPlan.Add(plan);

            }
            return productionPlan;
        }
    }
}
