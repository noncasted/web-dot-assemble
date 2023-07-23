﻿using System.Runtime.InteropServices;
using UnityEngine;

namespace Global.Services.Publisher.Yandex.DataStorages
{
    public class StorageExternAPI : IStorageAPI
    {
        [DllImport("__Internal")]
        private static extern void GetUserData();

        [DllImport("__Internal")]
        private static extern void SaveUserData(string data);

        public void Get_Internal()
        {
            return;
            GetUserData();
        }

        public void Set_Internal(string data)
        {
            return;
            Debug.Log($"Save internal: {data}");
            SaveUserData(data);
        }
    }
}