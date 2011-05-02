namespace Mangifera.Validation
{
    public interface IValidator<TEntity> where TEntity : class
    {
        ValidationResult Validate(TEntity target);
    }
}
