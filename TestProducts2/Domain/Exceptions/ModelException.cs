namespace Domain.Exceptions
{
    public sealed class ModelException : Exception
    {
        public ModelException(string message)
            : base(message)
        {
        }
    }
}
