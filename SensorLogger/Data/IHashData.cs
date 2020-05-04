namespace SensorLogger.Data
{
    public interface IHashData
    {
        string ComputeHashSha512(string password, string salt);
    }
}
