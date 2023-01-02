public static class RandomFloat
{
    public static float Next(float min, float max)
    {
        System.Random random = new System.Random();
        double value = random.NextDouble() * (max - min) + min;

        return (float)value;
    }
}
