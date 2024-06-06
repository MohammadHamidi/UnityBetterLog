
# Unity Better Log

This package provides a custom debug logger for Unity projects. It allows you to log messages with different log levels and colors, and provides customization options through a scriptable object.

## Features
- Log messages with different log levels (Info, Warning, Error)
- Customize log colors for each log level
- Scriptable object for easy configuration
- Conditional compilation for editor and debug builds
- Dependency injection support using Zenject

## Installation
1. Download the `DebugLogger.unitypackage` file from the releases page.
2. In your Unity project, go to "Assets" -> "Import Package" -> "Custom Package".
3. Select the downloaded package file and click "Import".
4. (Optional) If you want to use dependency injection with Zenject:
   - Make sure you have Zenject installed in your project. You can install it via the Unity Package Manager or by downloading it from the Zenject repository.
   - Add the `LoggerInstaller` script to your project's installers.

## Usage

### Basic Usage
1. Create an instance of the `DebugLogger` class in your script:
   ```csharp
   using Core.Application.Logging;

   public class MyScript : MonoBehaviour
   {
       private IDebugLogger logger;

       private void Awake()
       {
           logger = new DebugLogger();
       }
   }
   ```

2. Use the logging methods to log messages:
   ```csharp
   logger.Log("This is an info message");
   logger.LogWarning("This is a warning message");
   logger.LogError("This is an error message");
   ```

3. Customize the log settings by modifying the `LogSettings` scriptable object in the "Resources" folder.

### Usage with Dependency Injection (Zenject)
1. Add the `LoggerInstaller` script to your project's installers:
   ```csharp
   using Core.Application.Logging;
   using Zenject;

   public class LoggerInstaller : MonoInstaller
   {
       public override void InstallBindings()
       {
           Container.Bind<IDebugLogger>().To<DebugLogger>().AsSingle().NonLazy();
       }
   }
   ```

2. Inject the `IDebugLogger` interface into your scripts:
   ```csharp
   using Core.Application.Logging;
   using Zenject;

   public class ExampleWithDI
   {
       [Inject] private IDebugLogger _debugLogger;

       public void Test()
       {
           _debugLogger.Log("Test");
           _debugLogger.LogWarning("Test");
           _debugLogger.LogError("Test");
       }
   }
   ```

3. Customize the log settings by modifying the `LogSettings` scriptable object in the "Resources" folder.

