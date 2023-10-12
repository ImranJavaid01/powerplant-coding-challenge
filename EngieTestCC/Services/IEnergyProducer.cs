namespace EngieTestCC.Services
{
    public interface IEnergyProducer
    {
        ProductionPlan ProduceEnergy(decimal remainingLoad, List<FuelCost> fuelCosts, List<Powerplant> availableplants);
    }
}
