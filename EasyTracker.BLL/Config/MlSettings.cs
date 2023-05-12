namespace EasyTracker.BLL.Config;

public static class MlSettings
{
    public const string DateKey = "Date";
    public const string AmountKey = "Count";
    public const string PriceKey = "Price";

    public static string GetLocalDataPath()
    {
        return Path.Combine(GetRootDir(), "MlData", "data.json");
    }

    public static string GetModelPath()
    {
        return Path.Combine(GetRootDir(), "MlData", "model.zip");
    }

    private static string GetRootDir()
    {
        return Path.GetFullPath(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../"));
    }
}
