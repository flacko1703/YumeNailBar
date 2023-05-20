﻿using YumeNailBar.Domain.SeedWork;

namespace YumeNailBar.Domain.Exceptions.CustomerExceptions;

internal class NullCustomerIdExceptionBase : DomainExceptionBase
{
    internal NullCustomerIdExceptionBase() 
        : base("Customer id can not be null")
    {
    }
}