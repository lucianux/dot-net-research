using System;

namespace exampleDI
{
    public class Hello1: IHello
    {
        public string GetMessage()
        {
            return "Message example";
        }
    }
}
