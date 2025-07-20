GorillaTagInjector (Source Code)
===============================

A simple WinForms-based DLL injector for Gorilla Tag, built using SharpMonoInjector logic.

⚠️ This is the SOURCE CODE, not a pre-built executable.
You must edit and compile it yourself to match your own mod DLL.

-------------------------------------
🔧 What You Need to Modify
-------------------------------------

In the injector's source code, you'll find textboxes or variables where you must enter:
- Your mod's **Namespace**
- The **Class Name** containing the method
- The **Method Name** you want to run (must be static)

Example:
Namespace: MyMod
Class: MainLoader
Method: StartMod

These must match your compiled DLL structure.

-------------------------------------
🧠 Example Mod Structure
-------------------------------------

namespace MyMod
{
    public class MainLoader : MonoBehaviour
    {
        public static void StartMod()
        {
            // Your mod logic here
        }
    }
}

Injector Input:
- Namespace: MyMod
- Class: MainLoader
- Method: StartMod

-------------------------------------
📦 Requirements
-------------------------------------
- .NET Framework 4.7.2 or later
- Unity Mono-compatible mod DLL
- Visual Studio or another IDE to build the injector

-------------------------------------
🚀 How to Use (After Building)
-------------------------------------
1. Open Gorilla Tag (Steam PC version).
2. Run your built injector as Administrator.
3. Browse and select your mod DLL.
4. Enter the correct namespace/class/method.
5. Click 'Inject'.

-------------------------------------
📞 Need Help?
-------------------------------------
Join our Discord server: https://discord.gg/encryptic

-------------------------------------
📝 License / Use
-------------------------------------
This project is intended for educational and development use only.
You are responsible for how you use this tool. We do NOT support cheating or public abuse.

Credits:
- SharpMonoInjector by warbler
- Injector created by Longno
