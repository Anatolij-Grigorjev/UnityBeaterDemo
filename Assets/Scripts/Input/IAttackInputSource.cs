namespace BeaterDemo.Input
{
    public interface IAttackInputSource
    {
         InputEvent GetLatestAttackInput();

         void ClearLatestAttackInput();
    }
}