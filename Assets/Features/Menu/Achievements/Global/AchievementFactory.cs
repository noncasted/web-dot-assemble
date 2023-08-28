using System;
using System.Collections.Generic;
using Menu.Achievements.Definitions;

namespace Menu.Achievements.Global
{
    public class AchievementFactory : IAchievementFactory
    {
        public IAchievement Create(AchievementConfig config, IReadOnlyDictionary<AchievementType, int> save)
        {
            var currentProgress = 0;

            if (save.ContainsKey(config.Type) == true)
                currentProgress = save[config.Type];

            var progress = new AchievementProgress(config.Type, config.TargetProgress, currentProgress);
            var completionChecker = CreateCompletionChecker(config.Type, progress);
            var data = new AchievementData(config.Icon, config.Name, config.Description, config.Type);

            return new Achievement(progress, data, completionChecker);
        }

        private IAchievementCompletionChecker CreateCompletionChecker(AchievementType type, IAchievementProgress progress)
        {
            switch (type)
            {
                case AchievementType.Type_1:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_2:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_3:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_0:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_4:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_5:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_6:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_7:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_8:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_9:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_10:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_11:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_12:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_13:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_14:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_15:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_16:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_17:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_18:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_19:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_20:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_21:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_22:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_23:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_24:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_25:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_26:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_27:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_28:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_29:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_30:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_31:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_32:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_33:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_34:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_35:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_36:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_37:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_38:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_39:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_40:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_41:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_42:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_43:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_44:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_45:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_46:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_47:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_48:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_49:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_50:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_51:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_52:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_53:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_54:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_55:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_56:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_57:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_58:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_59:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_60:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_61:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_62:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_63:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_64:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                case AchievementType.Type_65:
                    return new AchievementTypeHandlerProgress<TestPayload>(progress);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}