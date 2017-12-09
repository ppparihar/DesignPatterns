using System;

namespace MissionCode.DesignPatterns.SOLID
{
    //Interface Segregation Principle
    //Don't put too much into an interface;split into seprate interface
    public interface IPhone
    {
        void MakeVoiceCall();

        void SendMessage();

        void MakeVideoCall();
    }
    public class SmartPhone : IPhone
    {
        public void MakeVoiceCall()
        {
            Console.Write("Voice Call!!");
        }

        public void SendMessage()
        {
            Console.Write("Message sent!!");
        }

        public void MakeVideoCall()
        {
            Console.Write("Video Call!!");
        }
    }

    public class OldPhone : IPhone
    {
        public void MakeVoiceCall()
        {
            Console.Write("Voice Call!!");
        }

        public void SendMessage()
        {
            Console.Write("Message sent!!");
        }

        //Breaks the interface segregation principle 
        //Video call is not supported in the OldPhone and but it is forcing to implement the MakeVideoCall
        public void MakeVideoCall()
        {
            throw new NotImplementedException();
        }
    }

    // Handle the interface segregation principle 

    public interface IBasicPhone
    {
        void MakeVoiceCall();
        void SendMessage();

    }

    public interface ISmartPhone : IBasicPhone
    {
        void MakeVideoCall();
    }

    public class SmartPhoneWithISP : ISmartPhone
    {
        public void MakeVoiceCall()
        {
            Console.Write("Voice call with ISP!!");
        }

        public void SendMessage()
        {
            Console.Write("Message sent with ISP!!");
        }

        public void MakeVideoCall()
        {
            Console.Write("Video Call with ISP!!");
        }
    }

    public class OldPhoneWithISP : IBasicPhone
    {
        public void MakeVoiceCall()
        {
            Console.Write("Voice Call with ISP!!");
        }

        public void SendMessage()
        {
            Console.Write("Message sent with ISP!!");
        }

    }

}