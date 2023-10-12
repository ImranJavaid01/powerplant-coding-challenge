public class PowerPlantSelector : IPowerPlantSelector
{
    /// <summary>
    /// This Method with return the Power plant with approriate priority
    /// </summary>
    /// <param name="powerplants"></param>
    /// <returns></returns>
    public Powerplant? SelectPowerPlant(List<Powerplant> powerplants)
    {
        var windPlant = powerplants.FirstOrDefault(x => x.Type == nameof(PlantType.windturbine));
        if (windPlant != null)
        {
            return windPlant;
        }
        var gasPlant = powerplants.FirstOrDefault(x => x.Type == nameof(PlantType.gasfired));
        if (gasPlant != null)
        {
            return gasPlant;
        }
        var turboPlant = powerplants.FirstOrDefault(x => x.Type == nameof(PlantType.turbojet));
        if (turboPlant != null)
        {
            return turboPlant;
        }
        return null;
    }
}
