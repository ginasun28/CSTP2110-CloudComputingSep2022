using System;
using System.Collections.Generic;
using System.Text;

namespace QueueConsoleApp.Common
{
    public interface IStorageConfiguration
    {
        string GetStorageConnectionString();
    }
}
