using System;
using UnityEngine;

namespace Game.LogSystem
{
    public class LogMessage
    {
        public LogType Type { get; private set; }
        public DateTime Time { get; private set; }
        public string Message { get; private set; }

        public LogMessage(LogType Type, string Message)
        {
            this.Message = Message;
            this.Time = DateTime.UtcNow;
            this.Type = Type;
        }

        public void UpdaiteTime()
        {
            this.Time = DateTime.UtcNow;
        }
    }
}