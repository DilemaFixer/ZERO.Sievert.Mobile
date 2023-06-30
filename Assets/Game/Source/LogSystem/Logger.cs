using System;
using System.IO;
using UnityEngine;

namespace Game.Source
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
            Application.logMessageReceived += OnLogMessegReceived;
        }

        private void OnDestroy() =>  Application.logMessageReceived -= OnLogMessegReceived;

        private void OnLogMessegReceived(string Condition, string Stacktrace, LogType type)
        {
            _fileWriter.Write(Condition);
        }
    }
}