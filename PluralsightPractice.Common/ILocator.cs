namespace PluralsightPractice.Common
{
   public interface ILocator
   {
      T GetInstance<T>() where T : class;

      void Register<T>() where T : class;

      void Register<T>(T instance) where T : class;

      void Register<TInterface, TImplementation>() where TImplementation : class, TInterface
                                                   where TInterface : class;
   }
}
