using System;
using Gtk;
namespace TdP2019TPFinalRichieri.UI
{
    public class ModalMessage
    {
        public static void Info(Window parentWindow, string pMessage)
        {
            Info(parentWindow, ButtonsType.None, pMessage);
        }

        public static void Info(Window parentWindow, ButtonsType pButtonsType, string pMessage)
        {
            Message(parentWindow, MessageType.Info, pButtonsType, pMessage);
        }

        public static void Error(Window parentWindow, string pMessage)
        {
            Error(parentWindow, ButtonsType.None, pMessage);
        }

        public static void Error(Window parentWindow, ButtonsType pButtonsType, string pMessage)
        {
            Message(parentWindow, MessageType.Error, pButtonsType, pMessage);
        }

        protected static void Message(Window parentWindow, MessageType pMessageType, string pMessage)
        {
            Message(parentWindow, pMessageType, ButtonsType.None, pMessage);
        }

        protected static void Message(Window parentWindow, MessageType pMessageType, ButtonsType pButtonsType, string pMessage)
        {
            var md = new MessageDialog(parentWindow, DialogFlags.Modal, pMessageType, pButtonsType, pMessage);
            md.Run();
            md.Destroy();
        }
    }
}
