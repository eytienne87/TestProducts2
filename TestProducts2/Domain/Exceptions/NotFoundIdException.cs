namespace Domain.Exceptions
{
    public abstract class NotFoundIdException : NotFoundException
    {
        public NotFoundIdException(int id)
            : base($"The benefit with the identifier {id} could not be found")
        {
        }
    }
}
