using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basy.LethalCompany.Utilities.Commands
{
    public interface ICommand
    {
        public string Command { get; }
        public Task ExecuteAsync(string[] args);
    }
}
