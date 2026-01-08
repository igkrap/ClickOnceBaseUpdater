using System;

namespace ModuleContracts
{
    public interface IModule
    {
        string Name { get; }

        string Execute(string input);
    }
}
