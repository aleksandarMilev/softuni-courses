namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int IndustrialAsssistantBatteryCapacity = 40_000;
        private const int IndustrialAsssistantConvertionCapacityIndex = 5_000;
        public IndustrialAssistant(string model)
            : base(model, IndustrialAsssistantBatteryCapacity, IndustrialAsssistantConvertionCapacityIndex)
        {
        }
    }
}
