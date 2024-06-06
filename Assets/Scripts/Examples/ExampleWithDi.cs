using Core.Application.Logging;
using Zenject;

namespace DefaultNamespace
{
    public class ExampleWithDi
    {
        [Inject] private IDebugLogger _debugLogger;

        public void Test()
        {
            _debugLogger.Log("Test");
            _debugLogger.LogWarning("Test");
            _debugLogger.LogError("Test");
            
            
        }
    }
}