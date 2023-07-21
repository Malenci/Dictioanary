using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    public class TryingDeletLastTranslationsOption : Exception
    {
        public TryingDeletLastTranslationsOption(string message) : base(message)
        {

        }
    }

    public class ThisWordAlreadyExists : Exception
    {
        public ThisWordAlreadyExists(string message) : base(message)
        {

        }
    }
}