using Menu.Common.Paths;

namespace Menu.Calendar.Common
{
    public class CalendarRoutes
    {
        public const string ServiceName = MenuAssetsPrefixes.Service + "Calendar_Global";
        public const string ServicePath = MenuAssetsPaths.Root + "Calendar/Global";

        public const string ControllerName = MenuAssetsPrefixes.Service + "Calendar_Ui";
        public const string ControllerPath = MenuAssetsPaths.Root + "Calendar/Ui";

        public const string ConfigName = MenuAssetsPrefixes.Config + "Calendar";
        public const string ConfigPath = MenuAssetsPaths.Root + "Calendar/Config";
        
        public const string DayName = MenuAssetsPrefixes.Config + "Day";
        public const string DayPath = MenuAssetsPaths.Root + "Calendar/Day";
    }
}