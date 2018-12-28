using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWeekFourCompleted
{
    public enum SerializationType
    {
        Json, Xml, Soap, Binary
    }
    public interface IApplicationSerializable
    {
    }
    public interface IDatabaseModel
    {
    }
}
