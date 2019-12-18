using System;
using System.Collections.Generic;
using System.Text;

namespace SZHelperCore
{
    public class RandomStr
    {
        private static int rep = 0;

        /// <summary> 
        /// 生成随机数字字符串 
        /// </summary> 
        /// <param name="codeCount">待生成的位数</param> 
        /// <returns>生成的数字字符串</returns> 
        public static string GenerateCheckCodeNum(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }
            return str;
        }

        /// <summary> 
        /// 生成随机字母字符串(数字字母混和) 
        /// </summary> 
        /// <param name="codeCount">待生成的位数</param> 
        /// <returns>生成的字母字符串</returns> 
        public static string GenerateCheckCode(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
        /// <summary>
        /// 升级1e内不重复的字符串
        /// </summary>
        /// <returns></returns>
        public static string GenerateStringID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);

        }
        public static long GenerateIntID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
