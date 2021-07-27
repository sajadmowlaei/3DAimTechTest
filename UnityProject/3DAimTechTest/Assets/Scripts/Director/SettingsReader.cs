using System;
using GameParameters;
using UnityEngine;

namespace Director
{
    public class SettingsReader : MonoBehaviour
    {
        private static SettingsReader _instance;
        public static  SettingsReader Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            _instance = this;
        }

        [SerializeField] private Settings gameSettings;

        public Settings GameSettings => gameSettings;
    }
}
