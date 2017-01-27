// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Crc32
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;

namespace CloudinaryDotNet
{
    public static class Crc32
    {
        private static readonly uint[] table;

        static Crc32()
        {
            var num1 = 3988292384;
            table = new uint[256];
            for (uint index1 = 0; (long) index1 < (long) table.Length; ++index1)
            {
                var num2 = index1;
                for (var index2 = 8; index2 > 0; --index2)
                    if (((int) num2 & 1) == 1)
                        num2 = (num2 >> 1) ^ num1;
                    else
                        num2 >>= 1;
                table[index1] = num2;
            }
        }

        public static uint ComputeChecksum(byte[] bytes)
        {
            var num1 = uint.MaxValue;
            for (var index = 0; index < bytes.Length; ++index)
            {
                var num2 = (byte) ((num1 & byte.MaxValue) ^ bytes[index]);
                num1 = (num1 >> 8) ^ table[num2];
            }
            return ~num1;
        }

        public static byte[] ComputeChecksumBytes(byte[] bytes)
        {
            return BitConverter.GetBytes(ComputeChecksum(bytes));
        }
    }
}