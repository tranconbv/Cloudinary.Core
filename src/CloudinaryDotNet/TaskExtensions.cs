﻿using System.Threading.Tasks;

namespace CloudinaryDotNet
{
    internal static class TaskExtensions
    {
        public static T Sync<T>(this Task<T> task)
        {
            return task.ConfigureAwait(false).GetAwaiter().GetResult();
        }

    }
}
