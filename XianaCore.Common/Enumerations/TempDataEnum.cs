using System;
using System.Collections.Generic;
using System.Text;

namespace XianaCore.Common.Enumerations
{
    public class TempDataEnum : EnumeratorManager
    {
        private static TempDataEnum _resultMessage = new TempDataEnum(1, "ResultMessage");

        private static TempDataEnum _resultType = new TempDataEnum(2, "ResultType");
        public static TempDataEnum ResultMessage => _resultMessage;

        public static TempDataEnum ResultType => _resultType;

        public TempDataEnum(int id, string name): base (id, name)
        {
        }
    }
}
