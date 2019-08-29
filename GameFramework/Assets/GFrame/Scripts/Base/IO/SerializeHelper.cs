using UnityEngine;
using LitJson;
using System;
using System.Text;
using System.IO;

namespace GFrame
{

    public class SerializeHelper
    {
        public static bool SerializeJson(string path, object obj, bool encry)
        {
            if (string.IsNullOrEmpty(path))
            {
                Log.w("SerializeJson Without Valid Path.");
                return false;
            }

            if (obj == null)
            {
                Log.w("SerializeJson obj is Null.");
                return false;
            }

            string jsonValue = null;
            try
            {
                jsonValue = JsonMapper.ToJson(obj);
                if (encry)
                {
                    //jsonValue = EncryptUtil.AesStr(jsonValue, "weoizkxjkfs", "asjkdyweucn");
                }
            }
            catch (Exception e)
            {
                Log.e(e);
                return false;
            }

            Debug.LogError(jsonValue);

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                byte[] writeDataArray = UTF8Encoding.UTF8.GetBytes(jsonValue);
                fs.Write(writeDataArray, 0, writeDataArray.Length);
                fs.Flush();
            }

            return true;
        }

        public static T DeserializeJson<T>(string path, bool encry)
        {
            if (string.IsNullOrEmpty(path))
            {
                Log.w("DeserializeJson Without Valid Path.");
                return default(T);
            }

            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                return default(T);
            }

            using (FileStream stream = fileInfo.OpenRead())
            {
                try
                {
                    if (stream.Length <= 0)
                    {
                        stream.Close();
                        return default(T);
                    }

                    byte[] byteData = new byte[stream.Length];

                    stream.Read(byteData, 0, byteData.Length);

                    string context = UTF8Encoding.UTF8.GetString(byteData);
                    stream.Close();

                    if (string.IsNullOrEmpty(context))
                    {
                        return default(T);
                    }

                    // if (encry)
                    // {
                    //     context = EncryptUtil.UnAesStr(context, "weoizkxjkfs", "asjkdyweucn");
                    // }

                    return JsonMapper.ToObject<T>(context);
                }
                catch (Exception e)
                {
                    Log.e(e);
                }
            }

            Log.w("DeserializeJson Failed!");
            return default(T);//返回T的默认值。
        }
    }
}




