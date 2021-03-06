﻿using System;

namespace XDATA
{
    [Serializable]
    public class KnownException : Exception
    {
        public KnownException(string message) : base(string.IsNullOrEmpty(message) ? "Unknown Exception" : message)
        {

        }
    }
}
