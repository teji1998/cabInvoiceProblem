﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceDemo
{
    public class CabInvoiceException:Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        ExceptionType type;
        public CabInvoiceException(ExceptionType type, string message)
        {
            this.type = type;
        }
    }
   
}
