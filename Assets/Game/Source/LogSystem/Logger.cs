using System.IO;
using UnityEngine;

namespace Game.LogSystem
{
    public class Logger : MonoBehaviour
    {
        private FileWriter _fileWriter;
        private string _workDirectory;
        
        private void Start()
        {
            _workDirectory = $@"{Application.persistentDataPath}/Logs";
            if (!Directory.Exists(_workDirectory))
            {
                Directory.CreateDirectory(_workDirectory);
            }

            _fileWriter = new FileWriter(_workDirectory);
            Application.logMessageReceivedThreaded += OnLogMessegReceived;
        }

        private void OnDestroy()
        {
            Application.logMessageReceived -= OnLogMessegReceived;
            _fileWriter.Dispose();
        }

        private void OnLogMessegReceived(string Condition, string Stacktrace, LogType type)
        {
            if (type == LogType.Exception)
            {
                _fileWriter.Write(new LogMessage(type , Condition));
                _fileWriter.Write(new LogMessage(type , Stacktrace));
            }
            else
            {
                _fileWriter.Write(new LogMessage(type , Condition));
            }
          
        }
        
    }
}