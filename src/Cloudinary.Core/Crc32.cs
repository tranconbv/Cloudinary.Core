// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Crc32
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System;

namespace CloudinaryDotNet
{
    /// <summary>
    /// Hashing alghorithm to compute checksum
    /// </summary>
    public static class Crc32
    {
        private static readonly uint[] Table;
        private const uint Hash = 3988292384;

        static Crc32()
        {
            Table = new uint[256];
            for (uint index1 = 0; (long) index1 < (long) Table.Length; ++index1)
            {
                var num2 = index1;
                for (var index2 = 8; index2 > 0; --index2)
                    if (((int) num2 & 1) == 1)
                        num2 = (num2 >> 1) ^ Hash;
                    else
                        num2 >>= 1;
                Table[index1] = num2;
            }
        }

        public static uint ComputeChecksum(byte[] bytes)
        {
            var max = uint.MaxValue;
            for (var index = 0; index < bytes.Length; ++index)
            {
                var tableIndex = (byte) ((max & byte.MaxValue) ^ bytes[index]);
                max = (max >> 8) ^ Table[tableIndex];
            }
            return ~max;
        }

        public static byte[] ComputeChecksumBytes(byte[] bytes)
        {
            return BitConverter.GetBytes(ComputeChecksum(bytes));
        }
    }
}