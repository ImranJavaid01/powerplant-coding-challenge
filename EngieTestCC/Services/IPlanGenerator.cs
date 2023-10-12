namespace EngieTestCC.Services
{
    public interface IPlanGenerator
    {
        List<ProductionPlan> GeneratePlan(decimal load, List<FuelCost> fuelCosts, List<Powerplant> powerplants);
    }

}
